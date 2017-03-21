// Declare new PassportIdendity object as variable newPass.
System.Web.Security.PassportIdentity newPass = new System.Web.Security.PassportIdentity();
// Build a string with the elapsed time since the user's ticket was last refreshed with the Passport Authority.
string sElapsedTime = "Elapsed time since ticket refresh: " + newPass.TicketAge.ToString() + " seconds.";