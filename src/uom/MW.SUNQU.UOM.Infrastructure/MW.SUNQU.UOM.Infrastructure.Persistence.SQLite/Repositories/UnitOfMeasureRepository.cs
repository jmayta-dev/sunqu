using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using MW.SUNQU.UOM.Domain.Entities;
using MW.SUNQU.UOM.Domain.Interfaces;
using MW.SUNQU.UOM.Domain.ValueObject;
using MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Context;

namespace MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Repositories;

public class UnitOfMeasureRepository : IUnitOfMeasureRepository
{
    #region Properties & Variables
    //
    // private
    //
    private bool _disposed = false;
    private readonly UnitOfMeasureDbContext _context;
    //
    // public
    //
    #endregion
    
    #region IDisposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context?.Connection?.Close();
                _context?.Connection?.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion

    #region Constructor
    public UnitOfMeasureRepository(UnitOfMeasureDbContext context)
    {
        _context = context;
    }
    #endregion
    public Task<bool> BulkRegisterUom(IEnumerable<UnitOfMeasure> uomCollection)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<UnitOfMeasure>> GetAllUnitsOfMeasureAsync(
        CancellationToken cancellationToken = default)
    {
        List<UnitOfMeasure> uoms = new();
        using SqliteConnection connection = (SqliteConnection)_context.Connection;
        await connection.OpenAsync(cancellationToken);
        
        using SqliteTransaction uomTransaction =
            (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken);
        using SqliteCommand command = new();
        command.CommandText =
        @"
            SELECT *
            FROM UnitOfMeasure
        ";
        command.Transaction = uomTransaction;
        command.Connection = connection;
        
        SqliteDataReader reader =
            await command.ExecuteReaderAsync(cancellationToken);

        if(reader.HasRows)
            while(await reader.ReadAsync(cancellationToken))
            {
                UnitOfMeasure.Builder uomBuilder = new();
                uomBuilder.WithDescription(
                    reader.GetString(reader.GetOrdinal("Description"))
                );
                uomBuilder.WithAbbreviation(
                    reader.GetString(reader.GetOrdinal("Abbreviation"))
                );
                uoms.Add(uomBuilder.Build());
            }

        return uoms ?? new List<UnitOfMeasure>();
    }

    public Task<UnitOfMeasureId> RegisterUnitOfMeasure(UnitOfMeasure uom)
    {
        throw new NotImplementedException();
    }

    public Task<UnitOfMeasureId> RegisterUnitOfMeasureAsync(UnitOfMeasure uom, out DbTransaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UnitOfMeasure>> GetAllUnitsOfMeasureAsync(out DbTransaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<UnitOfMeasureId> RegisterUnitOfMeasureAsync(UnitOfMeasure uom, out IDbTransaction transaction)
    {
        throw new NotImplementedException();
    }
}