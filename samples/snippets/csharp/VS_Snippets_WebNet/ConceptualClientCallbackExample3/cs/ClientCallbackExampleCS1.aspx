<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>
<!-- </Snippet1> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    String returnValue;
    // <Snippet2>
    public void RaiseCallbackEvent(String eventArgument)
    {
        
    }
    // </Snippet2>
    // <Snippet3>
    public String GetCallbackResult()
    {
        return returnValue;
    }
    // </Snippet3>
    // <Snippet4>
    protected override void Render(HtmlTextWriter writer)
    {
        Page.ClientScript.RegisterForEventValidation("ClientCallback1");
        base.Render(writer);
    }
    // </Snippet4>
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>