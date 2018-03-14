<!--<Snippet1>-->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub ScheduleCalendar_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs) Handles ScheduleCalendar.DayRender
  
    ' Customize the caption for today's date.
    If e.Day.IsToday Then
    
      ' Create the content to render for today's date. Use the 
      ' SelectUrl property to retrieve the script used to post
      ' the page back to the server when the user selects the
      ' date.
      Dim dayContent As String = "<a href=""" & e.SelectUrl & _
        """><img border=""0"" alt=""Today"" src=""today.jpg""/></a>"
      
      ' Display the custom content in the date cell. 
      e.Cell.Text = dayContent
      
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <asp:calendar id="ScheduleCalendar"
        runat="server"/> 
    
    </form>
  </body>
</html>

<!--</Snippet1>-->
