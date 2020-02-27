<%@ Page Language="C#" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<!-- <Snippet2> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server">
        <mobile:DeviceSpecific Runat="server">
            <Choice Filter="isHTML32">
                <HeaderTemplate>
                    <mobile:Label ID="Label1" Runat="server">
                        Header Template - HTML32</mobile:Label>
                    <mobile:Command Runat="server">
                        Submit</mobile:Command>
                </HeaderTemplate>
                <FooterTemplate>
                    <mobile:Label ID="Label2" Runat="server">
                        Footer Template</mobile:Label>
                </FooterTemplate>
            </Choice>
            <Choice>
                <HeaderTemplate>
                    <mobile:Label ID="Label1" Runat="server">
                        Header Template - Default</mobile:Label>
                    <mobile:Command ID="Command1" Runat="server">
                        Submit</mobile:Command>
                </HeaderTemplate>
                <FooterTemplate>
                    <mobile:Label ID="Label2" Runat="server">
                        Footer Template</mobile:Label>
                </FooterTemplate>
            </Choice>
        </mobile:DeviceSpecific>
    </mobile:Form>
</body>
</html>
<!-- </Snippet2> -->
