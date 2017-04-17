<%@ Page Language="VB" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Collections.Specialized" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

Public Sub Page_Load()
  Snippet1()
  Snippet2()
  Snippet3()
End Sub

Public Sub Snippet1()

'<Snippet1>
' Identify the connection string for the SqlRoleProvider.
Dim config As NameValueCollection = New NameValueCollection()
config.Add("connectionStringName", "SqlServices")

' Create and Initialize the SqlRoleProvider.
Dim p As SqlRoleProvider = New SqlRoleProvider()
p.Initialize("MySqlProvider", config)

' Create the RoleProviderCollection and add the SqlRoleProvider.
Dim coll As RoleProviderCollection = New RoleProviderCollection()
coll.Add(p)
'</Snippet1>

  ProvidersListBox.DataSource = coll
  ProvidersListBox.DataBind()
End Sub

Public Sub Snippet2()

'<Snippet2>
Dim p As SqlRoleProvider = CType(Roles.Providers("SqlProvider"), SqlRoleProvider)
DescriptionLabel.Text = p.Description
'</Snippet2>

End Sub

Public Sub Snippet3()

'<Snippet3>
Dim providers As RoleProviderCollection = Roles.Providers
Dim copiedProviders(providers.Count) As RoleProvider
providers.CopyTo(copiedProviders, 0)
'</Snippet3>

End Sub

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Sample: Provider List</title>
</head>
<body>

<form id="form1" runat="server">
  <h3>Provider List</h3>

      <asp:ListBox id="ProvidersListBox" DataTextField="Name" 
                   Rows="8" runat="server" />

      <asp:Label id="DescriptionLabel" runat="server" />
</form>

</body>
</html>
