<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  ' <Snippet1>        
  Sub Text_Change(ByVal sender As Object, ByVal e As EventArgs)
    myLabel.Text = "<b>Welcome " + myTextBox.Text + " to ASP.NET</b>"
  End Sub 'Text_Change

  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
    Me.RegisterRequiresPostBack(myTextBox)
  End Sub
  ' </Snippet1>        
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>
                Page Example
            </title>
</head>
    <body>
        <form method="post" runat="server" id="myForm">
            <h4>
                Page Example
            </h4>
            Type a name & hit 'Enter' key
            <asp:TextBox Text=" " EnableViewState="true" ID="myTextBox" OnTextChanged="Text_Change" Runat="server" />
            <br />
            <asp:Label ID="myLabel" Runat="server" />
        </form>
    </body>
</html>
