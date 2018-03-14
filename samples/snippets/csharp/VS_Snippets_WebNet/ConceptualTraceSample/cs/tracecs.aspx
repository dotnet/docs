<!-- <Snippet1> -->
<%@ Page Language="C#" Trace="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
void Page_Load(object sender, EventArgs e)
{
    try {
      if (IsPostBack)
      {
        
        switch (Request.Form["__EVENTTARGET"])
        {
          case "WarnLink":
            throw new ArgumentException("Trace warn.");
            break;
          case "WriteLink":
            throw new InvalidOperationException("Trace write.");
            break;
          default:
            throw new ArgumentException("General exception.");
            break;          
        }
      }
    }
    catch (ArgumentException ae) {    
        Trace.Warn("Exception Handling", "Warning: Page_Load.", ae);
    }
    catch (InvalidOperationException ioe) {    
        Trace.Write("Exception Handling", "Exception: Page_Load.", ioe);
    }
}

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Trace Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:LinkButton id="WriteLink" 
                      runat="server"
                      text="Generate Trace Write" />
      <asp:LinkButton id="WarnLink"
                      runat="server"
                      text="Generate Trace Warn" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
