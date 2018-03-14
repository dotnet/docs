<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

string[] rolesArray;

public void Page_Load(object sender, EventArgs args)
{
  if (!IsPostBack)
  {
    // Bind roles to GridView.

    rolesArray = Roles.GetAllRoles();
    RolesGrid.DataSource = rolesArray;
    RolesGrid.DataBind();
  }
}

public void CreateRole_OnClick(object sender, EventArgs args)
{
  string createRole = RoleTextBox.Text;

  try
  {
    if (Roles.RoleExists(createRole))
    {
      Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' already exists. Please specify a different role name.";
      return;
    }

    Roles.CreateRole(createRole);

    Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' created.";

    // Re-bind roles to GridView.

    rolesArray = Roles.GetAllRoles();
    RolesGrid.DataSource = rolesArray;
    RolesGrid.DataBind();
  }
  catch (Exception e)
  {
    Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' <u>not</u> created.";
    Response.Write(e.ToString());
  }

}

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