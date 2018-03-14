<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        ' Define the name, type and url of the client script on the page.
        Dim csname As String = "ButtonClickScript"
        Dim csurl As String = "~/script_include.js"
        Dim cstype As Type = Me.GetType()
    
        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
    
        ' Check to see if the include script is already registered.
        If (Not cs.IsClientScriptIncludeRegistered(cstype, csname)) Then
      
            cs.RegisterClientScriptInclude(cstype, csname, ResolveClientUrl(csurl))
      
        End If
    
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ClientScriptManager Example</title>
</head>
<body>
     <form id="Form1" runat="server">
     <div>
        <input type="text"
               id="Message"/> 
        <input type="button" 
               value="ClickMe"
               onclick="DoClick()"/>
     </div>
     </form>
</body>
</html>
<!-- </Snippet1> -->