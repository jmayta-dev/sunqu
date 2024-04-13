using Microsoft.Data.Sqlite;
using MW.SUNQU.UOM.Domain.Interfaces;
using MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Context;

namespace MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Repositories;

public class UnitOfWorkUom : IUnitOfWorkUom
{
    #region Properties & Variables
    //
    // private
    //
    private bool disposed = false;
    private readonly SqliteConnection _connection;
    private readonly SqliteTransaction _transaction;
    //
    // public
    //
    public IUnitOfMeasureRepository UnitOfMeasureRepository =>
        new UnitOfMeasureRepository(_connection, _transaction);
    #endregion

    #region Constructor
    public UnitOfWorkUom(UnitOfMeasureDbContext context)
    {
        _connection = (SqliteConnection)context.Connection;
        _connection.Open();

        _transaction = _connection.BeginTransaction();
    }
    #endregion

    #region IDisposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _connection?.Close();
                _connection?.Dispose();

                _transaction?.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion

    #region Methods
    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _transaction.Rollback(), cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _transaction.Commit(), cancellationToken);
    }
    #endregion Methods
}