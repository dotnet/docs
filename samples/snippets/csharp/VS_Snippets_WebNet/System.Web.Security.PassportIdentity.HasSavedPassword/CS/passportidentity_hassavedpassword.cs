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
// Set a string variable that indicates whether the user has a valid Passport ticket.
String sHasTick = newPass.HasTicket.ToString();
// </snippet1>
}
}
}
