// <Snippet1>
<%@ WebService Language="C#" class= "ServerVariables"%>
 
 using System;
 using System.Web.Services;
 using System.Web.Services.Protocols;
 
 [ WebService(Description="Server Variables",
 Namespace="http://www.contoso.com/")]
 public class ServerVariables: WebService {
    [ SoapDocumentMethod(Action="http://www.contoso.com/Time")]
    [ WebMethod(Description="Returns the time as stored on the Server",EnableSession=false)]
    public string Time() {
       return Context.Timestamp.TimeOfDay.ToString();
    }
 }
 
// </Snippet1>
