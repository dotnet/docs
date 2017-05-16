<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server" >
  
      Sub Selection_Change(sender As Object, e As EventArgs)
      
         ' Set the title format based on the value selected from the
         ' DropDownList control. The SelectedIndex property can be used
         ' to determine an enumeration value. Simply cast the value to 
         ' the appropriate enumeration type. Note that the value might
         ' need to be adjusted if the enumeration type is not zero-based.
         Calendar1.TitleFormat = CType(ModeList.SelectedIndex, TitleFormat)

      End Sub
  
   </script>
  
<head runat="server">
    <title> DropDownList SelectedIndex Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> DropDownList SelectedIndex Example </h3>

      Choose the title format.

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

               <asp:DropDownList id="ModeList"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Selection_Change"
                    runat="server">

                  <asp:ListItem> Month </asp:ListItem>
                  <asp:ListItem Selected="True"> MonthYear </asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>
         
      </table>   
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
