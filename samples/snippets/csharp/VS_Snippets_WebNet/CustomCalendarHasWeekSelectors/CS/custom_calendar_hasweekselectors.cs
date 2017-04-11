// <Snippet2>
using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomCalendarHasWeekSelectors : System.Web.UI.WebControls.Calendar
    {
    protected override void OnPreRender(System.EventArgs e)
    {
      // Determine if a CalendarSelectionMode.DayWeek contains WeekSelectors.
      bool hasWeekSelectors = this.HasWeekSelectors(System.Web.UI.WebControls.CalendarSelectionMode.DayWeek);

      // Call the base's OnPreRender method.
      base.OnPreRender(e);
    }
  }
}
// </Snippet2>