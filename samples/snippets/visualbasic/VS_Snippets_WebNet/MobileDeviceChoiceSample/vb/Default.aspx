<%@ Page Language="VB" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<script runat="server">
    '<Snippet1>
    Public Sub Page_Load(ByVal source As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Dim txt As String = "Selected Filter is {0}"
            Label1.Text = String.Format(txt, _
                Panel1.DeviceSpecific.SelectedChoice.Filter.ToString())
        End If
    End Sub
    '</Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label ID="Label1" Runat="server" />
        <mobile:Panel ID="Panel1" Runat="server"></mobile:Panel>
    </mobile:form>
</body>
</html>
