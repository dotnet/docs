<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="AspNetSamples" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS.Controls" %>
<%@ Import Namespace="System.Reflection" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
            
    // Get the assembly metatdata.
    Type clsType = typeof(MyCustomControl);
    Assembly a = clsType.Assembly;

    // Iterate through the attributes for the assembly.
    foreach (Attribute attr in Attribute.GetCustomAttributes(a))
    {
      //Check for WebResource attributes.
      if (attr.GetType() == typeof(WebResourceAttribute))
      {
        WebResourceAttribute wra = (WebResourceAttribute)attr;
        Response.Write("Resource in the assembly: " + wra.WebResource.ToString() +
          " with ContentType = " + wra.ContentType.ToString() +
          " and PerformsSubstitution = " + wra.PerformSubstitution.ToString() + "</br>");
      }
    }
  }
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