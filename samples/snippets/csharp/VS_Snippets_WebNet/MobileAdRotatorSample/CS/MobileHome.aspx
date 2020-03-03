<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    //<Snippet3>
    private void AdCreated_Event(Object sender, AdCreatedEventArgs e)
    {
       Label2.Text = "Clicking the AdRotator control takes you to " + 
           e.NavigateUrl;
    }
    //</Snippet3>

    // Determine whether the current browser is a WML brower
    public bool isWML11(MobileCapabilities caps, string optValue)
    {
        // Determine if the browser is not a Web crawler and 
        // requires WML markup
        if (!caps.Crawler && caps.PreferredRenderingType == 
            MobileCapabilities.PreferredRenderingTypeWml11)
            return true;
        else
            return false;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <!-- <Snippet4> -->
        <!-- The AdRotator control -->
        <mobile:AdRotator id="AdControl" runat="server"
            ImageKey="MobileImgSrc" NavigateUrlKey="TargetUrl"
            AdvertisementFile="App_Data/ads.xml" Alignment="Left" 
            KeywordFilter="Developer" OnAdCreated="AdCreated_Event">
            <DeviceSpecific>
                <Choice Filter="isWML11" NavigateUrlKey="WmlTargetUrl" 
                    ImageKey= "WmlImageSrc" />
            </DeviceSpecific>
        </mobile:AdRotator>
        <!-- </Snippet4> -->
        
        <!-- The instructions label -->
        <mobile:Label id="Label1" runat="server" 
            Text="Refresh the page to change the advertisement" />

        <!-- The URL info label -->
        <mobile:Label id="Label2" runat="server" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->