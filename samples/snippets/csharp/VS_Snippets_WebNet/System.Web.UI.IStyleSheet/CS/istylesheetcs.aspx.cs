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

// <snippet2>
public partial class istylesheetcs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create a Style object to hold style rules to apply to a Label control.
        Style labelStyle = new Style();

        labelStyle.ForeColor = System.Drawing.Color.DarkRed;
        labelStyle.BorderColor = System.Drawing.Color.DarkBlue;
        labelStyle.BorderWidth = 2;

        // Register the Style object so that it can be merged with 
        // the Style object of the controls that use it.
        Page.Header.StyleSheet.RegisterStyle(labelStyle, null);

        // Merge the labelCssStyle style with the label1 control's
        // style settings.
        label1.MergeStyle(labelStyle);
        label1.Text = "This is what the labelCssStyle looks like.";


        // Create a Style object for the <BODY> section of the Web page.
        Style bodyStyle = new Style();

        bodyStyle.ForeColor = System.Drawing.Color.Blue;
        bodyStyle.BackColor = System.Drawing.Color.LightGray;

        // Add the style to the header of the current page.
        Page.Header.StyleSheet.CreateStyleRule(bodyStyle, null, "BODY");

        // Add text to the label2 control to see the label without 
        // the labelStyle applied to it.  
        label2.Text = "This is what the bodyStyle looks like.";
    }
}
// </snippet2>