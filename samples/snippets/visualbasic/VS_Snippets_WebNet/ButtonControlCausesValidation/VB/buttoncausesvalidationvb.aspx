<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head runat="server">
    <title> Button CausesValidation Example </title>
<script runat="server">

      Sub SubmitButton_Click(sender As Object, e As EventArgs)
         
         ' Determine which button was clicked.
         Select Case (CType(sender, Button)).ID

            Case "CityQueryButton"

               ' Validate only the controls used for the city query.
               CityReqValidator.Validate()

               ' Take the appropriate action if the controls pass validation. 
               If CityReqValidator.IsValid Then
           
                  Message.Text = "You have chosen to run a query for the following city: " & _ 
                     CityTextBox.Text
               
               End If

            Case "StateQueryButton"

               ' Validate only the controls used for the state query.
               StateReqValidator.Validate()

               ' Take the appropriate action if the controls pass validation.
               If StateReqValidator.IsValid Then
               
                  Message.Text = "You have chosen to run a query for the following state: " & _ 
                     StateTextBox.Text
               
               End If

            Case Else

               ' If the button clicked isn't recognized, erase the message on the page.
               Message.Text = ""

         End Select
        
      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> Button CausesValidation Example </h3>

      <table border="1" cellpadding="10">
         <tr>
            <td>
               <b>Enter city to query.</b> <br />
               <asp:TextBox ID="CityTextBox" 
                    runat="server"/>
               <asp:RequiredFieldValidator ID="CityReqValidator"
                    ControlToValidate="CityTextBox"
                    ErrorMessage="<br />Please enter a city."
                    Display="Dynamic"
                    EnableClientScript="False"
                    runat="server"/>
            </td>
            <td valign="bottom">
               <asp:Button ID="CityQueryButton"
                    Text="Submit"
                    CausesValidation="False"
                    OnClick="SubmitButton_Click"
                    runat="server"/>
            </td>
         </tr>

         <tr>
            <td>
               <b>Enter state to query.</b> <br />
               <asp:TextBox ID="StateTextBox"  
                    runat="server"/>
               <asp:RequiredFieldValidator ID="StateReqValidator"
                    ControlToValidate="StateTextBox"
                    ErrorMessage="<br />Please enter a state."
                    Display="Dynamic"
                    EnableClientScript="False"
                    runat="server"/>
            </td>
            <td valign="bottom">
               <asp:Button ID="StateQueryButton"
                    Text="Submit"
                    CausesValidation="False"
                    OnClick="SubmitButton_Click"
                    runat="server"/>
            </td>
         </tr>

      </table>

      <br /><br />

      <asp:Label ID="Message"
           runat="Server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->