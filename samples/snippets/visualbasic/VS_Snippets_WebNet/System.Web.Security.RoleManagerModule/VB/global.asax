<script language="VB" runat="server">
'<Snippet1>
Public Sub RoleManager_OnGetRoles(sender As Object, args As RoleManagerEventArgs)
  args.Context.Trace.Write("Roles", "Applying Role Information")
End Sub
'</Snippet1>
</script>