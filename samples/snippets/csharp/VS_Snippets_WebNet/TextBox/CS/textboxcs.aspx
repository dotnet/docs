<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> TextBox Example </title>
<script runat="server">

      protected void AddButton_Click(Object sender, EventArgs e)
      {
         int Answer;

         Answer = Convert.ToInt32(Value1.Text) + Convert.ToInt32(Value2.Text);

         AnswerMessage.Text = Answer.ToString();

      }

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> TextBox Example </h3>

      <table>

         <tr>

            <td colspan="5">

               Enter integer values into the text boxes. <br />
               Click the Add button to add the two values. <br />
               Click the Reset button to reset the text boxes.

            </td>

         </tr>

         <tr>

            <td colspan="5">

               &nbsp;

            </td>

         </tr>

         <tr align="center">

            <td>

               <asp:TextBox ID="Value1"
                    Columns="2"
                    MaxLength="3"
                    Text="1"
                    runat="server"/>

            </td>

            <td>

               + 

            </td>

            <td>

               <asp:TextBox ID="Value2"
                    Columns="2"
                    MaxLength="3"
                    Text="1"
                    runat="server"/>

            </td>

            <td>

               =

            </td>

            <td>
               
               <asp:Label ID="AnswerMessage"
                    runat="server"/>

            </td>

         </tr>

         <tr>

            <td colspan="2">

               <asp:RequiredFieldValidator
                    ID="Value1RequiredValidator"
                    ControlToValidate="Value1"
                    ErrorMessage="Please enter a value.<br />"
                    Display="Dynamic"
                    runat="server"/>

               <asp:RangeValidator
                    ID="Value1RangeValidator"
                    ControlToValidate="Value1"
                    Type="Integer"
                    MinimumValue="1"
                    MaximumValue="100"
                    ErrorMessage="Please enter an integer <br /> between than 1 and 100.<br />"
                    Display="Dynamic"
                    runat="server"/>

            </td>

            <td colspan="2">

               <asp:RequiredFieldValidator
                    ID="Value2RequiredValidator"
                    ControlToValidate="Value2"
                    ErrorMessage="Please enter a value.<br />"
                    Display="Dynamic"
                    runat="server"/>

               <asp:RangeValidator
                    ID="Value2RangeValidator"
                    ControlToValidate="Value2"
                    Type="Integer"
                    MinimumValue="1"
                    MaximumValue="100"
                    ErrorMessage="Please enter an integer <br /> between than 1 and 100.<br />"
                    Display="Dynamic"
                    runat="server"/>

            </td>

            <td>

               &nbsp
 
            </td>

         </tr>

         <tr align="center">

            <td colspan="4">

               <asp:Button ID="AddButton"
                    Text="Add"
                    OnClick="AddButton_Click"
                    runat="server"/>

            </td>

            <td>

               &nbsp;

            </td>

         </tr>

      </table>

   </form>

</body>
</html>
<!--</Snippet1>-->