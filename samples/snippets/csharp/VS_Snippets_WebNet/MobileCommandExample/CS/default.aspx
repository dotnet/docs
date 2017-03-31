<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    //<Snippet3>
    public void Page_Load(Object sender, EventArgs e)
    {
        MobileCapabilities caps
            = (MobileCapabilities)Request.Browser;
        if (caps.MaximumSoftkeyLabelLength == 5)
        {
            Command1.SoftkeyLabel = "Click";
        }
        else if (caps.MaximumSoftkeyLabelLength > 5)
        {
            Command1.SoftkeyLabel = "Submit";
        }
    }
    //</Snippet3>

    void Command_Click(object sender, CommandEventArgs e)
    {
        string txt = "You clicked Button{0}. ({1} points)";
        if (e.CommandName.ToString() == "Command1")
        {
            Label1.Text = String.Format(txt, 1, 
                e.CommandArgument);
        }
        else if (e.CommandName.ToString() == "Command2")
        {
            Label1.Text = String.Format(txt, 2, 
                e.CommandArgument);
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label id="Label1" runat="server">
            Click a button
        </mobile:Label>
        <mobile:Label id="Label2" runat="server" /> 
        <mobile:Command id="Command1"  Format="Button"
            OnItemCommand="Command_Click" 
            CommandName="Command1" runat="server" 
            Text="Button1" CommandArgument="70" />
        <mobile:Command id="Command2" Format="Link"
            OnItemCommand="Command_Click" 
            CommandName="Command2" runat="server" 
            Text="Button2" CommandArgument="50" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
