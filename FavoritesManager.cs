using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperCrud.Models;

namespace ProjectDiary;

public class FavoritesManager
{
    ToolStripMenuItem menuItemFavorites;

    Form1 formParent;

    public FavoritesManager(Form1 formParent)
    {
        this.menuItemFavorites = formParent.menuItemFavorites;
        this.formParent = formParent;
    }

    //public List<String> ItemList;

    private int getIndexOfFavorite(string text)
    {
        int index = 0;
        foreach (ToolStripItem m in menuItemFavorites.DropDownItems)
        {
            if (m is ToolStripSeparator) return index;

            if (m is ToolStripMenuItem)
            {
                if (m.Text == text || (m.Tag != null && m.Tag.ToString() == text)) return index;
            }
            index++;
        }

        return -1;
    }

    public List<Catalog> sortFavorites(List<Catalog> favorites)
    {
        return favorites.OrderBy(o => o.FavoriteRank).ToList();
    }

    public void AddFavoritesToMenu(List<Catalog> catalogList)
    {
        menuItemFavorites.Visible = false;

        List<Catalog> favorites = new();

        foreach (var catalog in catalogList)
        {
            if ((bool)catalog.Favorite)
            {
                favorites.Add(catalog);
            }
        }

        if (catalogList.Count == 0) return;
        menuItemFavorites.Visible = true;

        favorites = sortFavorites(favorites);
        foreach (var favorite in favorites)
        {
            AddFavoriteToMenu(favorite.ShortName, favorite.Location);
        }
    }

    public void DeleteFavoriteFromMenu(string text)
    {
        int index = getIndexOfFavorite(text);

        ToolStripMenuItem mi = (ToolStripMenuItem)menuItemFavorites.DropDownItems[index];

        mi.Click -= formParent.OnFavoriteClicked;
        menuItemFavorites.DropDownItems.RemoveAt(index);
    }

    public void AddFavoriteToMenu(string text, string location)
    {
        // Assumes Favorites starts out with a separator and a "Manage favorites" item.
        ToolStripMenuItem fileItem = new ToolStripMenuItem(text);
        fileItem.Tag = location;

        fileItem.Click += formParent.OnFavoriteClicked;
        //fileItem.Checked = true;

        int index = getIndexOfFavorite("END-OF-FAVORITES");
        menuItemFavorites.DropDownItems.Insert(index, fileItem);
    }

    public Dictionary<string, string> GetItemsDictionary()
    {
        Dictionary<string, string> itemsDict = new Dictionary<string, string>();

        foreach (ToolStripItem m in menuItemFavorites.DropDownItems)
        {
            if (m is ToolStripSeparator) return itemsDict;

            if (m is ToolStripMenuItem)
            {
                if (m.Tag != null && m.Tag.ToString() == "END-OF-FAVORITES")
                {
                }
                else
                {
                    itemsDict.Add(m.Text, m.Tag.ToString());
                }
            }
        }

        return itemsDict;
    }

    public List<string> GetItemsText()
    {
        List<string> itemList = new List<string>();

        foreach (ToolStripItem m in menuItemFavorites.DropDownItems)
        {
            if (m is ToolStripSeparator) return itemList;
            if (m is ToolStripMenuItem)
            {
                if (m.Tag != null && m.Tag.ToString() == "END-OF-FAVORITES")
                {
                    return itemList;
                }
                else
                {
                    itemList.Add(m.Text);
                }
            }
        }

        return itemList;
    }

    /*
    private void reorderFavorites()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            int index = getIndexOfFavorite(ItemList[i]);
        }
    }
    */
}



