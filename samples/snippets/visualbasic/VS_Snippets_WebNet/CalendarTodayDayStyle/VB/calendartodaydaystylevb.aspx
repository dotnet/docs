<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the background color for today's date in the Calendar.
         Calendar1.TodayDayStyle.BackColor = _
            System.Drawing.Color.FromName(ColorList.SelectedItem.Value)

      End Sub
  
   </script>
  
<head runat="server">
    <title> Calendar TodayDayStyle Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar TodayDayStyle Example </h3>

      Select a background color for today's date in the calendar.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <table cellpadding="5">

         <tr>

            <td>

               Background color:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="ColorList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
                  <asp:ListItem Value="Silver"> Silver </asp:ListItem>
                  <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
                  <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
                  <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>
  
    </table>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
