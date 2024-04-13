using MediatR;
using MW.CHUYA.Application.UseCases.Common;
using MW.SUNQU.UOM.Application.DTOs;
using MW.SUNQU.UOM.Application.UseCases.Queries.GetAllUnitsOfMeasure;
using MW.SUNQU.UOM.Domain.Entities;
using MW.SUNQU.UOM.Domain.Interfaces;

namespace MW.SUNQU.UOM.Application.UseCases.Queries;

public class GetAllUnitsOfMeasureHandler
    : IRequestHandler<GetAllUnitsOfMeasureQuery, BaseResponse<IEnumerable<GetAllUnitsOfMeasureDto>>>
{
    #region Properties & Variables
    //
    // dependencies
    //
    private readonly IUnitOfWorkUom _unitOfWorkUom;
    //
    // private
    //
    //
    // public
    //
    #endregion

    #region Constructor
    public GetAllUnitsOfMeasureHandler(IUnitOfWorkUom unitOfWorkUom)
    {
        _unitOfWorkUom = unitOfWorkUom;
    }
    #endregion Constructor

    public async Task<BaseResponse<IEnumerable<GetAllUnitsOfMeasureDto>>> Handle(
        GetAllUnitsOfMeasureQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<GetAllUnitsOfMeasureDto>>();

        try
        {
            IEnumerable<UnitOfMeasure> uomCollection =
                await _unitOfWorkUom
                    .UnitOfMeasureRepository
                    .GetAllAsync(cancellationToken);
            
            if (uomCollection is not null)
            {
                // map UnitOfMeasure -> GetAllUnitsOfMeasureDto
                IEnumerable<GetAllUnitsOfMeasureDto> uomDtoCollection =
                    uomCollection.Select(u => new GetAllUnitsOfMeasureDto
                    {
                        Id = u.Id,
                        Description = u.Description,
                        Abbreviation = u.Abbreviation,
                        BaseUnitId = u.BaseUnitId,
                        NumericalValue = u.NumericalVaue,
                        IsActive = u.IsActive
                    });

                response.IsSuccess = true;
                response.Data = uomDtoCollection;
                response.Message = "Success";
            }
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            throw;
        }

        return response;
    }
}