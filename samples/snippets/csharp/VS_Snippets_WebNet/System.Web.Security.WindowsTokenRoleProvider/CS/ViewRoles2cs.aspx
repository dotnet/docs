<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

string[] rolesArray;

public void Page_Load()
{
  Msg.Text = "";

  WindowsPrincipal p = (WindowsPrincipal)System.Threading.Thread.CurrentPrincipal;

  if (!p.IsInRole(WindowsBuiltInRole.Administrator))
  {
    Msg.Text = "You are not authorized to view user roles.";
    return;
  }


  // Bind roles to GridView.

  try
  {
    rolesArray = Roles.GetRolesForUser(User.Identity.Name);
  }
  catch (HttpException e)
  {
    Msg.Text = "There is no current logged on user. Role membership cannot be verified.";
    return;
  }

  UserRolesGrid.DataSource = rolesArray;
  UserRolesGrid.DataBind();

  UserRolesGrid.Columns[0].HeaderText = "Roles for " + User.Identity.Name;
}

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
<!-- </Snippet2> -->