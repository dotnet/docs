<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> Calendar VisibleMonthChanged Example </title>
<script runat="server">

      Sub MonthChange(sender As Object, e As MonthChangedEventArgs) 

         If e.NewDate.Month > e.PreviousDate.Month Then
         
            Message.Text = "You moved forward one month."
         
         Else
         
            Message.Text = "You moved backwards one month."
       
         End If

      End Sub
         
   </script>
 
</head>
 
<body>
 
   <form id="form1" runat="server">

      <h3> Calendar VisibleMonthChanged Example </h3>
       
      Select a different month on the calendar. 
      <br /><br />
 
      <asp:Calendar id="Calendar1" runat="server"
           OnVisibleMonthChanged="MonthChange">

         <WeekendDayStyle BackColor="gray">
         </WeekendDayStyle>

      </asp:Calendar>

      <hr /> 

      <table border="1">

         <tr style="background-color:Silver">

            <th>

               Month navigation direction

            </th>
         </tr>

         <tr>

            <td>
           
               <asp:Label id="Message" 
                    Text="Starting Month." 
                    runat="server"/>

            </td>

         </tr>

      </table>
                   
   </form>
         
</body>

</html>
   
<!--</Snippet1>-->
