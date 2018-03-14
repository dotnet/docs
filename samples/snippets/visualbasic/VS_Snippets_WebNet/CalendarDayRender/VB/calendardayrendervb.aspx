<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendar DayRender Example</title>
<script runat="server">
   
      Sub DayRender(sender as Object, e As DayRenderEventArgs) 

         ' Change the background color of the days in the month
         ' to yellow.
         If (Not e.Day.IsOtherMonth) And (Not e.Day.IsWeekend) Then
        
            e.Cell.BackColor=System.Drawing.Color.Yellow
         
         End If

         ' Add custom text to cell in the Calendar control.
         If e.Day.Date.Day = 18 Then
         
            e.Cell.Controls.Add(New LiteralControl("<br />Holiday"))
         
         End If

      End Sub

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Manually register the event-handling method for the DayRender  
         ' event of the Calendar control.
         AddHandler Calendar1.DayRender, AddressOf DayRender

      End Sub

   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">

      <h3>Calendar DayRender Example</h3>
 
      <asp:Calendar id="Calendar1" 
                    runat="server">

         <WeekendDayStyle BackColor="gray">
         </WeekendDayStyle>

      </asp:Calendar>
                   
   </form>
          
</body>
</html>
   
<!--</Snippet1>-->
