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
// Build a string with the elapsed time since the user last signed in with the Passport Authority.
string sElapsedTimeSignIn = "Elapsed time since SignIn: " + newPass.TimeSinceSignIn.ToString() + " seconds.";
// </snippet1>
}
}
}
