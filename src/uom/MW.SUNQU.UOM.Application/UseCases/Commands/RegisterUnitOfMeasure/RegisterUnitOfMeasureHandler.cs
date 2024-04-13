using MediatR;
using MW.CHUYA.Application.Common.Interfaces;
using MW.CHUYA.Application.UseCases.Common.Base;
using MW.SUNQU.UOM.Application.DTOs;
using MW.SUNQU.UOM.Domain.Entities;
using MW.SUNQU.UOM.Domain.Interfaces;
using MW.SUNQU.UOM.Domain.ValueObject;
using System.Data.Common;

namespace MW.SUNQU.UOM.Application.UseCases.Commands;

public class RegisterUnitOfMeasureHandler :
    IRequestHandler<RegisterUnitOfMeasureCommand, BaseResponse<UnitOfMeasureDto>>
{
    #region Properties & Variables
    // private
    private readonly IUnitOfWorkUom _unitOfWorkUom;
    // public
    #endregion

    #region Constructor
    public RegisterUnitOfMeasureHandler(IUnitOfWorkUom unitOfWorkUom)
    {
        _unitOfWorkUom = unitOfWorkUom;
    }
    #endregion

    #region Methods
    public async Task<BaseResponse<UnitOfMeasureDto>> Handle(
        RegisterUnitOfMeasureCommand request,
        CancellationToken cancellationToken)
    {
        // construir unidad de medida
        UnitOfMeasure.Builder uomBuilder = new();
        uomBuilder.WithAbbreviation(request.Abbreviation);
        uomBuilder.WithDescription(request.Description);
        uomBuilder.WithNumericalValue(request.NumericalValue);
        if (request.BaseUnit is not null)
        {
            UnitOfMeasureId baseUnitId = new((int)request.BaseUnit);
            uomBuilder.WithBaseUnit(baseUnitId);
        }
        UnitOfMeasure uom = uomBuilder.Build();

        // registrar y obtener id de unidad de medida
        UnitOfMeasureId unitOfMeasureId =
            await _unitOfWorkUom.UnitOfMeasure.RegisterAsync(uom, cancellationToken);

        // confirmar y grabar cambios
        await _unitOfWorkUom.SaveChangesAsync(cancellationToken);

        // preparar respuesta
        var uomDto = new UnitOfMeasureDto
        {
            Id = unitOfMeasureId,
            Abbreviation = uom.Abbreviation,
            Description = uom.Description,
            NumericalValue = uom.NumericalVaue,
            BaseUnit = uom.BaseUnit
        };
        // retornar respuesta
        return new BaseResponse<UnitOfMeasureDto>
        {
            IsSuccess = true,
            Data = uomDto
        };
    }
    #endregion
}