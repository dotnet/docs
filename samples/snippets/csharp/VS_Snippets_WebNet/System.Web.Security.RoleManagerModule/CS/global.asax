<script language="c#" runat="server">
//<Snippet1>
public void RoleManager_OnGetRoles(object sender, RoleManagerEventArgs args)
{
  args.Context.Trace.Write("Roles", "Applying Role Information");
}
//</Snippet1>
</script>