<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  void Page_Load(Object sender, EventArgs e)
  {

    // Create a new HtmlForm control.
    HtmlForm form = new HtmlForm();
    form.ID = "ButtonForm";

    // Create an HtmlButton control.
    HtmlButton button = new HtmlButton();
    button.InnerHtml = "Click Me";

    // Register the event-handling method for the ServerClick event of the 
    // HtmlButton control.
    button.ServerClick += new System.EventHandler(this.Button_Click);

    // Add the HtmlButton control to the HtmlForm control.
    form.Controls.Add(button);

    // Add the HtmlForm control to the control collection of the page.
    Page.Controls.Add(form);

  }

  void Button_Click(Object sender, EventArgs e)
  {

    // Write a message to the user.
    Message.InnerHtml = "Hello World";

  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>

   <title>HtmlForm Constructor Example</title>

</head>

<body>
  
   <h3> HtmlForm Constructor Example </h3>

   <span id="Message" runat="server"/> 

</body>

</html>
 
<!--</Snippet1>-->
