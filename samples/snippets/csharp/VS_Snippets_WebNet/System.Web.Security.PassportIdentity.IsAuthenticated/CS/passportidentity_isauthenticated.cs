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
// Set the string sIsAuth to the users SignIn status (a boolean) converted to a string.
String sIsAuth = newPass.IsAuthenticated.ToString();
// </snippet1>
}
}
}
