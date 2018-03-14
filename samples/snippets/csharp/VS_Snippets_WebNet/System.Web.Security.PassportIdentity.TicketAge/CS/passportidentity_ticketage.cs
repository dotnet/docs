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
// Build a string with the elapsed time since the user's ticket was last refreshed with the Passport Authority.
string sElapsedTime = "Elapsed time since ticket refresh: " + newPass.TicketAge.ToString() + " seconds.";
// </snippet1>
}
}
}
