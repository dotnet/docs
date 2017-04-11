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

// <snippet1>
// Create a code-behind user control that is cached
// for 20 seconds and uses the VaryByCustom property
// to vary the cached control according to the type of browser
// that makes the request for the user control.

// <snippet2>
// Set the PartialCachingAttribute.Duration property to
// 20 seconds and the PartialCachingAttribute.VaryByCustom
// property to browser.
[PartialCaching(20, null, null, "browser")]
public partial class ctlSelect : UserControl
// </snippet2>
{
   
    protected void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TimeMsg.Text = DateTime.Now.ToString("T");
        }
    }

    protected void SubmitBtn_Click(Object Sender, EventArgs e)
    {
        Label1.Text = "You chose: " + state.SelectedItem.Text + " and " + country.SelectedItem.Text + ".";
        TimeMsg.Text = DateTime.Now.ToString("T");
    }
}
// </snippet1>
