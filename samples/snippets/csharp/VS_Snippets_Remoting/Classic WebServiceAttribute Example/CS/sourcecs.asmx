// <Snippet1>
<%@ WebService Language="C#" Class= "ServerVariables"%>
 
 using System;
 using System.Web.Services;
 
 [ WebService(Description="Common Server Variables",Namespace="http://www.contoso.com/")]
 public class ServerVariables: WebService {
 
 
    [ WebMethod(Description="Obtains the Server Computer Name",EnableSession=false)]
    public string GetMachineName() {
       return Server.MachineName;
    }   
 }
 
// </Snippet1>
