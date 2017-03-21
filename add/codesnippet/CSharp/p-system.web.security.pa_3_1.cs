// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Set a string variable that indicates whether the user has a valid Passport ticket.
String sHasTick = newPass.HasTicket.ToString();