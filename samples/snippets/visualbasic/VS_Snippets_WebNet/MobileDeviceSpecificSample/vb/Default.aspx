<%@ Page Language="VB" Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<script runat="server">
    '<Snippet1>
    Public Sub Page_Load(ByVal source As Object, ByVal e As EventArgs)
        If Panel1.IsTemplated Then
            Dim txt As String = "Loaded panel has {0} Templates for a Filter named {1}."
            Dim TemplateCount As Integer = _
                Panel1.DeviceSpecific.Choices(0).Templates.Count
            Dim FilterString As String = _
                Panel1.DeviceSpecific.Choices(0).Filter.ToString()
            Label1.Text = _
                String.Format(txt, TemplateCount, FilterString)
        Else
            Label1.Text = "Loaded panel does not have Templates"
        End If
    End Sub
    '</Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:panel id="Panel1" runat="server" />
        <mobile:label id="Label1" runat="server" />
    </mobile:form>
</body>
</html>
