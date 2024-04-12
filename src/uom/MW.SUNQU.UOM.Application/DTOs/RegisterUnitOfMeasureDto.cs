using MW.SUNQU.UOM.Domain.ValueObject;

namespace MW.SUNQU.UOM.Application.DTOs;

public record RegisterUnitOfMeasureDto
{
    public string Description { get; init; }
    public string Abbreviation { get; init; }
    public float? NumericalValue { get; init; }
    public UnitOfMeasureId? BaseUnit { get; init; }
}