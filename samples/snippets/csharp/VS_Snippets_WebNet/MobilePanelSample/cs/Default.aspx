<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Drawing" %>

<script runat="server">
    public void Page_Load(Object sender, EventArgs e)
    {
        // Set Panel1 properties
        Panel1.Wrapping = Wrapping.NoWrap;
        Panel1.Alignment = Alignment.Center;
        Panel1.StyleReference = "title";

        // Find Label in Panel2
        Control ctl = Panel2.Content.FindControl("lblStatusToday");
        if (ctl != null)
            ((System.Web.UI.MobileControls.Label)ctl).Text
                = "I found this label";
    }
    
    public void MakeFontRed(Object sender, EventArgs e)
    {
        Panel1.ForeColor = Color.Red;
    }
    
    public void MakeFontBlue(Object sender, EventArgs e)
    {
        Panel1.ForeColor = Color.Blue;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<mobile:Form runat="server" id="Form1">
    <!-- First Panel -->
    <mobile:Panel runat="server" id="Panel1">
        <mobile:TextView runat="server" id="TextView1">
            A Panel provides a grouping mechanism<br />
            for organizing controls.
        </mobile:TextView>
    </mobile:Panel>
    <mobile:Command runat="server" id="Command1"  BreakAfter="false"
        Text="Make Font Red" OnClick="MakeFontRed"/>
    <mobile:Command runat="server" id="Command2" BreakAfter="true"
        Text="Make Font Blue" OnClick="MakeFontBlue"/>

    <!-- Second Panel -->
    <mobile:Panel ID="Panel2"  Runat="server">
        <mobile:DeviceSpecific id="DeviceSpecific1" runat="server">
            <!-- Filter and template for HTML32 devices -->
            <Choice Filter="isHTML32" 
                Xmlns="http://schemas.microsoft.com/mobile/html32template">
                <ContentTemplate>
                    <mobile:Label id="Label1" runat="server">
                        HTML32 Template</mobile:Label>
                    <mobile:Label ID="lblStatusToday" Runat="server"/>
                </ContentTemplate>
            </Choice>
            <!-- Default filter and template -->
            <Choice>
                <ContentTemplate>
                    <mobile:Label ID="Label1" Runat="server">
                        Default Template</mobile:Label>
                    <mobile:Label ID="lblStatusToday" Runat="server" />
                </ContentTemplate>
            </Choice>
        </mobile:DeviceSpecific>
    </mobile:Panel>
</mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
