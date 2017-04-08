<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    '<Snippet3>
    Private Sub AdCreated_Event(ByVal sender As Object, _
        ByVal e As AdCreatedEventArgs)
        
        Label2.Text = "Clicking the AdRotator control takes you to " + _
            e.NavigateUrl
    End Sub
    '</Snippet3>

    ' Determine whether the current browser is a WML brower.
    Public Function isWml11(ByVal caps As MobileCapabilities, _
        ByVal value As String) As Boolean
        If Not caps.Crawler AndAlso caps.PreferredRenderingMime = _
            MobileCapabilities.PreferredRenderingTypeWml11 Then
            
            Return True
        Else
            Return False
        End If
    End Function
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