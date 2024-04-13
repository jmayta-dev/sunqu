using MW.SUNQU.UOM.Domain.ValueObject;
using MW.SUNQU.UOM.Domain.Entities;

namespace MW.SUNQU.UOM.Domain.Interfaces;

public interface IUnitOfMeasureRepository : IDisposable
{
    Task<bool> BulkRegisterAsync(
        IEnumerable<UnitOfMeasure> uomCollection,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<UnitOfMeasure>> GetAllAsync(
        CancellationToken cancellationToken = default);
    Task<UnitOfMeasureId> RegisterAsync(
        UnitOfMeasure uom,
        CancellationToken cancellationToken = default);
}