<%@ Import Namespace="System.Web.Profile" %>
<script language="VB" runat="server">

'<Snippet12>
Public Sub Profile_Personalize(sender As Object, args As ProfileEventArgs)
  Dim userProfile As ProfileCommon

  If User Is Nothing Then Return

  userProfile = CType(ProfileBase.Create(User.Identity.Name), ProfileCommon)

  If User.IsInRole("Administrators") Then
    userProfile = userProfile.GetProfile("Administrator")
  Else
    If User.IsInRole("Users") Then
      userProfile = userProfile.GetProfile("User")
    Else
      userProfile = userProfile.GetProfile("Guest")
    End If
  End If

  If Not userProfile Is Nothing Then _
    args.Profile = userProfile
End Sub
'</Snippet12>
</script>