<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> TextBox Constructor Example </title>
<script runat="server">

      Protected Sub Page_Load(sender As Object, e As EventArgs)

         ' Create UserTextBox TextBox control.
         Dim UserTextBox As New TextBox()

         ' Configure the UserTextBox TextBox control.
         UserTextBox.ID = "UserTextBox"
         UserTextBox.Columns = 50


         ' Add UserTextBox TextBox control to the Controls collection 
         ' of the TextBoxControlPlaceHolder PlaceHolder control.
         TextBoxControlPlaceHolder.Controls.Add(UserTextBox)

      End Sub

      Protected Sub Submit_Click(sender As Object, e As EventArgs)

         ' Retrieve the UserTextBox TextBox control from the TextBoxControlPlaceHolder
         ' PlaceHolder control.
         Dim TempTextBox As TextBox = CType(TextBoxControlPlaceHolder.FindControl("UserTextBox"), TextBox)

         ' Display the Text property.
         Message.Text = "The TextBox control above is dynamically generated. <br /> You entered: " & _ 
                        TempTextBox.Text

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> TextBox Constructor Example </h3>

      Enter some text and click the Submit button. <br /><br />

      <asp:PlaceHolder ID="TextBoxControlPlaceHolder"
           runat="server"/>

      <br /><br />
 
      <asp:Button ID="SubmitButton"
           Text="Submit"
           OnClick="Submit_Click"
           runat="server"/>

      <br /><br />

      <asp:Label ID="Message"
           runat="server"/>


   </form>

</body>
</html>
<!--</Snippet1>-->