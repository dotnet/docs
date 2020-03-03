<!--<Snippet1>-->
<%@ Page Language="C#"%>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  void Page_Load(Object sender, EventArgs e) 
  {
    DisplayCalendar.VisibleDate = DisplayCalendar.TodaysDate;
  }

  void SelectButton_Click(Object sender, EventArgs e) 
  {

    int current_day = DisplayCalendar.VisibleDate.Day;
    int current_month = DisplayCalendar.VisibleDate.Month;
    int current_year = DisplayCalendar.VisibleDate.Year;

    DisplayCalendar.SelectedDates.Clear();
   
    // Iterate through the current month and add all Wednesdays to the 
    // SelectedDates collection of the Calendar control.
    for (int i = 1; i <= System.DateTime.DaysInMonth(current_year, current_month); i++)
    {
       DateTime currentDate = new DateTime(current_year, current_month, i);
       if (currentDate.DayOfWeek == DayOfWeek.Wednesday)
       {
         DisplayCalendar.SelectedDates.Add(currentDate);
       }
    }

     MessageLabel.Text = "Selection Count = " + DisplayCalendar.SelectedDates.Count.ToString();
 
  }

  void DisplayCalendar_SelectionChanged(Object sender, EventArgs e) 
  {
    MessageLabel.Text = "Selection Count = " + DisplayCalendar.SelectedDates.Count.ToString();
  }
 
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
