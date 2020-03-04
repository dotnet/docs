<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Drawing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendar OtherMonthDayStyle Example</title>
<script runat="server">

      void Index_Changed(Object sender, EventArgs e)
      {

         // Set the foreground color of days not in the current
         // month to the color selected from the DropDownList control.
         Calendar1.OtherMonthDayStyle.ForeColor = 
            Color.FromName(ColorList.SelectedItem.Value);

      }

   </script>

</head>
<body>

   <form id="form1" runat="server">

      <h3>Calendar OtherMonthDayStyle Example</h3>

      <asp:Calendar id="Calendar1" runat="server">

         <OtherMonthDayStyle ForeColor="LightGray">
         </OtherMonthDayStyle>

      </asp:Calendar>

      <br /><br />

      Select a color for the days not in the current month:

      <br />     
 
      <asp:DropDownList id="ColorList"
           AutoPostBack="True"
           OnSelectedIndexChanged="Index_Changed"
           runat="server">

         <asp:ListItem Value="DarkGray">Dark Gray</asp:ListItem>
         <asp:ListItem Value="LightGray" Selected="True">Light Gray</asp:ListItem>
         <asp:ListItem Value="DarkKhaki">Dark Khaki</asp:ListItem>
         <asp:ListItem Value="Khaki">Khaki</asp:ListItem>
         <asp:ListItem Value="White">White</asp:ListItem>

      </asp:DropDownList>      
            
   </form>
        
</body>
</html>

<!--</Snippet1>-->
