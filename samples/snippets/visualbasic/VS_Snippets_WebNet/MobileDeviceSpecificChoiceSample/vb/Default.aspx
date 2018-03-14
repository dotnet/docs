<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    Private Function supportsColor(ByVal caps As MobileCapabilities, _
        ByVal value As String) As Boolean
        
        ' Determine if the browser is not a Web crawler and
        ' can display in color
        If Not caps.Crawler And caps.IsColor Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function isWML11(ByVal caps As MobileCapabilities, _
        ByVal value As String) As Boolean

        ' Determine if the browser is not a Web crawler and
        ' requires WML markup
        If (Not caps.Crawler) AndAlso caps.PreferredRenderingType = _
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
