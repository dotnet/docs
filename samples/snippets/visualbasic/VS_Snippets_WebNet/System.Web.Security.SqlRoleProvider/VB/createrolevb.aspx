<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Dim rolesArray() As String

Public Sub Page_Load(sender As Object, args As EventArgs)

  If Not IsPostBack Then
    ' Bind roles to GridView.

    rolesArray = Roles.GetAllRoles()
    RolesGrid.DataSource = rolesArray
    RolesGrid.DataBind()
  End If

End Sub

Public Sub CreateRole_OnClick(sender As Object, args As EventArgs)

  Dim createRole As String = RoleTextBox.Text

  Try
    If Roles.RoleExists(createRole) Then
      Msg.Text = "Role '" & Server.HtmlEncode(createRole) & "' already exists. Please specify a different role name."
      Return
    End If

    Roles.CreateRole(createRole)

    Msg.Text = "Role '" & Server.HtmlEncode(createRole) & "' created."

    ' Re-bind roles to GridView.

    rolesArray = Roles.GetAllRoles()
    RolesGrid.DataSource = rolesArray
    RolesGrid.DataBind()
  Catch
    Msg.Text = "Role '" & Server.HtmlEncode(createRole) & "' <u>not</u> created."
  End Try

End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Create Role</title>
</head>
<body>

<form runat="server" id="PageForm">
  <h3>Create a Role</h3>

  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  Role name: 

  <asp:TextBox id="RoleTextBox" runat="server" />

  <asp:Button Text="Create Role" id="CreateRoleButton"
              runat="server" OnClick="CreateRole_OnClick" />

  <br />

  <asp:GridView runat="server" CellPadding="2" id="RolesGrid" 
                Gridlines="Both" CellSpacing="2" AutoGenerateColumns="false" >
    <HeaderStyle BackColor="navy" ForeColor="white" />
    <Columns>
      <asp:TemplateField HeaderText="Roles" >
        <ItemTemplate>
          <%# Container.DataItem.ToString() %>
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
   </asp:GridView>
</form>

</body>
</html>
<!-- </Snippet1> -->