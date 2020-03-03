<%@ Import Namespace="System.Web.Profile" %>
<script language="C#" runat="server">
//<Snippet1>
public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
{
  ProfileCommon anonymousProfile = Profile.GetProfile(args.AnonymousID);

  Profile.ZipCode = anonymousProfile.ZipCode;
  Profile.CityAndState = anonymousProfile.CityAndState;
  Profile.StockSymbols = anonymousProfile.StockSymbols;

  ////////
  // Delete the anonymous profile. If the anonymous ID is not 
  // needed in the rest of the site, remove the anonymous cookie.

  ProfileManager.DeleteProfile(args.AnonymousID);
  AnonymousIdentificationModule.ClearAnonymousIdentifier(); 

  // Delete the user row that was created for the anonymous user.
  Membership.DeleteUser(args.AnonymousID, true);

}
//</Snippet1>
</script>