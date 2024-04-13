using Microsoft.Data.Sqlite;
using MW.CHUYA.Application.Common.Interfaces;
using MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Context;

namespace MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Repositories;

public class UnitOfWorkSQLite : IUnitOfWork
{
    #region Properties & Variables
    //
    // private
    //
    private bool disposed = false;
    private SqliteConnection _connection { get; init; }
    private SqliteTransaction _transaction { get; init; }
    //
    // public
    //
    #endregion

    #region Constructor
    public UnitOfWorkSQLite(UnitOfMeasureDbContext context)
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

    public Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}