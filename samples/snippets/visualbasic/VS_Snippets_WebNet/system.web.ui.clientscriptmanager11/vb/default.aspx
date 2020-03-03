<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Public Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs)
        ' Define the name and type of the client scripts on the page. 
        Dim csname1 As [String] = "PopupScript"
        Dim cstype As Type = Me.[GetType]()
    
        ' Get a ClientScriptManager reference from the Page class. 
        Dim cs As ClientScriptManager = Page.ClientScript
    
        ' Check to see if the startup script is already registered. 
        If Not cs.IsStartupScriptRegistered(cstype, csname1) Then
            Dim cstext1 As New StringBuilder()
            cstext1.Append("<script type=text/javascript> alert('Hello World!') </")
            cstext1.Append("script>")
        
            cs.RegisterStartupScript(cstype, csname1, cstext1.ToString())
        End If
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RegisterStartupScript</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->

