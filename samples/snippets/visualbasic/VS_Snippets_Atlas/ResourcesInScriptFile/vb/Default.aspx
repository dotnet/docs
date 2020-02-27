<!-- <Snippet1> -->
<%@ Page Language="VB" AutoEventWireup="true" UICulture="auto" Culture="auto" %>

<script runat="server">
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim _firstInt As Int32
        Dim _secondInt As Int32
        
        Dim _random As New Random()
        _firstInt = _random.Next(0, 20)
        _secondInt = _random.Next(0, 20)

        firstNumber.Text = _firstInt.ToString()
        secondNumber.Text = _secondInt.ToString()
        
        If (IsPostBack) Then
            userAnswer.Text = ""
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
    <form id="form1" runat="server" >
        <asp:DropDownList runat="server" AutoPostBack="true" ID="selectLanguage" OnSelectedIndexChanged="selectLanguage_SelectedIndexChanged">
            <asp:ListItem Text="English" Value="en"></asp:ListItem>
            <asp:ListItem Text="Italian" Value="it"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:ScriptManager ID="ScriptManager1" EnableScriptLocalization="true" runat="server">
        <Scripts>
            <asp:ScriptReference Path="scripts/CheckAnswer.js" ResourceUICultures="it-IT" />
        </Scripts>
        </asp:ScriptManager>
        <div>
        <asp:Label ID="firstNumber" runat="server"></asp:Label>
        +
        <asp:Label ID="secondNumber" runat="server"></asp:Label>
        =
        <asp:TextBox ID="userAnswer" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClientClick="return CheckAnswer()" />
        <br />
        <asp:Label ID="labeltest" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
