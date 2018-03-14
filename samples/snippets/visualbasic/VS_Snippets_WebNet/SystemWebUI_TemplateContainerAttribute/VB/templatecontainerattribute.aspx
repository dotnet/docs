<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    ' <Snippet3>
    ' Get the class type for which to access metadata.
    Dim clsType As Type = GetType(VB_TemplatedFirstControl)
    ' Get the PropertyInfo object for FirstTemplate.
    Dim pInfo As PropertyInfo = clsType.GetProperty("FirstTemplate")
    ' See if the TemplateContainer attribute is defined for this property.
    Dim isDef As Boolean = Attribute.IsDefined(pInfo, GetType(TemplateContainerAttribute))
    ' Display the result if the attribute exists.
    If isDef Then
      Dim tca As TemplateContainerAttribute = CType(Attribute.GetCustomAttribute(pInfo, GetType(TemplateContainerAttribute)), TemplateContainerAttribute)
      Response.Write("The binding direction is: " & tca.BindingDirection.ToString())
    End If
    ' </Snippet3>
   
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TemplateContainerAttribute Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <aspSample:VB_TemplatedFirstControl id="TemplatedFirstControl1" runat="server">
         <FirstTemplate>This is the first template.</FirstTemplate>
      </aspSample:VB_TemplatedFirstControl>
      <br />
      <aspSample:VB_TemplatedFirstControl id="TemplatedFirstControl2" runat="server">
      </aspSample:VB_TemplatedFirstControl>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
