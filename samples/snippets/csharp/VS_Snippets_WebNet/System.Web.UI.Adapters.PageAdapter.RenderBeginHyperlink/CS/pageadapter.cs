// <snippet1>
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.Adapters;

// A derived PageAdapter class.
public class CustomPageAdapter : PageAdapter
{
    // Override RenderBeginHyperlink to add an attribute that 
    // references the referring page.
    public override void RenderBeginHyperlink(
        HtmlTextWriter writer, string targetUrl,
        bool encodeUrl, string softkeyLabel, 
        string accessKey )
    {
        string url = null;

        // Add the src attribute, if referring page URL is available.
        if( Page != null && Page.Request != null &&
            Page.Request.Url != null )
        {
            url = Page.Request.Url.AbsoluteUri;
            if( encodeUrl )
                url = HttpUtility.HtmlAttributeEncode( url );
            writer.AddAttribute( "src", url );
        }

        // Add the accessKey attribute, if caller requested.
        if( accessKey != null && accessKey.Length == 1 )
            writer.AddAttribute( "accessKey", accessKey );

        // Add the href attribute, encode the URL if requested.
        if( encodeUrl )
            url = HttpUtility.HtmlAttributeEncode( targetUrl );
        else
            url = targetUrl;
        writer.AddAttribute( "href", url );

        // Render the hyperlink opening tag with the added attributes.
        writer.RenderBeginTag( "a" );
    }
}
// </snippet1>

public class MainClass
{
    public static void Main()
    {
        CustomPageAdapter cpa = new CustomPageAdapter();
        StreamWriter sw = new StreamWriter("cpag.htm");
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        cpa.RenderBeginHyperlink(htw, "http://target.url.com", true, "Click", "X");
        htw.Close();
    }
}
// Use as alternate src for testing:
//      else
//          writer.AddAttribute("src", "abbaDabbaDo" );

