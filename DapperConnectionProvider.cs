using Microsoft.Extensions.Configuration;
using System.Data;

namespace DapperWork;

public class DapperConnectionProvider
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperConnectionProvider(IConfiguration configuration)
    {
        _configuration = configuration;

        _connectionString = _configuration.GetConnectionString("SqlServer");
    }

    public IDbConnection Connect() => new Microsoft.Data.SqlClient.SqlConnection(_connectionString);
}