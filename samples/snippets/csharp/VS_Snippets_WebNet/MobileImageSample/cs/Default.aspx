<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        string spec1 = "Device: {0}";
        string spec2 = "Image source: {0}";

        if (!IsPostBack)
        {
            Label1.Text = String.Format(spec1,  Device.Browser);
            Label2.Text = string.Format(spec2, Image1.ImageUrl);
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Image ID="Image1" Runat="server" 
            AlternateText="Sunshine">
            
            <DeviceSpecific ID="imgDevSec" Runat="server">
                <Choice Filter="isWML11" 
                        ImageUrl="symbol:44" />
                <Choice Filter="isCHTML10" 
                        ImageUrl="symbol:63726" />
                <Choice ImageUrl="sunshine.gif" />
            </DeviceSpecific>
            
        </mobile:Image>
        <mobile:Label ID="Label1" Runat="server" />
        <mobile:Label ID="Label2" Runat="server" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
