// <snippet1>
/* File Name: constructorneedstagatt.cs. */

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace MyUserControl 
{
  // Attach the 'ConstructorNeedsTagAttribute' to 'Simple' class. 
  [ConstructorNeedsTagAttribute(true)]
  public class Simple : WebControl 
  {
    private String NameTag = "";

    public Simple(String tag)
    {
      this.NameTag = tag;
    } 
 
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    protected override void Render(HtmlTextWriter output) 
    {
      output.Write("<br>The TagName used for the 'Simple' control is "+"'"+NameTag+"'");
    }
  }  
}
// </snippet1>