<!-- <snippet1> -->

<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Hosting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  protected void Page_PreRender(object sender, EventArgs e)
  {
    ApplicationManager appManager = ApplicationManager.GetApplicationManager();
    ApplicationInfo [] appInfo = appManager.GetRunningApplications();
    GridView1.DataSource = appInfo;
    GridView1.DataBind();
  }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>Application Info sample</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
  </form>
</body>
</html>
<!-- </snippet1> -->
