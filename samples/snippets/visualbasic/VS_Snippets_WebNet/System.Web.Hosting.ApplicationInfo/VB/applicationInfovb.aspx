<!-- <snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Hosting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
    Dim appManager As ApplicationManager
    appManager = ApplicationManager.GetApplicationManager()
   
    Dim appInfo As ApplicationInfo()
    appInfo = appManager.GetRunningApplications()
    
    GridView1.DataSource = appInfo
    GridView1.DataBind()
  End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html" />
  <title>Untitled Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
  </form>
</body>
</html>
<!-- </snippet1> -->