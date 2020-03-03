<!-- <snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Public Sub PageLoad(ByVal Sender As Object, ByVal e As EventArgs)
    'Manually register the event-handling methods.
    AddHandler ChangePassword1.ChangingPassword, AddressOf Me._ChangingPassword
  End Sub

  Public Sub _ChangingPassword(ByVal Sender As Object, ByVal e As LoginCancelEventArgs)
    If (ChangePassword1.CurrentPassword.ToString() = ChangePassword1.NewPassword.ToString) Then
      Message1.Visible = True
      Message1.Text = "Old password and new password must be different.  Please try again."
      e.Cancel = True
    Else
      'This line prevents the error showing up after a first failed attempt.
      Message1.Visible = False
    End If
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>ChangePassword including a ChangingPassword event handler</title>
</head>
<body>
  <form id="form1" runat="server">
  <div style="text-align:center">

    <h1>ChangePassword</h1>
    
    <asp:LoginView ID="LoginView1" Runat="server" 
      Visible="true">
      <LoggedInTemplate>
        <asp:LoginName ID="LoginName1" Runat="server" FormatString="You are logged in as {0}." />
        <br />
      </LoggedInTemplate>
      <AnonymousTemplate>
        You are not logged in
      </AnonymousTemplate>
    </asp:LoginView><br />
    
    <asp:ChangePassword ID="ChangePassword1" Runat="server"
      BorderStyle="Solid" 
      BorderWidth="1" 
      CancelDestinationPageUrl="~/Default.aspx" 
      DisplayUserName="true" 
      OnChangingPassword="_ChangingPassword"
      ContinueDestinationPageUrl="~/Default.aspx" >
    </asp:ChangePassword><br />
  
    <asp:Label ID="Message1" Runat="server" ForeColor="Red" /><br />

    <asp:HyperLink ID="HyperLink1" Runat="server" 
      NavigateUrl="~/Default.aspx">
      Home
    </asp:HyperLink>
    
  </div>
  </form>
</body>
</html>
<!-- </snippet1>-->