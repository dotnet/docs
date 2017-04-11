using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MovieLibrary
/// </summary>

// <Snippet1>
public class MovieLibrary
{
    string[] _availableGenres = { "Comedy", "Drama", "Romance" };

    public MovieLibrary()
    {
    }

    public string[] AvailableGenres
    {
        get
        {
            return _availableGenres;
        }
    }
}
// </Snippet1>
