// <Snippet1>
<%@ WebService Language="C#" class= "ServerVariables"%>
 
 using System;
 using System.Web.Services;
 using System.Web.Services.Protocols;
 
 [ WebService(Namespace="http://www.contoso.com/")]
 public class ServerVariables: WebService {
    [ WebMethod(Description="Returns the time as stored on the Server",EnableSession=false)]
    public string Time() {
       return Context.Timestamp.TimeOfDay.ToString();
    }
 }
 
// </Snippet1>
