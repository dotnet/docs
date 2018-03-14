<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    ' <Snippet1>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Dim adName As String = Request.QueryString("ad")
        Dim redirect As String = Request.QueryString("target")
        If (adName Is Nothing Or redirect Is Nothing) Then
            redirect = "TestAds.aspx"
        End If

        Dim doc As System.Xml.XmlDocument
        Dim docPath As String = "~/App_Data/AdResponses.xml"

        doc = New System.Xml.XmlDocument()
        doc.Load(Server.MapPath(docPath))
        Dim root As System.Xml.XmlNode = doc.DocumentElement
        Dim xpathExpr As String
        xpathExpr = "descendant::ad[@adname='" & adName & "']"
        Dim adNode As System.Xml.XmlNode = _
            root.SelectSingleNode(xpathExpr)
        If adNode IsNot Nothing Then
            Dim ctr As Integer = _
                CInt(adNode.Attributes("hitCount").Value)
            ctr += 1
            Dim newAdNode As System.Xml.XmlNode = _
                adNode.CloneNode(False)
            newAdNode.Attributes("hitCount").Value = ctr.ToString()
            root.ReplaceChild(newAdNode, adNode)
            doc.Save(Server.MapPath(docPath))
        End If
        Response.Redirect(redirect)
        
    End Sub
    ' </Snippet1>
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
