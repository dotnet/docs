<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    public int cbCount = 0;
    
    // Define method that processes the callbacks on server.
    public void RaiseCallbackEvent(String eventArgument)
    {
        cbCount = Convert.ToInt32(eventArgument) + 1;
    }

    // Define method that returns callback result.
    public string GetCallbackResult()
    {
        return cbCount.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Define a StringBuilder to hold messages to output.
        StringBuilder sb = new StringBuilder();

        // Check if this is a postback.
        sb.Append("No page postbacks have occurred.");
        if (Page.IsPostBack)
        {
            sb.Append("A page postback has occurred.");
        }

        // Write out any messages.
        MyLabel.Text = sb.ToString();

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        // Define one of the callback script's context.
        // The callback script will be defined in a script block on the page.
        StringBuilder context1 = new StringBuilder();
        context1.Append("function ReceiveServerData1(arg, context)");
        context1.Append("{");
        context1.Append("Message1.innerText =  arg;");
        context1.Append("value1 = arg;");
        context1.Append("}");

        // Define callback references.
        String cbReference1 = cs.GetCallbackEventReference(this, "arg", 
            "ReceiveServerData1", context1.ToString());
        String cbReference2 = cs.GetCallbackEventReference("'" + 
            Page.UniqueID + "'", "arg", "ReceiveServerData2", "", 
            "ProcessCallBackError", false);
        String callbackScript1 = "function CallTheServer1(arg, context) {" + 
            cbReference1 + "; }";
        String callbackScript2 = "function CallTheServer2(arg, context) {" + 
            cbReference2 + "; }";

        // Register script blocks will perform call to the server.
        cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer1", 
            callbackScript1, true);
        cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer2", 
            callbackScript2, true);

    }
</script>

<script type="text/javascript">
var value1 = 0;
var value2 = 0;
function ReceiveServerData2(arg, context)
{
    Message2.innerText = arg;
    value2 = arg;
}
function ProcessCallBackError(arg, context)
{
    Message2.innerText = 'An error has occurred.';
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ClientScriptManager Example</title>
</head>
<body>
    <form id="Form1" 
          runat="server">
    <div>
      Callback 1 result: <span id="Message1">0</span>
      <br />
      Callback 2 result: <span id="Message2">0</span>
      <br /> <br />
      <input type="button" 
             value="ClientCallBack1" 
             onclick="CallTheServer1(value1, alert('Increment value'))"/>    
      <input type="button" 
             value="ClientCallBack2" 
             onclick="CallTheServer2(value2, alert('Increment value'))"/>
      <br /> <br />
      <asp:Label id="MyLabel" 
                 runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
