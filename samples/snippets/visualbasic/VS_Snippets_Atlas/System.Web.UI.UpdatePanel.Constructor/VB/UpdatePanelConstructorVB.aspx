<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
     "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lbl As Label
        lbl = Page.FindControl("Label1")
        lbl.Text = "Panel refreshed at " & DateTime.Now.ToString()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim up1 As UpdatePanel
        up1 = New UpdatePanel()
        up1.ID = "UpdatePanel1"
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
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UpdatePanel Constructor Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
