<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Selection_Change(sender As Object, e As EventArgs)

         ' Set the cell padding and cell spacing for the Calendar control
         ' based on the values selected from the DropDownList control.
         Calendar1.CellPadding = CellPaddingList.SelectedIndex
         Calendar1.CellSpacing = CellSpacingList.SelectedIndex

      End Sub
  
   </script>
  
<head runat="server">
    <title> Calendar CellPadding and CellSpacing Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar CellPadding and CellSpacing Example </h3>

      Select the cell padding and cell spacing values.

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
           runat="server"/>

      <br /><br />

      <table cellpadding="5">

         <tr>

            <td>

               Cell padding:

            </td>

            <td>

               Cell spacing:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="CellPaddingList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem> 0 </asp:ListItem>
                  <asp:ListItem> 1 </asp:ListItem>
                  <asp:ListItem Selected="True"> 2 </asp:ListItem>
                  <asp:ListItem> 3 </asp:ListItem>
                  <asp:ListItem> 4 </asp:ListItem>
                  <asp:ListItem> 5 </asp:ListItem>

               </asp:DropDownList>

            </td>

            <td>

               <asp:DropDownList id="CellSpacingList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem Selected="True"> 0 </asp:ListItem>
                  <asp:ListItem> 1 </asp:ListItem>
                  <asp:ListItem> 2 </asp:ListItem>
                  <asp:ListItem> 3 </asp:ListItem>
                  <asp:ListItem> 4 </asp:ListItem>
                  <asp:ListItem> 5 </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>
  
      </table>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
