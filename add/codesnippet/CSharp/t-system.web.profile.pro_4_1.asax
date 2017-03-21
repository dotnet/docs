public void Profile_ProfileAutoSaving(object sender, ProfileAutoSaveEventArgs args)
{
  if (Profile.Cart.HasChanged)
    args.ContinueWithProfileAutoSave = true;
  else
    args.ContinueWithProfileAutoSave = false;
}