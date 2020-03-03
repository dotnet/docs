<%@ Page Language="C#" %>
<!--<Snippet1>-->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void ScheduleCalendar_DayRender(object sender, DayRenderEventArgs e)
  {
    // Customize the caption for today's date.
    if(e.Day.IsToday)
    {
      // Create the content to render for today's date. Use the 
      // SelectUrl property to retrieve the script used to post
      // the page back to the server when the user selects the
      // date.
      string dayContent = "<a href=\"" + e.SelectUrl +
        "\"><img border=\"0\" alt=\"Today\" src=\"today.jpg\"/></a>";
      
      // Display the custom content in the date cell. 
      e.Cell.Text = dayContent;
    }
    
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <asp:calendar id="ScheduleCalendar"
        ondayrender="ScheduleCalendar_DayRender" 
        runat="server"/> 
    
    </form>
  </body>
</html>
<!--</Snippet1>-->
