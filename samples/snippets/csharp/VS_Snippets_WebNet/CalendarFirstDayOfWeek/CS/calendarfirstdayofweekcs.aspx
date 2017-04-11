<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the first day of the week.
         Calendar1.FirstDayOfWeek = (FirstDayOfWeek)DayList.SelectedIndex;

      }
  
   </script>
  
<head runat="server">
    <title> Calendar FirstDayOfWeek Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar FirstDayOfWeek Example </h3>

      Select the first day of the week.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <table cellpadding="5">

         <tr>

            <td>

               First day of the week:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="DayList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem> Sunday </asp:ListItem>
                  <asp:ListItem> Monday </asp:ListItem>
                  <asp:ListItem> Tuesday </asp:ListItem>
                  <asp:ListItem> Wednesday </asp:ListItem>
                  <asp:ListItem> Thursday </asp:ListItem>
                  <asp:ListItem> Friday </asp:ListItem>
                  <asp:ListItem> Saturday </asp:ListItem>
                  <asp:ListItem Selected="True"> Default </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>
  
      </table>  
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
