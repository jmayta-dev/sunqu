using Microsoft.Data.Sqlite;

namespace MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Repositories;

public abstract class Repository
{
    #region Properties & Variables
    protected SqliteConnection _connection;
    protected SqliteTransaction _transaction;
    #endregion Properties & Variables

    #region Constructor
    protected Repository(SqliteConnection connection, SqliteTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }
    #endregion Constructor

    #region Methods
    protected SqliteCommand CreateCommand(string query) =>
        new(query, _connection, _transaction);
    #endregion Methods
}