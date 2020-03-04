<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Register TagPrefix="AspNetSamples" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' <Snippet3>
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Get the class type for which to access metadata.
    Dim clsType As Type = GetType(MyLoginViewA)
    ' Get the PropertyInfo object for FirstTemplate.
    Dim pInfo As PropertyInfo = clsType.GetProperty("AnonymousTemplate")
    ' See if the TemplateInstanceAttribute is defined for this property.
    Dim isDef As Boolean = Attribute.IsDefined(pInfo, GetType(TemplateContainerAttribute))
    
    ' Display the result if the attribute exists.
    If isDef Then
      Dim tia As TemplateInstanceAttribute = CType(Attribute.GetCustomAttribute(pInfo, GetType(TemplateInstanceAttribute)), TemplateInstanceAttribute)
      Response.Write("The <AnonymousTemplate> has the TemplateInstanceAttribute = " & tia.Instances.ToString() & ".<br />")
      If (tia.IsDefaultAttribute()) Then
        Response.Write("The TemplateInstanceAttribute used is the same as the default instance.")
      Else
        Response.Write("The TemplateInstanceAttribute used is not the same as the default instance.")
      End If

    End If

  End Sub
  ' </Snippet3>
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TemplateInstance Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <AspNetSamples:MyLoginViewA id="MyLoginViewA1" runat="server">
        <AnonymousTemplate>
          <asp:Label ID="LoginViewLabel1" runat="server" Text="LoginView Anonymous Template Text"/>
        </AnonymousTemplate>
      </AspNetSamples:MyLoginViewA>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
