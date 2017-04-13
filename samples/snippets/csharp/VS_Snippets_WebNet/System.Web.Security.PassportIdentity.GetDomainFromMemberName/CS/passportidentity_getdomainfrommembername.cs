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
// Get the name of the Passport domain associated with the current UserName.
string passportDomain = newPass.GetDomainFromMemberName(newPass.Name);
// </snippet1>
}
}
}
