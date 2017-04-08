<!-- <Snippet4> -->
<%@ Page Language="VB" AutoEventWireup="true" UICulture="auto" Culture="auto" %>
<%@ Register TagPrefix="Samples" Namespace="LocalizingScriptResources" Assembly="LocalizingScriptResources" %>
<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If (IsPostBack) Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectLanguage.SelectedValue)
        Else
            selectLanguage.Items.FindByValue(System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName).Selected = True
        End If
    End Sub

    Protected Sub selectLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectLanguage.SelectedValue)
    End Sub
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Client Localization Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList runat="server" AutoPostBack="true" ID="selectLanguage" OnSelectedIndexChanged="selectLanguage_SelectedIndexChanged">
            <asp:ListItem Text="English" Value="en"></asp:ListItem>
            <asp:ListItem Text="Italian" Value="it"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:ScriptManager ID="ScriptManager1" EnableScriptLocalization="true" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="LocalizingScriptResources" Name="LocalizingScriptResources.CheckAnswer.js" />
        </Scripts>
        </asp:ScriptManager>
        <div>
        <Samples:ClientVerification ID="ClientVerification1" runat="server" ></Samples:ClientVerification>
        </div>
    </form>
</body>
</html>
<!-- </Snippet4> -->