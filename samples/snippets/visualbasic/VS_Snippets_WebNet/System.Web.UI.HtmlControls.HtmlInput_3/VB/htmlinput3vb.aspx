<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    
    If (IsPostBack) Then
      ' Add code to process the Login.
    End If

  End Sub

  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs)

    ' Pass "password" to make the HtmlInput control render a
    ' password input type.
    Dim passwordText As HtmlInputPassword = New HtmlInputPassword()
    passwordText.MaxLength = 20
    Placeholder1.Controls.Add(passwordText)

    ' Pass "submit" to make the HtmlInput control render a
    ' form submit button.
    Dim submitButton As HtmlInputSubmit = New HtmlInputSubmit("submit")
    submitButton.Value = "Log On to System"
    Placeholder2.Controls.Add(submitButton)
    
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="Form1" runat="server">

      <table cellpadding="2">
        <tr>
        <td>Password
            <asp:placeholder
                runat="server"
                id="Placeholder1" />
        </td></tr>
        <tr><td><asp:placeholder
                runat="server"
                id="Placeholder2" />
        </td></tr>
      </table>
    </form>
  </body>
</html>
<!-- </Snippet1> -->