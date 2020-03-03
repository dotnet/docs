<!-- <Snippet1> -->
<%@ Page Language="C#"%>
<%@ Import Namespace="Samples.AspNet.CS.Controls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
 
  public void Page_Load(Object sender, EventArgs e)
  {
    // Define the resource name and type.
    String rsname = "Samples.AspNet.CS.Controls.script_include.js";
    Type rstype = typeof(ClientScriptResourceLabel);
        
    // Get a ClientScriptManager reference from the Page class.
    ClientScriptManager cs = Page.ClientScript;

    // Write out the web resource url.
    ResourcePath.InnerHtml = cs.GetWebResourceUrl(rstype, rsname);

    // Register the client resource with the page.
    cs.RegisterClientScriptResource(rstype, rsname);

  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form    id="Form1"
            runat="server">
     The web resource path is 
     <span  id="ResourcePath"
            runat="server"/>.
     <br />
     <br />
     <input type="text" 
            id="Message" />     
     <input type="button" 
            onclick="DoClick()" 
            value="ClientClick" />
     </form>
  </body>
</html>
<!-- </Snippet1> -->