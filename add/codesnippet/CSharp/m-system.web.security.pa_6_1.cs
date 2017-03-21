// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Declare and set myURL variable = the URL of the appropriate Passport SignIn/SignOut Authority.
string myURL = newPass.AuthUrl();