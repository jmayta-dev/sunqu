
namespace MW.SUNQU.UOM.Domain.Interfaces;

public interface IUnitOfWorkUom : IDisposable
{
    IUnitOfMeasureRepository UnitOfMeasureRepository { get; }
    Task RollbackAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}