<!-- <Snippet1> -->
<%@ Page Language="C#" Culture="auto" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void Page_Load(object sender, EventArgs e)
  {
    string localresourcestring;
    string globalresourcestring;
    
    // Get the local resource string.
    try
    {
      localresourcestring = "Found the local resource string and it's value is: " + 
        (String)GetLocalResourceObject("LocalResourceString1") + ".";
    }
    catch
    {
      localresourcestring = "Could not find local resource.";
    }
    
    // Get the global resource string.
    try
    {
      // Look in the global resource file called MyResource.resx.
      globalresourcestring = "Found the global resource string and it's value is: " +
        (String)GetGlobalResourceObject("MyResource", "GlobalResourceString1") + ".";
    }
    catch
    {
      globalresourcestring = "Could not find global resource.";
    }

    LocalResourceMessage.InnerText = localresourcestring;
    GlobalResourceMessage.InnerText = globalresourcestring;

  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TemplateControl GetGlobalResourceObject and GetLocalResourceObject Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>TemplateControl GetGlobalResourceObject and GetLocalResourceObject Example</h3>
      <span id="LocalResourceMessage"
            runat="server"/>
      <br />
      <span id="GlobalResourceMessage"
            runat="server" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->