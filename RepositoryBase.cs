using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperCrud.Models;

namespace DapperWork;

public class RepositoryBase
{
    private readonly DapperConnectionProvider _dapperProvider;

    public RepositoryBase(DapperConnectionProvider dapperProvider)
    {
        _dapperProvider = dapperProvider;
    }

    // For querying
    public async Task<T> QuerySingle<T, U>(string Sql,
                                           U parameters,
                                           CommandType commandType = CommandType.Text)
    {
        using (var connection = _dapperProvider.Connect())
        {
            return await connection.QuerySingleOrDefaultAsync<T>(Sql, parameters, commandType: commandType).ConfigureAwait(false);
        }       
    }

    // For insert and update
    public async Task<T> QuerySingle<T>(string Sql,
                                        T parameters,
                                        CommandType commandType = CommandType.Text)
    {
        using (var connection = _dapperProvider.Connect())
        {
            return await connection.QuerySingleOrDefaultAsync<T>(Sql, parameters, commandType: commandType).ConfigureAwait(false);
        }
    }

    public async Task Exec<T>(string sql,
                              T parameters,
                              CommandType commandType = CommandType.Text)
    { 
        using (var connection = _dapperProvider.Connect())
        {
            await connection.ExecuteAsync(sql,
                                          parameters,
                                          commandType: commandType).ConfigureAwait(false);
        }
    }

    public async Task<IEnumerable<T>> Query<T,U>(string sql,
                                                 U parameters,
                                                 CommandType commandType = CommandType.Text)
    { 
        using (var connection = _dapperProvider.Connect())
        {
            return await connection.QueryAsync<T>(sql, parameters, commandType: commandType).ConfigureAwait(false);
        }
    }


    public async Task<IEnumerable<T>> Query<T>(string sql,
                                               CommandType commandType = CommandType.Text)
    { 
        using (var connection = _dapperProvider.Connect())
        {
            return await connection.QueryAsync<T>(sql, new { }, commandType: commandType).ConfigureAwait(false);
        }
    }

    /*
     | ExecScalar<T> - return T
     */
    public async Task<T> ExecScalar<T, U>(string sql,
                                          U parameters,
                                          CommandType commandType = CommandType.Text)
    {
        using (var connection = _dapperProvider.Connect())
        {
            T result = await connection.ExecuteScalarAsync<T>(sql,
                                                              parameters,
                                                              commandType: commandType).ConfigureAwait(false);
            return (T)result;
        }
    }

    /*
B     | ExecScalar<T> - return T
     */
    public async Task<T> ExecScalar<T>(string sql,
                                       CommandType commandType = CommandType.Text)
    {
        using (var connection = _dapperProvider.Connect())
        {
            T result = await connection.ExecuteScalarAsync<T>(sql,
                                                              new {},
                                                              commandType: commandType).ConfigureAwait(false);
            return (T)result;
        }
    }
}    
