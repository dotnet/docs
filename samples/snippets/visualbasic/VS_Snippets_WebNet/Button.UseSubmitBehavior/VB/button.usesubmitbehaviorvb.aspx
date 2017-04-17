<!--<Snippet1>-->
<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    
  Sub SubmitBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
    
    Message.Text = "Hello World!"
    
  End Sub

  </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Button.UseSubmitBehavior Example</title>
</head>
<body>
  <form id="form1" runat="server">

    <h3>Button.UseSubmitBehavior Example</h3> 

    Click the Submit button.
      
    <br /><br /> 

    <!--The value of the UseSubmitBehavior property
    is false. Therefore the button uses the ASP.NET 
    postback mechanism.-->
    <asp:button id="Button1"
      text="Submit"
      onclick="SubmitBtn_Click" 
      usesubmitbehavior="false"
      runat="server"/>       

    <br /><br /> 

    <asp:label id="Message" 
      runat="server"/>

  </form>
</body>
</html>
<!--</Snippet1>-->
