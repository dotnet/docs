<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Calendar Example</title>
<script language="C#" runat="server">

      void Selection_Change(Object sender, EventArgs e) 
      {
         Calendar1.TodaysDate = Calendar1.SelectedDate;
         Label1.Text = "Today's Date is now " + Calendar1.TodaysDate.ToShortDateString();
      }

   </script>

</head>     
<body>

   <form id="form1" runat="server">

      <h3>Calendar Example</h3>

      Select a date on the Calendar control to use as today's date.<br /><br />

      <asp:Calendar ID="Calendar1" runat="server"  
           SelectionMode="Day" 
           ShowGridLines="True" 
           OnSelectionChanged="Selection_Change">

         <SelectedDayStyle BackColor="Yellow"
                           ForeColor="Red">
         </SelectedDayStyle>

      </asp:Calendar> 

      <hr /><br />

      <asp:Label id="Label1" runat="server" />

   </form>
</body>
</html>

<!--</Snippet1>-->
