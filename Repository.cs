using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using DapperCrud.Models;

namespace DapperWork;

public class Repository : RepositoryBase
{
    private readonly DapperConnectionProvider _dapperProvider;

    public Repository(DapperConnectionProvider dapperProvider) : base(dapperProvider)
    {
        _dapperProvider = dapperProvider;
    }

    public async Task<List<string>> GetUniqueTags()
    {
        // A very SQL Server technique to get all unique values form a field 

        string sql = $"""
        SELECT DISTINCT VALUE AS [Tag] from [Catalog] CROSS APPLY string_split([tags], ' ') ORDER BY [TAG]
        """;

        var results = await this.Query<string>(sql);
        return results.ToList();
    }

    public async Task<List<Catalog>> SearchCatalogRows(string searchString)
    {
        string sql = $"""
        SELECT * FROM [Catalog] WHERE CONTAINS(*, '"{searchString}"') ORDER BY [dateAdded] DESC
        """;

        var results = await this.Query<Catalog>(sql);

        var searchResults = results.ToList();
        foreach (var item in searchResults)
        {
            item.ShortName = item.ShortName + "   " + item.Tags;            
        }
        return searchResults;


        //return results.ToList();
    }

    public async Task<List<Catalog>> SearchForTags(string searchString)
    {
        string sql;

        if (searchString.Contains(" "))
        {
            var tags = searchString.Split(" ");

            if (tags[1].StartsWith("#"))
            {
                // Search for two tags.
                sql = $"""
                SELECT * FROM [Catalog] WHERE CONTAINS(tags, '"{tags[0].Trim()}"') AND CONTAINS(tags, '"{tags[1].Trim()}"') ORDER BY [dateAdded] DESC 
                """;
            }
            else
            {
                // Search for one tab and something in the body.
                sql = $"""
                SELECT * FROM [Catalog] WHERE CONTAINS(tags, '"{tags[0].Trim()}"') AND CONTAINS(*, '"{tags[1].Trim()}"') ORDER BY [dateAdded] DESC 
                """;
            }
        }
        else
        {
            sql = $"""
            SELECT * FROM [Catalog] WHERE CONTAINS(tags, '"{searchString}"') ORDER BY [dateAdded] DESC 
            """;
        }

        var results = await this.Query<Catalog>(sql);

        var searchResults = results.ToList();
        foreach (var item in searchResults)
        {
            item.ShortName = item.ShortName + "   " + item.Tags;            
        }
        return searchResults;

//        return results.ToList();
    }

    public async Task<List<Catalog>> GetAllCatalogRowsByDateAdded()
    {
        string sql = $"""
        SELECT * FROM [Catalog] ORDER BY [dateAdded] DESC
        """;

        var results = await this.Query<Catalog>(sql);
        return results.ToList();
    }

public async Task<List<Catalog>> GetAllCatalogRowsByShortName()
    {
        string sql = $"""
        SELECT * FROM [Catalog] ORDER BY [shortName] ASC
        """;

        var results = await this.Query<Catalog>(sql);
        return results.ToList();
    }

    public async Task<Catalog> GetAllCatalogRowByShortName(string shortName)
    {
        string sql = $"""
        SELECT * FROM [Catalog] WHERE [shortName] = @shortName
        """;

        var results = await this.QuerySingle<Catalog, dynamic>(sql, new {shortName = shortName});
        return results;
    }

    public async Task<Catalog> GetCatalogByLocation(string location)
    {
        string sql = $"""
            SELECT * FROM [Catalog] where [location] = @location 
        """;

        return await this.QuerySingle<Catalog, dynamic>(sql, new {location = location });
    }

    public async Task<T> Upsert<T>(T model)
    {
        string className = typeof(T).Name;

        return await this.QuerySingle<T>($"rp_{className}Upsert", model, CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<T> SelectOne<T,U>(U model)
    {
        string className = typeof(T).Name;

        return await this.QuerySingle<T,U>($"rp_{className}SelectOne", model, CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task Delete<T>(T model)
    {
        string className = typeof(T).Name;

        await this.Exec<T>($"rp_{className}Delete", model, CommandType.StoredProcedure).ConfigureAwait(false);
    }

    /*
    public async Task Query<T>(string sql,
                               T parameters,
                               CommandType commandType = CommandType.Text)
    {
        using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);

        await connection.QueryAsync(sql,
                                    parameters,
                                    commandType: commandType).ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> Query<T>(string sql,
                                               CommandType commandType = CommandType.Text)
    { 
        using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(_connectionString);

        return await connection.QueryAsync<T>(sql, new { }, commandType: commandType).ConfigureAwait(false);
    }
    */

}