<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> CheckBoxList RepeatLayout Example </title>
<script runat="server">

      Sub Check_Clicked(sender as Object, e As EventArgs) 

         Message.Text = "Selected Item(s):<br /><br />"

         ' Iterate through the Items collection of the CheckBoxList
         ' control and display the selected items.
         Dim i As Integer

         For i=0 To checkboxlist1.Items.Count - 1

            If checkboxlist1.Items(i).Selected Then

               Message.Text &= checkboxlist1.Items(i).Text & "<br />"

            End If

         Next

      End Sub

      Sub Index_Change(sender as Object, e As EventArgs) 

         ' Set the layout (table or flow) of the CheckBoxList control.
         checkboxlist1.RepeatLayout = CType(List.SelectedIndex, RepeatLayout)

      End Sub

   </script>
 
</head>

<body>
   
   <form id="form1" runat="server">
 
      <h3> CheckBoxList RepeatLayout Example </h3>

      Select items from the CheckBoxList.

      <br /><br />

      <asp:CheckBoxList id="checkboxlist1" 
           AutoPostBack="True"
           CellPadding="5"
           CellSpacing="5"
           RepeatColumns="2"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           TextAlign="Right"
           OnSelectedIndexChanged="Check_Clicked"
           runat="server">
 
         <asp:ListItem>Item 1</asp:ListItem>
         <asp:ListItem>Item 2</asp:ListItem>
         <asp:ListItem>Item 3</asp:ListItem>
         <asp:ListItem>Item 4</asp:ListItem>
         <asp:ListItem>Item 5</asp:ListItem>
         <asp:ListItem>Item 6</asp:ListItem>
 
      </asp:CheckBoxList>
 
      <br /><br />

      <asp:label id="Message" runat="server"/>

      <hr />

      Select whether to display the CheckBoxList control in 
      table or flow layout.

      <table cellpadding="5">

         <tr>

            <td>

               RepeatLayout:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="List"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Index_Change"
                    runat="server">

                  <asp:ListItem Selected="True">Table</asp:ListItem>
                  <asp:ListItem>Flow</asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>

      </table>
             
   </form>
          
</body>

</html>

<!-- </Snippet1> -->