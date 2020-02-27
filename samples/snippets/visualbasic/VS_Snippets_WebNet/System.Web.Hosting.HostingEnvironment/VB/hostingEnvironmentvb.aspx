<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Hosting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    appID.Text = HostingEnvironment.ApplicationID
    appPPath.Text = HostingEnvironment.ApplicationPhysicalPath
    appVPath.Text = HostingEnvironment.ApplicationVirtualPath
    siteName.Text = HostingEnvironment.SiteName
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Hosting Environment Sample</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table>
        <tr>
          <td colspan="2">
            <b>HostingEnvironment Properties</b></td>
        </tr>
        <tr>
          <td>
            Application ID:
          </td>
          <td>
            <asp:Label ID="appID" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            Application Physical Path:
          </td>
          <td>
            <asp:Label ID="appPPath" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            Application Virtual Path:
          </td>
          <td>
            <asp:Label ID="appVPath" runat="server" />
          </td>
        </tr>
        <tr>
          <td>
            Site Name:
          </td>
          <td>
            <asp:Label ID="siteName" runat="server" />
          </td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
<!-- </Snippet1> -->
