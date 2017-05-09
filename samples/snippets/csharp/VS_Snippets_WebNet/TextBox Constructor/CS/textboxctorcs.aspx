<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> TextBox Constructor Example </title>
<script runat="server">

      protected void Page_Load(Object sender, EventArgs e)
      {

         // Create UserTextBox TextBox control.
         TextBox UserTextBox = new TextBox();

         // Configure the UserTextBox TextBox control.
         UserTextBox.ID = "UserTextBox";
         UserTextBox.Columns = 50;


         // Add UserTextBox TextBox control to the Controls collection 
         // of the TextBoxControlPlaceHolder PlaceHolder control.
         TextBoxControlPlaceHolder.Controls.Add(UserTextBox);

      }

      protected void Submit_Click(Object sender, EventArgs e)
      {

         // Retrieve the UserTextBox TextBox control from the TextBoxControlPlaceHolder
         // PlaceHolder control.
         TextBox TempTextBox = (TextBox)TextBoxControlPlaceHolder.FindControl("UserTextBox");

         // Display the Text property.
         Message.Text = "The TextBox control above is dynamically generated. <br /> You entered: " + 
                        TempTextBox.Text;

      }

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