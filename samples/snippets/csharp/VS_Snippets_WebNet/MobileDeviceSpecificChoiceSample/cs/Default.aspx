<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    private bool supportsColor(MobileCapabilities caps, string optValue)
    {
        // Determine if the browser is not a Web crawler and
        // can display in color
        if (!caps.Crawler && caps.IsColor)
            return true;
        return false;
    }

    private bool isWML11(MobileCapabilities caps, string optValue)
    {
        // Determine if the browser is not a Web crawler and
        // requires WML markup
        if (!caps.Crawler && caps.PreferredRenderingType ==
            MobileCapabilities.PreferredRenderingTypeWml11)
            return true;
        return false;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Image ID="Image1" runat="server" 
            AlternateText="Cannot display this image.">
            <DeviceSpecific>
                <choice Filter ="isWML11" ImageURL="wmlImage.wbmp" />
                <choice Filter="supportsColor" ImageURL="colorImage.gif" />
                <choice ImageURL="monoImg.gif" />
            </DeviceSpecific>
        </mobile:Image>
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
