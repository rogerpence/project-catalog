using System;

namespace DapperCrud.Models;

public partial class Catalog
{
    /*
     | Model type: table
     */
    public int id { get; set; } 
    public string? ShortName { get; set; } 
    public string? Description { get; set; } 
    public string? Location { get; set; } 
    public bool? Favorite { get; set; } 
    public string? Tags { get; set; } 
    public string? Url { get; set; } 
    public int FavoriteRank { get; set; }
    public System.DateTime? Dateadded { get; set; } = null;
    public System.DateTime? Dateupdated { get; set; } = null;
}
