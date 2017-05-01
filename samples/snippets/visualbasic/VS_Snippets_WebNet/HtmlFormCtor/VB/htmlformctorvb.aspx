<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server" >
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
         
    ' Create a new HtmlForm control.
    Dim form As HtmlForm = New HtmlForm()
    form.ID = "ButtonForm"

    ' Create an HtmlButton control.
    Dim button As HtmlButton = New HtmlButton()
    button.InnerHtml = "Click Me"

    ' Register the event-handling method for the ServerClick event of the 
    ' HtmlButton control.
    AddHandler button.ServerClick, AddressOf Button_Click

    ' Add the HtmlButton control to the HtmlForm control.
    form.Controls.Add(button)

    ' Add the HtmlForm to the control collection of the page.
    Page.Controls.Add(form)
            
  End Sub

  Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        
    ' Write a message to the user.
    Message.InnerHtml = "Hello World"

  End Sub
  
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
