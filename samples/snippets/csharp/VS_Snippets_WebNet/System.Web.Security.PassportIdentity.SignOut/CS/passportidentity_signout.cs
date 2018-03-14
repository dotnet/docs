using System;
using System.Web.Security;

namespace myPassportExamples
{ 

public class myPassportIdentity
{
public static void Main()
{
// <snippet1>
// This example demonstrates how to sign a user out of Passport.
// local GIF file that the user is redirected to.
string signOutGifFile = "signout.gif";
// Signs the user out of their Passport Profile and displays the SignOut.gif file.
System.Web.Security.PassportIdentity.SignOut(signOutGifFile);
// </snippet1>
}
}
}
