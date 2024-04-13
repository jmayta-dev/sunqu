using MW.SUNQU.UOM.Domain.ValueObject;

namespace MW.SUNQU.UOM.Application.DTOs;

public record GetAllUnitsOfMeasureDto
{
    public UnitOfMeasureId? Id { get; set; }
    public string? Description { get; init; }
    public string? Abbreviation { get; init; }
    public float? NumericalValue { get; init; }
    public UnitOfMeasureId? BaseUnitId { get; init; }
    public bool? IsActive { get; init; }
}