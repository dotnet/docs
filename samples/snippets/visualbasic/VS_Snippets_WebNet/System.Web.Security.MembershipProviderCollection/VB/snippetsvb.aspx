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
' Identify the connection string for the SqlMembershipProvider.
Dim config As NameValueCollection = New NameValueCollection()
config.Add("connectionStringName", "SqlServices")

' Create and Initialize the SqlMembershipProvider.
Dim p As SqlMembershipProvider = New SqlMembershipProvider()
p.Initialize("MySqlProvider", config)

' Create the MembershipProviderCollection and add the SqlMembershipProvider.
Dim coll As MembershipProviderCollection = New MembershipProviderCollection()
coll.Add(p)
'</Snippet1>

  ProvidersListBox.DataSource = coll
  ProvidersListBox.DataBind()
End Sub

Public Sub Snippet2()

'<Snippet2>
Dim p As SqlMembershipProvider = CType(Membership.Providers("SqlProvider"), SqlMembershipProvider)
PasswordFormatLabel.Text = p.PasswordFormat.ToString()
'</Snippet2>

End Sub

Public Sub Snippet3()

'<Snippet3>
Dim providers As MembershipProviderCollection = Membership.Providers
Dim copiedProviders(providers.Count) As MembershipProvider
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

      <asp:Label id="PasswordFormatLabel" runat="server" />
</form>

</body>
</html>
