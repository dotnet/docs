<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> Button Constructor Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create a new Button control.
         Dim NewButton As Button = New Button()
         NewButton.Text="Click Me"

         ' Register the event-handling method for the Click event. 
         AddHandler NewButton.Click, AddressOf Button_Click

         ' Add the control to the Controls collection of the
         ' PlaceHolder control. 
         Place.Controls.Clear()
         Place.Controls.Add(NewButton)

      End Sub

      Sub Button_Click(sender as Object, e As EventArgs)

         Message.Text = "Hello World"

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> Button Constructor Example </h3>

      <asp:Placeholder id="Place" 
           runat="server"/>

      <br /><br />

      <asp:Label id="Message" 
           runat="server"/>

   </form>

</body>

</html>

<!-- </Snippet1> -->