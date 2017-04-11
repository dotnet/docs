<!-- <Snippet1> -->
<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
 "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    public void Page_Load(Object sender, EventArgs e)
    {
        // Define the name, type and url of the client script on the page.
        String csname = "ButtonClickScript";
        String csurl = "~/script_include.js";
        Type cstype = this.GetType();

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        // Check to see if the include script exists already.
        if (!cs.IsClientScriptIncludeRegistered(cstype, csname))
        {
            cs.RegisterClientScriptInclude(cstype, csname, ResolveClientUrl(csurl));
        }

    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ClientScriptManager Example</title>
  </head>
  <body>
     <form id="Form1" runat="server">
     <div>
        <input type="text"
               id="Message"/> 
        <input type="button" 
               value="ClickMe"
               onclick="DoClick()"/>
     </div>
     </form>
  </body>
</html>
<!-- </Snippet1> -->