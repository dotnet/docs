<%--
   System.Web.UI.IValidator.ErrorMessage
   System.Web.UI.IValidator.IsValid

   The following program demonstrates the 'IsValid' and 'ErrorMessage'
   properties of 'IValidator' interface.

   The property IsValid is used by class 'CompareValidator' (which
   implements interface IValidator) to check if the validity of
   user-entered content in the specified control is true.
   The property ErrorMessage is used to set the error message when
   control statement is not valid.
--%>
<!-- <Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>IValidator Example demonstrating IsValid & ErrorMessage</title>
<script language="VB" runat="server">

         Sub Button_Click(sender As [Object], e As EventArgs)
            ' Generating a random number.
            Dim rand_s As New Random()
            myCompareValidate.ValueToCompare = rand_s.Next(1, 10).ToString()

            ' Set the ErrorMessage.
            myCompareValidate.ErrorMessage = "Try Again!!"
            myCompareValidate.Validate()

            ' Check for Validity of control.
            If myCompareValidate.IsValid And myTextBox.Text <> "" Then
               labelOutput.Text = "You guessed correctly!!"
               labelOutput.ForeColor = System.Drawing.Color.Blue
            Else
               labelOutput.Text = "You guessed poorly"
               labelOutput.ForeColor = System.Drawing.Color.Black
            End If

            labelOutput.Text += "<br /><br />" + "The number is: " + _
               myCompareValidate.ValueToCompare
         End Sub 'Button_Click

  </script>
</head>
    <body>
       <form runat="server" id="myForm">
          <h3>IValidator Example demonstrating IsValid & ErrorMessage</h3>
          <h5>Guess!! a number between 1 and 10:</h5>
          <asp:TextBox id="myTextBox" runat="server" />
          <asp:CompareValidator id="myCompareValidate"
               ControlToValidate="myTextBox" ValueToCompare="0"
               EnableClientScript="False" Type="Integer" Text="*"
               runat="server" />
          <br />
          <asp:Button Text="Submit" OnClick="Button_Click" runat="server" />
          <br />
          <asp:Label id="labelOutput" runat="server" />
          <br />
          <asp:ValidationSummary id="Summary1" runat="server" />
       </form>
    </body>
</html>
<!-- </Snippet1> -->