using System;
using System.Web.Security;

namespace myPassportExamples
{ 

public class myPassportIdentity
{
public static void Main()
{
// <snippet1>
// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Set a string to the URL of the appropriate Passport SignIn/SignOut authority.
string sPassportlink = newPass.LogoTag2();
// </snippet1>
}
}
}
