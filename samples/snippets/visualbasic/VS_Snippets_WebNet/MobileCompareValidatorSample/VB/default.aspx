<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label id="Label1" runat="server">Enter values
            </mobile:Label> 
        <mobile:TextBox id="TextBox1" runat="server" Text="abc" />
        <mobile:TextBox id="TextBox2" runat="server" Text="xyz" />
        <mobile:Command id="Command1" runat="server" Text="OK" />
        <mobile:CompareValidator ID="CompareValidator1" Runat="server" 
            ErrorMessage="Values are different" Operator="Equal"
            ControlToCompare="TextBox1"
            ControlToValidate="TextBox2" />
    </mobile:form>
</body>

</html>
<!-- </Snippet1> -->
