using MediatR;
using MW.SUNQU.UOM.Application.DTOs;

namespace MW.SUNQU.UOM.Application.UseCases.Commands;

public record RegisterUnitOfMeasureCommand (
    string Description,
    string Abbreviation,
    float? NumericalValue = null,
    int? BaseUnit = null
    ) : IRequest<UnitOfMeasureDto>;
