<!-- <Snippet6> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Profile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Page_Load()
  TotalLabel.Text = ProfileManager.GetNumberOfProfiles(ProfileAuthenticationOption.All).ToString()
  GetProfiles()
End Sub

Private Sub GetProfiles()
  ProfileGrid.DataSource = ProfileManager.GetAllProfiles(ProfileAuthenticationOption.All)
  ProfileGrid.DataBind()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Find Profiles</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Profile List</h3>

  <asp:Label id="TotalLabel" runat="server" text="0" /> Profiles found.<br />

  <asp:GridView id="ProfileGrid" runat="server"
                CellPadding="2" CellSpacing="1" Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:GridView>

</form>

</body>
</html>
<!-- </Snippet6> -->