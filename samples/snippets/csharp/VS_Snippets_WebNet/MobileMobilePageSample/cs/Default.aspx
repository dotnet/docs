<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    // <Snippet2>
    private void Command_OnClick(object sender, EventArgs e)
    {
        // Display the other form
        if (ActiveForm.ID == "Form1")
            ActiveForm = Form2;
        else
            ActiveForm = Form1;
    }
    // </Snippet2>

    public bool isAccessKey(MobileCapabilities caps, 
        string optValue)
    {
        // Determine if the browser is not a Web crawler 
        // and can use access keys
        if (!caps.Crawler && caps.SupportsAccesskeyAttribute)
            return true;
        return false;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form runat="server" id="Form1" >
        <mobile:Label Runat="server">This is Form1</mobile:Label>
        <mobile:Command id="cmd1" runat="server" Text="No AccessKey" 
            onClick="Command_OnClick">
            <DeviceSpecific>
               <Choice Filter="isAccessKey" Text="AccessKey is 1"/>
            </DeviceSpecific>
        </mobile:Command>
        <mobile:Label id="Label1" runat="server" />
    </mobile:Form>
    <mobile:Form ID="Form2" Runat="server">
        <mobile:Label Runat="server">This is Form2</mobile:Label>
        <mobile:Command id="cmd2" runat="server" text="Back to Form1"
            onClick="Command_OnClick">
            <DeviceSpecific>
                <Choice Filter="isAccessKey" Text="1 is AccessKey" AccessKey="1" />
            </DeviceSpecific>
        </mobile:Command>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
