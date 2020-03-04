<!-- <snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Public Sub MySendingMail(ByVal Sender As Object, ByVal e As MailMessageEventArgs)
    Message1.Text = "Sent mail to you to confirm the password change."
  End Sub

  Public Sub MySendMailError(ByVal Sender As Object, ByVal e As SendMailErrorEventArgs)
    Message1.Text = "Could not send mail to confirm the password change."
    
    ' The MySamplesSite event source has already been created by an administrator.
    Dim myLog As System.Diagnostics.EventLog
    myLog = new System.Diagnostics.EventLog
    myLog.Log = "Application"
    myLog.Source = "MySamplesSite"
    myLog.WriteEntry("Sending mail via SMTP failed with the following error: " & e.Exception.Message.ToString(), System.Diagnostics.EventLogEntryType.Error)

    e.Handled = True
    
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>ChangePassword including a SendMailError Event</title>
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
      OnSendingMail="MySendingMail" 
      OnSendMailError="MySendMailError" 
      ContinueDestinationPageUrl="~/Default.aspx" >
      <MailDefinition 
        BodyFileName="~\MailFiles\ChangePasswordMail.htm" 
        Subject="Activity information for you">
        <EmbeddedObjects>
          <asp:EmbeddedMailObject Name="LoginGif" Path="~\MailFiles\Login.gif" />
          <asp:EmbeddedMailObject Name="PrivacyNoticeTxt" Path="~\MailFiles\PrivacyNotice.txt" />
        </EmbeddedObjects>
      </MailDefinition>
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