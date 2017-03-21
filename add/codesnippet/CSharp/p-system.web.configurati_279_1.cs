
// Get the passport redirect URL
string redirectUrl = passport.RedirectUrl;

// Set passport redirect Url.
passport.RedirectUrl = "passportLogin.aspx";

if (!authenticationSection.SectionInformation.IsLocked)
  configuration.Save();
