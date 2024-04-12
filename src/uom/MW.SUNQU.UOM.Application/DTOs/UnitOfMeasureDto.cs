using MW.SUNQU.UOM.Domain.ValueObject;

namespace MW.SUNQU.UOM.Application.DTOs;

public record UnitOfMeasureDto
{
    public UnitOfMeasureId? Id { get; set; }
    public string? Description { get; init; }
    public string? Abbreviation { get; init; }
    public float? NumericalValue { get; init; }
    public UnitOfMeasureId? BaseUnit { get; init; }
}