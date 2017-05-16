<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>ASP.NET Example</title>
<script language="C#" runat="server">

      void DayRender(Object source, DayRenderEventArgs e) 
      {
      
         if (!e.Day.IsOtherMonth && !e.Day.IsWeekend)
            e.Cell.BackColor=System.Drawing.Color.Yellow;
      
      }

   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">
 
      <asp:Calendar id="calendar1" runat="server"
           WeekendDayStyle-BackColor="gray"
           OnDayRender="DayRender"/>
                   
   </form>
         
</body>
</html>
   
<!--</Snippet1>-->
