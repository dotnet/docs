public void Profile_Personalize(object sender, ProfileEventArgs args)
{
  ProfileCommon userProfile;

  if (User == null) { return; }

  userProfile = (ProfileCommon)ProfileBase.Create(User.Identity.Name);

  if (User.IsInRole("Administrators"))
    userProfile = userProfile.GetProfile("Administrator");
  else
    if (User.IsInRole("Users"))
      userProfile = userProfile.GetProfile("User");
    else
      userProfile = userProfile.GetProfile("Guest");

  if (userProfile != null)
    args.Profile = userProfile;
}