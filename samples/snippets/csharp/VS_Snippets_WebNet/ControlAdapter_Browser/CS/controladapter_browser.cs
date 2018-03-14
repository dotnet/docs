// <snippet1>
using System;
using System.Web.UI;
using System.Web.UI.Adapters;

public class CustomControlAdapter : ControlAdapter
{
    protected override void Render( HtmlTextWriter writer )
    {
        // Access Browser details through the Browser property.
        Version jScriptVersion = Browser.JScriptVersion;

        // Test if the browser supports Javascript.
        if (jScriptVersion != null)
        {
            // Render JavaScript-aware markup.
        }
        else
        {
            // Render scriptless markup.
        }
    }
}
// </snippet1>

public class MainClass
{
    public static void Main()
    {
    }
}
