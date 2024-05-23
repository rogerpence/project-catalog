using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectDiary;

public class LocationObject
{
    public int Id { get; set; } = 0;
    public string ShortName { get; set; } = "";
    public string Description { get; set; } = "";
    public string Location { get; set; } = "";
    public string Hashtags { get; set; } = "";
    public string Url { get; set; } = "";
    public bool Favorite { get; set; } = false;
    public int FavoriteRank { get; set; } = 0;
    public DateTime DateAdded { get; set; }
}

