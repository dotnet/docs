// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Get the name of the Passport domain associated with the current UserName.
string passportDomain = newPass.GetDomainFromMemberName(newPass.Name);