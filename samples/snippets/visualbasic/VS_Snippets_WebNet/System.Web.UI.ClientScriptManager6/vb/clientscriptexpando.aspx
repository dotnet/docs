<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        
    ' Get a ClientScriptManager reference from the Page class.
    Dim cs As ClientScriptManager = Page.ClientScript
    
    ' Register an expando attribute.
    cs.RegisterExpandoAttribute("Message", "title", "New title from client script.", True)    
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form    id="Form1"
            runat="server">
     <span  id="Message" 
            title="Title to be replaced.">
            Place your mouse over this text to see the title.
     </span>
     </form>
  </body>
</html>
<!-- </Snippet1> -->
