<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {

    // <Snippet3>
    // Get the class type for which to access metadata.
    Type clsType = typeof(TemplatedFirstControl);
    // Get the PropertyInfo object for FirstTemplate.
    PropertyInfo pInfo = clsType.GetProperty("FirstTemplate");
    // See if the TemplateContainer attribute is defined for this property.
    bool isDef = Attribute.IsDefined(pInfo, typeof(TemplateContainerAttribute));
    // Display the result if the attribute exists.
    if (isDef)
    {
      TemplateContainerAttribute tca =
        (TemplateContainerAttribute)Attribute.GetCustomAttribute(pInfo, typeof(TemplateContainerAttribute));
      Response.Write("The binding direction is: " + tca.BindingDirection.ToString());
    }
    // </Snippet3>

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TemplateContainerAttribute Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <aspSample:TemplatedFirstControl id="TemplatedFirstControl1" runat="server">
         <FirstTemplate>This is the first template.</FirstTemplate>
      </aspSample:TemplatedFirstControl>
      <br />
      <aspSample:TemplatedFirstControl id="TemplatedFirstControl2" runat="server">
      </aspSample:TemplatedFirstControl>    
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
