<!-- <Snippet4> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim rolesArray() As String
Dim users As MembershipUserCollection

Public Sub Page_Load()

  Msg.Text = ""

  Try
    If Not Roles.IsUserInRole(User.Identity.Name, "Administrators") Then
      Msg.Text = "You are not authorized to view user roles."
      UsersListBox.Visible = False
      Return
    End If
  Catch e As HttpException
    Msg.Text = "There is no current logged on user. Role membership cannot be verified."
    Return
  End Try


  If Not IsPostBack Then
    ' Bind users to ListBox.

    users = Membership.GetAllUsers()
    UsersListBox.DataSource = users
    UsersListBox.DataBind()
  End If


  ' If a user is selected, show the roles for the selected user.

  If Not UsersListBox.SelectedItem Is Nothing Then
    ' Bind roles to GridView.

    rolesArray = Roles.GetRolesForUser(UsersListBox.SelectedItem.Value)
    UserRolesGrid.DataSource = rolesArray
    UserRolesGrid.DataBind()

    UserRolesGrid.Columns(0).HeaderText = "Roles for " & UsersListBox.SelectedItem.Value
  End If

End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: View User Roles</title>
</head>
<body>

<form runat="server" id="PageForm">

  <h3>View User Roles</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <table border="0" cellspacing="4">
    <tr>
      <td valign="top"><asp:ListBox id="UsersListBox" DataTextField="Username" 
                                    Rows="8" AutoPostBack="true" runat="server" /></td>
      <td valign="top"><asp:GridView runat="server" CellPadding="4" id="UserRolesGrid" 
                                     AutoGenerateColumns="false" Gridlines="None" 
                                     CellSpacing="0" >
                         <HeaderStyle BackColor="navy" ForeColor="white" />
                         <Columns>
                           <asp:TemplateField HeaderText="Roles" >
                             <ItemTemplate>
                               <%# Container.DataItem.ToString() %>
                             </ItemTemplate>
                           </asp:TemplateField>
                         </Columns>
                       </asp:GridView></td>
    </tr>
  </table>

</form>

</body>
</html>
<!-- </Snippet4> -->