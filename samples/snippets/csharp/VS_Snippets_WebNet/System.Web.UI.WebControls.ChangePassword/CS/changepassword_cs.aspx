<!-- <snippet1>-->
<%@ Page Language="C#" CodeFile="ChangePassword.cs" Inherits="ChangePassword_cs_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>ChangePassword using code-behind including a SendMailError Event</title>
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