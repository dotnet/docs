Imports System.Web
Imports System.Security.Permissions

Namespace Samples.AspNet.VB.Controls
    ' <Snippet2>

    <AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public NotInheritable Class CustomCalendarHasWeekSelectors
        Inherits System.Web.UI.WebControls.Calendar

        Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
            ' Determine if a CalendarSelectionMode.DayWeek contains WeekSelectors.
            Dim hasWeekSelectors As Boolean = Me.HasWeekSelectors(System.Web.UI.WebControls.CalendarSelectionMode.DayWeek)

            ' Call the base OnPreRender method.
            MyBase.OnPreRender(e)
        End Sub
    End Class
    ' </Snippet2>
End Namespace