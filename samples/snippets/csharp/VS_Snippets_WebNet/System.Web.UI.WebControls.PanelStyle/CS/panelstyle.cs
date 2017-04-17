using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// <snippet2>
public partial class PanelStylecs_aspx : Page
{
    void Page_Load(object sender, EventArgs e)
    {
        StateBag panelState = new StateBag();
        PanelStyle myPanelStyle = new PanelStyle(panelState);
        
        // Set the properties of the PanelStyle class.
        myPanelStyle.HorizontalAlign = HorizontalAlign.Center;
        myPanelStyle.ScrollBars = ScrollBars.Both;
        myPanelStyle.Wrap = false;
        myPanelStyle.Direction = ContentDirection.LeftToRight;
        myPanelStyle.BackImageUrl = @"~\images\picture.jpg";

        // Use the ApplyStyle method of the Panel control to apply
        // the settings from the myPanelStyle object.
        Panel1.ApplyStyle(myPanelStyle);
        Panel2.ApplyStyle(myPanelStyle); 
    }
}
// </snippet2>
