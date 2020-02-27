<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="AspNetSamples" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB.Controls" %>
<%@ Import Namespace="System.Reflection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Get the assembly metatdata.
    Dim clsType As Type = GetType(MyCustomControl)
    Dim a As Assembly = clsType.Assembly
    
    For Each attr As Attribute In Attribute.GetCustomAttributes(a)
      'Check for WebResource attributes.
      If attr.GetType() Is GetType(WebResourceAttribute) Then
        Dim wra As WebResourceAttribute = CType(attr, WebResourceAttribute)
        Response.Write("Resource in the assembly: " & wra.WebResource.ToString() & _
        " with ContentType = " & wra.ContentType.ToString() & _
        " and PerformsSubstitution = " & wra.PerformSubstitution.ToString() & "</br>")
      End If
    Next attr
    
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WebResourceAttribute Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <AspNetSamples:MyCustomControl id="MyCustomControl1" runat="server">
      </AspNetSamples:MyCustomControl>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->