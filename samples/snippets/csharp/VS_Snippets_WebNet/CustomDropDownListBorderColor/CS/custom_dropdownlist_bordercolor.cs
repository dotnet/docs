// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomDropDownListBorderColor : System.Web.UI.WebControls.DropDownList
    {
    [System.ComponentModel.Browsable(false)]
    public override System.Drawing.Color BorderColor
    {
      // NOTE: The BorderColor property is inherited from the WebControl 
      // class and is not applicable to the DropDownList control. 
      get
      {
        return base.BorderColor;
      }
      set
      {
        base.BorderColor = value;
      }
    }

    public override System.Web.UI.WebControls.BorderStyle BorderStyle
    {
      // NOTE: The BorderStyle property is inherited from the WebControl 
      // class and is not applicable to the DropDownList control. 
      get
      {
        return base.BorderStyle;
      }
      set
      {
        base.BorderStyle = value;
      }
    }

    public override System.Web.UI.WebControls.Unit BorderWidth
    {
      // NOTE: The BorderWidth property is inherited from the WebControl 
      // class and is not applicable to the DropDownList control. 
      get
      {
        return base.BorderWidth;
      }
      set
      {
        base.BorderWidth = value;
      }
    }

    public override string ToolTip
    {
      // NOTE: The ToolTip property is inherited from the WebControl 
      // class and is not applicable to the DropDownList control. 
      get
      {
        return base.ToolTip;
      }
      set
      {
        base.ToolTip = value;
      }
    }
  }
}
// </Snippet2>
