<!--<Snippet1>-->
<%@ Page Language="VB"%>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
 
    DisplayCalendar.VisibleDate = DisplayCalendar.TodaysDate
    
  End Sub

  Sub SelectButton_Click(ByVal sender As Object, ByVal e As EventArgs)

    Dim current_day As Integer = DisplayCalendar.VisibleDate.Day
    Dim current_month As Integer = DisplayCalendar.VisibleDate.Month
    Dim current_year As Integer = DisplayCalendar.VisibleDate.Year

    DisplayCalendar.SelectedDates.Clear()
   
    ' Iterate through the current month and add all Wednesdays to the 
    ' SelectedDates collection of the Calendar control.
    Dim i As Integer
    For i = 1 To System.DateTime.DaysInMonth(current_year, current_month)
    
      Dim currentDate As New DateTime(current_year, current_month, i)
      If currentDate.DayOfWeek = DayOfWeek.Wednesday Then
       
        DisplayCalendar.SelectedDates.Add(currentDate)
        
      End If
      
    Next

    MessageLabel.Text = "Selection Count = " + DisplayCalendar.SelectedDates.Count.ToString()
 
  End Sub

  Sub DisplayCalendar_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
  
    MessageLabel.Text = "Selection Count = " & DisplayCalendar.SelectedDates.Count.ToString()
  
  End Sub
 
</script> 
 
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
 
      <asp:calendar id="DisplayCalendar" runat="server"  
        selectionmode="DayWeekMonth" 
        onselectionchanged="DisplayCalendar_SelectionChanged" />
 
      <hr />
 
      <asp:button id="SelectButton"
        text="Select All Weds in Month" 
        onclick="SelectButton_Click"  
        runat="server"/> 
        
      <br/>
 
      <asp:label id="MessageLabel" 
        runat="server" />
 
    </form>
  </body>
</html>
   
<!--</Snippet1>-->
