<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim users As MembershipUserCollection

Public Sub Page_Load(sender As Object, args As EventArgs)
  users = Membership.GetAllUsers()
  UserGrid.DataSource = users
  UserGrid.DataBind()

  NumUsers.Text = users.Count.ToString()
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: User List</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>User List</h3>

  Number of Users: <asp:Label id="NumUsers" runat="server" /><br />

  <asp:DataGrid id="UserGrid" runat="server"
                CellPadding="2" CellSpacing="1"
                Gridlines="Both">
    <HeaderStyle BackColor="darkblue" ForeColor="white" />
  </asp:DataGrid>
</form>

</body>
</html>
<!-- </Snippet1> -->