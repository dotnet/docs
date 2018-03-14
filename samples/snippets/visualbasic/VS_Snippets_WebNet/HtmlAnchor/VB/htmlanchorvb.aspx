<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
  
      Sub AnchorBtn_Click(sender As Object, e As EventArgs)

         ' Display a message when the HtmlAnchor control is clicked.
         Message.InnerHtml = "Hello World!"
      
      End Sub
  
   </script>
  
<head runat="server">
    <title> HtmlAnchor Control Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> HtmlAnchor Control Example </h3> 
  
      <a id="AnchorButton"
         onserverclick="AnchorBtn_Click" 
         title="Hello World!"
         runat="server">
 
         Click here

      </a>
   
      <h1>
         <span id="Message" runat="server"/>
      </h1>
  
   </form>

</body>
</html>
 
<!--</Snippet1>-->
