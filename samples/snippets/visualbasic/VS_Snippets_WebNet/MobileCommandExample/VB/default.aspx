<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    '<Snippet3>
    Public Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)

        Dim caps As System.Web.Mobile.MobileCapabilities _
            = CType(Request.Browser, MobileCapabilities)

        If caps.MaximumSoftkeyLabelLength = 5 Then
            Command1.SoftkeyLabel = "Click"
        ElseIf caps.MaximumSoftkeyLabelLength > 5 Then
            Command1.SoftkeyLabel = "Submit"
        End If
    End Sub
    '</Snippet3>

    Private Sub Command_Click(ByVal sender As Object, _
        ByVal e As CommandEventArgs)

        Dim txt As String = "You clicked Button{0}. ({1} points)"
        If e.CommandName.ToString() = "Command1" Then
            Label1.Text = String.Format(txt, 1, e.CommandArgument)
        ElseIf e.CommandName.ToString() = "Command2" Then
            Label1.Text = String.Format(txt, 2, e.CommandArgument)
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label id="Label1" runat="server">
            Click a button
        </mobile:Label>
        <mobile:Label id="Label2" runat="server" /> 
        <mobile:Command id="Command1" Format="Button"
            OnItemCommand="Command_Click" 
            CommandName="Command1" runat="server" 
            Text="Button1" CommandArgument="70" />
        <mobile:Command id="Command2" Format="Link"
            OnItemCommand="Command_Click" 
            CommandName="Command2" runat="server" 
            Text="Button2" CommandArgument="50" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
