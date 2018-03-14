<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> CheckBoxList RepeatColumns Example </title>
<script runat="server">

      void Check_Clicked(Object sender, EventArgs e) 
      {

         Message.Text = "Selected Item(s):<br /><br />";

         // Iterate through the Items collection of the CheckBoxList 
         // control and display the selected items.
         for (int i=0; i<checkboxlist1.Items.Count; i++)
         {

            if (checkboxlist1.Items[i].Selected)
            {

               Message.Text += checkboxlist1.Items[i].Text + "<br />";

            }

         }

      }

      void Index_Change(Object sender, EventArgs e) 
      {

         // Set the number columns in the CheckBoxList control.
         checkboxlist1.RepeatColumns = List.SelectedIndex;

      }

   </script>
 
</head>

<body>
   
   <form id="form1" runat="server">
 
      <h3> CheckBoxList RepeatColumns Example </h3>

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

      Select the number of columns to display.

      <table cellpadding="5">

         <tr>

            <td>

               RepeatColumns:

            </td>

         </tr>

         <tr>

            <td>

               <asp:DropDownList id="List"
                    AutoPostBack="True"
                    OnSelectedIndexChanged="Index_Change"
                    runat="server">

                  <asp:ListItem>0</asp:ListItem>
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem Selected="True">2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>

               </asp:DropDownList>

            </td>

         </tr>

      </table>
             
   </form>
          
</body>

</html>

<!-- </Snippet1> -->