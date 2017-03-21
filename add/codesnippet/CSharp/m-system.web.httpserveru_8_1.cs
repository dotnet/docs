Exception LastError;
String ErrMessage;
 
LastError = Server.GetLastError();

if (LastError != null)
   ErrMessage = LastError.Message;
else
   ErrMessage = "No Errors";

Response.Write("Last Error = " + ErrMessage);
   