<!-- <Snippet7> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<script runat="server">

Dim rolesArray() As String

Public Sub Page_Load()
  Dim r As RolePrincipal = CType(User, RolePrincipal)
  rolesArray = r.GetRoles()
  UserRolesGrid.DataSource = rolesArray
  UserRolesGrid.DataBind()

  Heading.Text = "Roles for " & User.Identity.Name
End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Sample: View Roles</title>
</head>
<body>

<form runat="server" id="PageForm">

  <h3><asp:Label id="Heading" runat="server" /></h3>

  <table border="0" cellspacing="4">
    <tr>
      <td valign="top"><asp:GridView runat="server" CellPadding="4" id="UserRolesGrid" 
                                     AutoGenerateColumns="false" Gridlines="None" 
                                     CellSpacing="0" >
                         <Columns>
                           <asp:TemplateField >
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
<!-- </Snippet7> -->