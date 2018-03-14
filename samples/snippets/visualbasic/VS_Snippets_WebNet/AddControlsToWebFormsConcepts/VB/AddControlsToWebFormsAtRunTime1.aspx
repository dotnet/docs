<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Add Controls to a Web Forms Page at Run Time</title>
</head>

<script runat="server">
    
    
    
    '<Snippet1>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Button1 As New Button()
        If ViewState("controlsadded") Is Nothing Then
            AddControls()
        End If
    End Sub

    Protected Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        If ViewState("controlsadded") = True Then
            AddControls()
        End If
    End Sub

    Dim Panel1 As New Panel
    Private Sub AddControls()
        Dim dynamictextbox As New TextBox
        dynamictextbox.Text = "(Enter some text)"
        dynamictextbox.ID = "dynamictextbox"
        Dim dynamicbutton As New Button
        AddHandler dynamicbutton.Click, AddressOf dynamicbutton_Click
        dynamicbutton.Text = "Dynamic Button"
        Panel1.Controls.Add(dynamictextbox)
        Panel1.Controls.Add(New LiteralControl("<br /><br />"))
        Panel1.Controls.Add(dynamicbutton)
        ViewState("controlsadded") = True
    End Sub

    Private Sub dynamicbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim tb As TextBox
        tb = CType(Panel1.FindControl("dynamictextbox"), TextBox)
        Label1.Text = Server.HtmlEncode(tb.Text)
    End Sub
    '</Snippet1>
      
</script>

<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button id="Button1" runat="server" ></asp:Button>
      <asp:Label id="Label1" runat="server" AssociatedControlID="Button1"></asp:Label>
    </div>
    </form>
</body>
</html>
