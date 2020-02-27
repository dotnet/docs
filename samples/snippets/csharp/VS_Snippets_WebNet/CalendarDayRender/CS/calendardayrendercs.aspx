<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendar DayRender Example</title>
<script runat="server">
   
      void DayRender(Object sender, DayRenderEventArgs e) 
      {

         // Change the background color of the days in the month
         // to yellow.
         if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
         {
            e.Cell.BackColor=System.Drawing.Color.Yellow;
         }

         // Add custom text to cell in the Calendar control.
         if (e.Day.Date.Day == 18)
         {
            e.Cell.Controls.Add(new LiteralControl("<br />Holiday"));
         }

      }

      void Page_Load(Object sender, EventArgs e)
      {

         // Manually register the event-handling method for the DayRender  
         // event of the Calendar control.
         Calendar1.DayRender += new DayRenderEventHandler(this.DayRender);

      }

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
