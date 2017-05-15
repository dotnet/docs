<!-- <Snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  public void Page_Load(Object sender, EventArgs e)
  {
    // Define the name and type of the client scripts on the page.
    String csname1 = "PopupScript";
    Type cstype = this.GetType();
        
    // Get a ClientScriptManager reference from the Page class.
    ClientScriptManager cs = Page.ClientScript;

    // Check to see if the startup script is already registered.
    if (!cs.IsStartupScriptRegistered(cstype, csname1))
    {
        StringBuilder cstext1 = new StringBuilder();
        cstext1.Append("<script type=text/javascript> alert('Hello World!') </");
        cstext1.Append("script>");

        cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
    }
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RegisterStartupScript</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->