<!--<Snippet1>-->

<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> HtmlButton Constructor Example </title>
<script runat="server">

      Sub Page_Load(sender As Object, e As EventArgs)

         ' Create a new HtmlButton control.
         Dim NewButtonControl As New HtmlButton()

         ' Set the properties of the new HtmlButton control.
         NewButtonControl.ID = "NewButtonControl"
         NewButtonControl.InnerHtml = "Click Me"

         ' Create an EventHandler delegate for the method you want to handle the event
         ' and then add it to the list of methods called when the event is raised.
         AddHandler NewButtonControl.ServerClick, AddressOf Button_Click 

         ' Add the new HtmlButton control to the Controls collection of the
         ' PlaceHolder control. 
         ControlContainer.Controls.Add(NewButtonControl)

      End Sub

      Sub Button_Click(sender As Object, e As EventArgs)

         ' Display a simple message. 
         Message.InnerHtml = "Thank you for clicking the button."

      End Sub

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3> HtmlButton Constructor Example </h3>

      <asp:PlaceHolder ID="ControlContainer"
           runat="server"/>

      <br /><br />
 
      <span id="Message"
            runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->