<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Register TagPrefix="AspNetSamples" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
   
  // <Snippet3> 
  protected void Page_Load(object sender, EventArgs e)
  {
        
    // Get the class type for which to access metadata.
    Type clsType = typeof(MyLoginViewA);
    // Get the PropertyInfo object for FirstTemplate.
    PropertyInfo pInfo = clsType.GetProperty("AnonymousTemplate");
    // See if the TemplateInstanceAttribute is defined for this property.
    bool isDef = Attribute.IsDefined(pInfo, typeof(TemplateInstanceAttribute));

    // Display the result if the attribute exists.
    if (isDef)
    {
      TemplateInstanceAttribute tia =
        (TemplateInstanceAttribute)Attribute.GetCustomAttribute(pInfo, typeof(TemplateInstanceAttribute));
      Response.Write("The <AnonymousTemplate> has the TemplateInstanceAttribute = " + tia.Instances.ToString() + ".<br />");
      if (tia.IsDefaultAttribute())
        Response.Write("The TemplateInstanceAttribute used is the same as the default instance.");
      else
        Response.Write("The TemplateInstanceAttribute used is not the same as the default instance.");
    }

  }
  // </Snippet3> 

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
