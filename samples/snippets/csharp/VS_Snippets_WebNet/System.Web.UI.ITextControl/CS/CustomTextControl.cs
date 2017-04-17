using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//<Snippet1>

public class CustomTextControl : Control, ITextControl
{
    private string _text;

	public CustomTextControl()
	{
	}

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            if (value != null)
            {
                _text = value;
            }
            else
            {
                _text = "No Value.";
            }
        }
    }

    // Provide the remaining code to implement a text control.
}
//</Snippet1>
