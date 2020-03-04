<%@ Page Language="VB" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim spec1 As String = "Device: {0}"
        Dim spec2 As String = "Image source: {0}"

        If Not IsPostBack Then
            Label1.Text = String.Format(spec1, Device.Browser)
            Label2.Text = String.Format(spec2, Image1.ImageUrl)
        End If
    End Sub
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
