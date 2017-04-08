<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Define the name and type of the client script on the page.
    Dim csname As String = "OnSubmitScript"
    Dim cstype As Type = Me.GetType()
    
    ' Get a ClientScriptManager reference from the Page class.
    Dim cs As ClientScriptManager = Page.ClientScript
    
    ' Check to see if the OnSubmit statement is already registered.
    If (Not cs.IsOnSubmitStatementRegistered(cstype, csname)) Then
      
      Dim cstext As String = "document.write('Text from OnSubmit statement.');"
      cs.RegisterOnSubmitStatement(cstype, csname, cstext)
      
    End If
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form    id="Form1"
            runat="server">
     <input type="submit"
            value="Submit" />
     </form>
  </body>
</html>
<!-- </Snippet1> -->
