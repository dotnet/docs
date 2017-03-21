// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Set a string variable to the Passport member name from the cookie.
string sMemberName = newPass.Name;