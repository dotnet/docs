<%@ Page Language="VB"
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Register TagPrefix="mobile"
    Namespace="System.Web.UI.MobileControls"
    Assembly="System.Web.Mobile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
    "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
       
    Protected Sub Page_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        ' Display the day header
        Calendar1.ShowDayHeader = True

        ' Allow the user to select a week or a month at a time.
        Calendar1.SelectionMode = _
            CalendarSelectionMode.DayWeekMonth

        ' Set the BorderStyle and BorderColor properties.
        Calendar1.WebCalendar.DayStyle.BorderStyle = _
            BorderStyle.Solid
        Calendar1.WebCalendar.DayStyle.BorderColor = Color.Cyan

        Calendar1.CalendarEntryText = "Your birthdate"

        Calendar1.FirstDayOfWeek = _
            System.Web.UI.WebControls.FirstDayOfWeek.Friday
        
        Calendar1.VisibleDate = DateTime.Parse("7/1/2004")

    End Sub

    Protected Sub ShowChanges(ByVal sender As Object, _
        ByVal e As EventArgs)

        TextView1.Text = "The date you selected is " & _
           Calendar1.SelectedDate.ToShortDateString()

        ' Distinguish the selected block using colors.
        Calendar1.WebCalendar.SelectedDayStyle.BackColor = _
            Color.LightGreen
        Calendar1.WebCalendar.SelectedDayStyle.BorderColor = _
            Color.Gray
        Calendar1.WebCalendar.DayStyle.BorderColor = Color.Blue
    End Sub

    Protected Sub Command1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim currentDay As Integer = Calendar1.VisibleDate.Day
        Dim currentMonth As Integer = Calendar1.VisibleDate.Month
        Dim currentYear As Integer = Calendar1.VisibleDate.Year
        Calendar1.SelectedDates.Clear()
        
        ' Loop through current month and add all Wednesdays to the collection.
        Dim i As Integer
        For i = 1 To System.DateTime.DaysInMonth(currentYear, currentMonth)
            Dim targetDate As New DateTime(currentYear, currentMonth, i)
            If targetDate.DayOfWeek = DayOfWeek.Wednesday Then
                Calendar1.SelectedDates.Add(targetDate)
            End If
        Next i
        TextView1.Text = "Selection Count = " & Calendar1.SelectedDates.Count.ToString()
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Calendar id="Calendar1" runat="server"
            OnSelectionChanged="ShowChanges" />
        <mobile:TextView runat="server" id="TextView1" />
        <mobile:Command ID="Command1" OnClick="Command1_Click" Runat="server">Select Weekdays</mobile:Command>
    </mobile:form>
</body>
</html>