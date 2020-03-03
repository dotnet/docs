<%@ Import Namespace="System.Web.Profile" %>
<script language="C#" runat="server">

//<Snippet11>
public void Profile_ProfileAutoSaving(object sender, ProfileAutoSaveEventArgs args)
{
  if (Profile.Cart.HasChanged)
    args.ContinueWithProfileAutoSave = true;
  else
    args.ContinueWithProfileAutoSave = false;
}
//</Snippet11>
</script>