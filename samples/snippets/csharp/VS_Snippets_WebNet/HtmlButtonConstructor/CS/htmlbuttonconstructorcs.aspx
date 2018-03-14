<!--<Snippet1>-->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" > 

<head>
    <title> HtmlButton Constructor Example </title>
<script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {

         // Create a new HtmlButton control.
         HtmlButton NewButtonControl = new HtmlButton();

         // Set the properties of the new HtmlButton control.
         NewButtonControl.ID = "NewButtonControl";
         NewButtonControl.InnerHtml = "Click Me";

         // Create an EventHandler delegate for the method you want to handle the event
         // and then add it to the list of methods called when the event is raised.
         NewButtonControl.ServerClick += new System.EventHandler(this.Button_Click); 

         // Add the new HtmlButton control to the Controls collection of the
         // PlaceHolder control. 
         ControlContainer.Controls.Add(NewButtonControl);

      }

      void Button_Click(Object sender, EventArgs e)
      {

         // Display a simple message. 
         Message.InnerHtml = "Thank you for clicking the button.";

      }

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