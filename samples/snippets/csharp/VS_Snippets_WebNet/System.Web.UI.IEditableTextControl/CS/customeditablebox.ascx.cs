using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//<Snippet1>

public partial class customeditablebox : System.Web.UI.UserControl, IEditableTextControl
{
    private static readonly object EventCustomTextChanged = new Object();

    public event EventHandler TextChanged
    {
        add
        {
            Events.AddHandler(EventCustomTextChanged, value);
        }
        remove
        {
            Events.RemoveHandler(EventCustomTextChanged, value);
        }
    }

    public string Text
    {
        get
        {
            // Provide implementation.
            return String.Empty;
        }
        set
        {
            // Provide implementation.
        }
    }
}
//</Snippet1>