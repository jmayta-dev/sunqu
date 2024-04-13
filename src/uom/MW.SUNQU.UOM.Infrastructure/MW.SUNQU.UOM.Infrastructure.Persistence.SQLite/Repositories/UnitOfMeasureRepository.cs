using Microsoft.Data.Sqlite;
using MW.SUNQU.UOM.Domain.Entities;
using MW.SUNQU.UOM.Domain.Interfaces;
using MW.SUNQU.UOM.Domain.ValueObject;

namespace MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Repositories;

public class UnitOfMeasureRepository : Repository, IUnitOfMeasureRepository
{
    #region Properties & Variables
    //
    // private
    //
    private bool _disposed = false;
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
                _connection?.Close();
                _connection?.Dispose();
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
    public UnitOfMeasureRepository(
        SqliteConnection connection, SqliteTransaction transaction) :
        base(connection, transaction)
    {

    }
    #endregion Constructor

    #region Methods
    public Task<bool> BulkRegisterUom(IEnumerable<UnitOfMeasure> uomCollection)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<UnitOfMeasure>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        List<UnitOfMeasure> uoms = new();
        string query =
        @"
            SELECT
                Id, Description, Abbreviation,
                NumericalValue, BaseUnit
            FROM
                UnitOfMeasure
        ";
        using SqliteCommand command = CreateCommand(query);

        SqliteDataReader reader =
            await command.ExecuteReaderAsync(cancellationToken);

        if (reader.HasRows)
            while (await reader.ReadAsync(cancellationToken))
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

    public Task<bool> BulkRegisterAsync(IEnumerable<UnitOfMeasure> uomCollection, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UnitOfMeasureId> RegisterAsync(UnitOfMeasure uom, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion Methods
}