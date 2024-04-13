using MediatR;
using MW.CHUYA.Application.UseCases.Common;
using MW.SUNQU.UOM.Application.DTOs;

namespace MW.SUNQU.UOM.Application.UseCases.Queries.GetAllUnitsOfMeasure;

public class GetAllUnitsOfMeasureQuery
    : IRequest<BaseResponse<IEnumerable<GetAllUnitsOfMeasureDto>>>
{

}