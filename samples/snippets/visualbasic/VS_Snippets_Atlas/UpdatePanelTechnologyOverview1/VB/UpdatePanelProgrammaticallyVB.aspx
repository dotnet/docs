<!-- <Snippet4> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-'W3C'DTD XHTML 1.0 Transitional'EN" 
 "http:'www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal Sender As Object, ByVal E As EventArgs)
        Dim up1 As UpdatePanel
        up1 = New UpdatePanel()
        up1.ID = "UpdatePanel1"
        up1.UpdateMode = UpdatePanelUpdateMode.Conditional
        Dim button1 As Button
        button1 = New Button()
        button1.ID = "Button1"
        button1.Text = "Submit"
        AddHandler button1.Click, AddressOf Button_Click
        Dim label1 As Label
        label1 = New Label()
        label1.ID = "Label1"
        label1.Text = "A full page postback occurred."
        up1.ContentTemplateContainer.Controls.Add(button1)
        up1.ContentTemplateContainer.Controls.Add(label1)
        Page.Form.Controls.Add(up1)

    End Sub
    Protected Sub Button_Click(ByVal Sender As Object, ByVal E As EventArgs)
        Dim lbl As Label
        lbl = Page.FindControl("Label1")
        lbl.Text = "Panel refreshed at " & _
            DateTime.Now.ToString()
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UpdatePanel Added Programmatically Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="TheScriptManager"
                               runat="server" />
        </div>
    </form>
</body>
</html>
<!-- </Snippet4> -->
