using MW.SUNQU.UOM.Domain.ValueObject;
using MW.SUNQU.UOM.Domain.Entities;

namespace MW.SUNQU.UOM.Domain.Interfaces;

public interface IUnitOfMeasureRepository : IDisposable
{
    Task<bool> BulkRegisterAsync(IEnumerable<UnitOfMeasure> uomCollection);
    Task<IEnumerable<UnitOfMeasure>> GetAllAsync();
    Task<UnitOfMeasureId> RegisterUnitOfMeasureAsync(UnitOfMeasure uom);
}