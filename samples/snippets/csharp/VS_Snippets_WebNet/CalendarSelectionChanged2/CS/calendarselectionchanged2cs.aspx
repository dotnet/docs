<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendar SelectionChanged Example</title>
<script runat="server">

      void Selection_Change(Object sender, EventArgs e) 
      {
 
         // Clear the current text.
         Message.Text = "";

         // Iterate through the SelectedDates collection and display the
         // dates selected in the Calendar control.
         foreach(DateTime day in Calendar1.SelectedDates)
         {

            Message.Text += day.Date.ToShortDateString() + "<br />";

         }
         
      }

      void Page_Load(Object sender, EventArgs e)
      {

         // Manually register the event-handling method for the  
         // SelectionChanged event of the Calendar control.
         Calendar1.SelectionChanged += new EventHandler(this.Selection_Change);

      }


   </script>

</head>     
<body>

   <form id="form1" runat="server">

      <h3>Calendar SelectionChanged Example</h3>

      Select a day, week, or month on the Calendar control.<br /><br />

      <asp:Calendar ID="Calendar1" runat="server"  
           SelectionMode="DayWeekMonth" 
           ShowGridLines="True">

         <SelectedDayStyle BackColor="Yellow"
                           ForeColor="Red">
         </SelectedDayStyle>

      </asp:Calendar>

      <hr />

      <table border="1">

         <tr style="background-color:silver">

            <th>

               Selected dates

            </th>
         </tr>

         <tr>

            <td>
           
               <asp:Label id="Message" 
                    Text="No dates selected." 
                    runat="server"/>

            </td>

         </tr>

      </table>

   </form>

</body>

</html>
   
<!--</Snippet1>-->
