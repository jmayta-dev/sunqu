
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace MW.SUNQU.UOM.Infrastructure.Persistence.SQLite.Context;

public class  UnitOfMeasureDbContext
{
    #region Properties & Variables
    // private
    private readonly string _connectionString;
    // public
    public IDbConnection Connection {
        get => new SqliteConnection(_connectionString);
    }
    #endregion

    #region Constructor
    public UnitOfMeasureDbContext(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("SUNQU.SQLite") ?? string.Empty;
    }
    #endregion
}