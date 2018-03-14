<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void Page_Load()
{

  try
  {
    RolePrincipal r = (RolePrincipal)User;

    IsCachedLabel.Text     = r.IsRoleListCached.ToString();
    CacheChangedLabel.Text = r.CachedListChanged.ToString();
    ExpiredLabel.Text      = r.Expired.ToString();
    VersionLabel.Text      = r.Version.ToString();
    IssueDateLabel.Text    = r.IssueDate.ToString();
    ExpireDateLabel.Text   = r.ExpireDate.ToString();
    CookiePathLabel.Text   = r.CookiePath;

    Msg.Text = "";
  }
  catch (InvalidCastException)
  {
    Msg.Text = "User is not of type RolePrincipal. Are roles enabled?";
  }

}

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Role Information</title>
</head>
<body>

<form id="form1" runat="server">

  Role Information for <b><%=User.Identity.Name%></b>.<br />

  <asp:Label id="Msg" runat="Server" ForeColor="maroon" /><br />

  <table border="1" cellpadding="4" cellspacing="4">
    <tr>
      <td>IsRoleListCached</td>
      <td><asp:Label id="IsCachedLabel" runat="Server" /></td>
    </tr>
    <tr>
      <td>CachedListChanged</td>  
      <td><asp:Label id="CacheChangedLabel" runat="Server" /></td>
    </tr>
    <tr>
      <td>Expired</td>
      <td><asp:Label id="ExpiredLabel" runat="Server" /></td>
    </tr>
    <tr>
      <td>Version</td>
      <td><asp:Label id="VersionLabel" runat="Server" /></td>
    </tr>
    <tr>
      <td>IssueDate</td>
      <td><asp:Label id="IssueDateLabel" runat="Server" /></td>
    </tr>
    <tr>
      <td>ExpireDate</td>
      <td><asp:Label id="ExpireDateLabel" runat="Server" /></td>
    </tr>
    <tr>
      <td>CookiePath</td>
      <td><asp:Label id="CookiePathLabel" runat="Server" /></td>
    </tr>
  </table>

</form>


</body>
</html>
<!-- </Snippet1> -->