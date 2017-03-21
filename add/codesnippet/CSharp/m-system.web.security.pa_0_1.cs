// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Set a string to the URL of the appropriate Passport SignIn/SignOut authority.
string sPassportlink = newPass.LogoTag2();