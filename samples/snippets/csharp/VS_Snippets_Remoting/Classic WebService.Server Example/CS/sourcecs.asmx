// <Snippet1>
<%@ WebService Language="C#" Class="Util" %>
 
 using System.Web.Services;
 
 public class Util: WebService {
    [ WebMethod(Description="Obtains the Server Computer Name",EnableSession=false)]
    public string GetMachineName() {
       return Server.MachineName;
    }
 }
    
// </Snippet1>
