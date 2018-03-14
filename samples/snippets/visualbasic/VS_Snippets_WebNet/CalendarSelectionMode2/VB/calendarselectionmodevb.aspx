<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the day selection mode.
         Calendar1.SelectionMode = _
            CType(ModeList.SelectedIndex, CalendarSelectionMode)

      End Sub
  
   </script>
  
<head runat="server">
    <title> Calendar SelectionMode Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar SelectionMode Example </h3>

      Choose the date selection mode.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <table cellpadding="5">

         <tr>

            <td>

               Mode:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="ModeList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem> None </asp:ListItem>
                  <asp:ListItem Selected="True"> Day </asp:ListItem>
                  <asp:ListItem> DayWeek </asp:ListItem>
                  <asp:ListItem> DayWeekMonth </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>
  
      </table>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
