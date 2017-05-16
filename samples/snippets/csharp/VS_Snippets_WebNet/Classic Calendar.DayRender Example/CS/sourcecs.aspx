<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DayRender Event Example</title>
<script language="C#" runat="server">
   
      void DayRender(Object source, DayRenderEventArgs e) 
      {

         // Change the background color of the days in the month
         // to yellow.
         if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
            e.Cell.BackColor=System.Drawing.Color.Yellow;

         // Add custom text to cell in the Calendar control.
         if (e.Day.Date.Day == 18)
            e.Cell.Controls.Add(new LiteralControl("<br />Holiday"));

      }

   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">

      <h3>DayRender Event Example</h3>
 
      <asp:Calendar id="calendar1" 
                    OnDayRender="DayRender"
                    runat="server">

         <WeekendDayStyle BackColor="gray">
         </WeekendDayStyle>

      </asp:Calendar>
                   
   </form>
          
</body>
</html>
   
<!--</Snippet1>-->
