// <snippet2>
using System;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Samples.AspNet.CS.Controls
{
  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class CalendarWebPart : WebPart
  {
    Calendar _calendar;

    public CalendarWebPart()
    {
      this.AllowClose = false;
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();
      _calendar = new Calendar();
      _calendar.Caption = "My Calendar";
      this.Controls.Add(_calendar);
      ChildControlsCreated = true;
    }
  }

  [AspNetHostingPermission(SecurityAction.Demand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  [AspNetHostingPermission(SecurityAction.InheritanceDemand,
    Level = AspNetHostingPermissionLevel.Minimal)]
  public class LinksWebPart : WebPart
  {
    Literal _literal;
    const string _literalText = @"
      <table>
      <tr>
        <td><a href='http://msdn.microsoft.com'>MSDN</a></td>
      </tr>
      <tr>
        <td><a href='http://msn.microsoft.com'>MSN</a></td>
      </tr>
      <tr>
        <td><a href='http://www.msnbc.msn.com'>MSNBC</a></td>
      </tr>
      </table>";

    public LinksWebPart()
    {
      this.AllowClose = false;
    }

    protected override void CreateChildControls()
    {
      Controls.Clear();

      _literal = new Literal();
      _literal.Text = _literalText;
      this.Controls.Add(_literal);

      ChildControlsCreated = true;
    }
  }
}
// </snippet2>
