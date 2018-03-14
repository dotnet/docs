<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Page_Load()
  ProviderNameLabel.Text        = ProfileManager.Provider.Name
  ProviderTypeLabel.Text        = ProfileManager.Provider.GetType().ToString()
  ProviderDescriptionLabel.Text = ProfileManager.Provider.Description
End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Default Profile Provider Information</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Default Profile Provider Information</h3>

  <table border="1" cellpadding="2" cellspacing="2">
    <tr>
      <td>Provider Name</td>
      <td><asp:Label id="ProviderNameLabel" runat="server" /></td>
    </tr>
    <tr>
      <td>Provider Type</td>
      <td><asp:Label id="ProviderTypeLabel" runat="server" /></td>
    </tr>
    <tr>
      <td>Provider Description</td>
      <td><asp:Label id="ProviderDescriptionLabel" runat="server" /></td>
    </tr>
  </table>


</form>

</body>
</html>
<!-- </Snippet2> -->