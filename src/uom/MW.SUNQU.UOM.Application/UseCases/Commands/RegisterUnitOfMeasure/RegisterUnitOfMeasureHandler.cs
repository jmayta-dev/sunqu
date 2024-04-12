using MediatR;
using MW.CHUYA.Application.Common.Interfaces;
using MW.SUNQU.UOM.Application.DTOs;
using MW.SUNQU.UOM.Domain.Entities;
using MW.SUNQU.UOM.Domain.Interfaces;
using MW.SUNQU.UOM.Domain.ValueObject;
using System.Data.Common;

namespace MW.SUNQU.UOM.Application.UseCases.Commands;

public class RegisterUnitOfMeasureHandler :
    IRequestHandler<RegisterUnitOfMeasureCommand, UnitOfMeasureDto>
{
    #region Properties & Variables
    // private
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUnitOfMeasureRepository _uomRepository;
    // public
    #endregion

    #region Constructor
    public RegisterUnitOfMeasureHandler(
        IUnitOfWork unitOfWork,
        IUnitOfMeasureRepository uomRepository)
    {
        _unitOfWork = unitOfWork;
        _uomRepository = uomRepository;
    }
    #endregion

    #region Methods
    public async Task<UnitOfMeasureDto> Handle(
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
            await _uomRepository.RegisterUnitOfMeasureAsync(
                uom, out DbTransaction transaction);
        
        // confirmar y grabar cambios
        await _unitOfWork.SaveChangesAsync(transaction, cancellationToken);

        // retornar resultado
        return new UnitOfMeasureDto
        {
            Id = unitOfMeasureId,
            Abbreviation = uom.Abbreviation,
            Description = uom.Description,
            NumericalValue = uom.NumericalVaue
        };
    }
    #endregion
}