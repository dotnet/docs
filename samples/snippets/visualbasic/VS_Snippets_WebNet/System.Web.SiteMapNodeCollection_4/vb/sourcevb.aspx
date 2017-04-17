<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' <Snippet1>
    Dim providername1 As String = "xAspNetXmlSiteMapProvider"
    Dim providername2 As String = "MyXmlSiteMapProvider"
    Dim providers As SiteMapProviderCollection = SiteMap.Providers
    
    If Not (providers(providername1) Is Nothing) AndAlso Not (providers(providername2) Is Nothing) Then
      Dim provider1 As SiteMapProvider = providers(providername1)
      Dim provider2 As SiteMapProvider = providers(providername2)
      Dim collection1 As SiteMapNodeCollection = provider1.RootNode.ChildNodes
      Dim collection2 As SiteMapNodeCollection = provider2.RootNode.ChildNodes
      Dim matches As Integer = 0
      Dim node As SiteMapNode
      For Each node In collection1
        If collection2.Contains(node) Then
          Response.Write("Match found at " & _
          providername1 & ", index = " & _
          collection1.IndexOf(node) & " with " & _
          providername2 & ", index = " & _
          collection2.IndexOf(node) & ".<br />")
          matches += 1
        End If
      Next node
      Response.Write("Number of matches found = " & _
      matches.ToString() + ".")
    Else
      Response.Write(providername1 & " or " & _
      providername2 & " not found.")
    End If    
    ' </Snippet1>
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SiteMapNodeCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
