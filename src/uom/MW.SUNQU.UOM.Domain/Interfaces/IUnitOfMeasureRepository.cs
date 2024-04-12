using MW.SUNQU.UOM.Domain.ValueObject;
using MW.SUNQU.UOM.Domain.Entities;
using System.Data.Common;
using System.Data;

namespace MW.SUNQU.UOM.Domain.Interfaces;

public interface IUnitOfMeasureRepository: IDisposable
{
    Task<bool> BulkRegisterUom(IEnumerable<UnitOfMeasure> uomCollection);
    Task<IEnumerable<UnitOfMeasure>> GetAllUnitsOfMeasureAsync(
        out DbTransaction transaction
    );
    Task<UnitOfMeasureId> RegisterUnitOfMeasure(UnitOfMeasure uom);
    Task<UnitOfMeasureId> RegisterUnitOfMeasureAsync(
        UnitOfMeasure uom, out IDbTransaction transaction);
}