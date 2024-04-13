
namespace MW.SUNQU.UOM.Domain.Interfaces;

public interface IUnitOfWorkUom : IDisposable
{
    IUnitOfMeasureRepository UnitOfMeasure { get; }
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}