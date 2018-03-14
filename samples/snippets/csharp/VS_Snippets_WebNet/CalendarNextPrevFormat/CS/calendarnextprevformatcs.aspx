<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the format for the next and previous month controls.
         Calendar1.NextPrevFormat = (NextPrevFormat)DayList.SelectedIndex;

      }
  
   </script>
  
<head runat="server">
    <title> Calendar NextPrevFormat Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar NextPrevFormat Example </h3>

      Select a format for the next and previous month controls.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <table cellpadding="5">

         <tr>

            <td>

               Format:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="DayList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem Selected="True"> Custom </asp:ListItem>
                  <asp:ListItem> ShortMonth </asp:ListItem>
                  <asp:ListItem> FullMonth </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>
  
      </table>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
