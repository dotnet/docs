<%@ Import Namespace="System.Web.Profile" %>
<script language="VB" runat="server">
'<Snippet1>
Public Sub Profile_OnMigrateAnonymous(sender As Object, args As ProfileMigrateEventArgs)
  Dim anonymousProfile As ProfileCommon = Profile.GetProfile(args.AnonymousID)

  Profile.ZipCode = anonymousProfile.ZipCode
  Profile.CityAndState = anonymousProfile.CityAndState
  Profile.StockSymbols = anonymousProfile.StockSymbols

  ''''''''
  ' Delete the anonymous profile. If the anonymous ID is not 
  ' needed in the rest of the site, remove the anonymous cookie.

  ProfileManager.DeleteProfile(args.AnonymousID)
  AnonymousIdentificationModule.ClearAnonymousIdentifier()

  ' Delete the user row that was created for the anonymous user.
  Membership.DeleteUser(args.AnonymousID, True)
End Sub
'</Snippet1>
</script>