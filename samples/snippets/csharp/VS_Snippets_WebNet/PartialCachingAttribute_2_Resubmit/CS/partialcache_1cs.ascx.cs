// <snippet1>
// Create a code-behind user control that is cached
// for 20 seconds and uses the VaryByControls property
// to vary the cached control according to the value of the 
// specified control.
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

namespace Samples.AspNet.CS.Controls {
// <snippet2>
 // Set the PartialCachingAttribute.Duration property to
 // 20 seconds and the PartialCachingAttribute.VaryByControls
 // property to the ID of the server control to vary the output by.
 // In this case, it is state, the ID assigned to a DropDownList
 // server control.
 [PartialCaching(20, null, "state", null)]
// </snippet2>
    public partial class ctlSelect : UserControl
  {

    protected void Page_Load(Object sender, EventArgs e)
    {
      if(!IsPostBack)
      {
        Label1.Text="The control was generated at:" + DateTime.Now.ToString("T"); 
      }
    }

    protected void SubmitBtn_Click(Object Sender, EventArgs e)
    {
      Label1.Text="You chose: " + state.SelectedItem.Text + " and " + country.SelectedItem.Text + ".";
      TimeMsg.Text = DateTime.Now.ToString("T");
    }
  }
}
// </snippet1>