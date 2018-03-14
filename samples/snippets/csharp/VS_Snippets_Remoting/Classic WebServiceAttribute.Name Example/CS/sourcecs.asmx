// <Snippet1>
<%@ WebService Language="C#" class= "ServerVariables"%>
 
 using System.Web.Services;
 
 [ WebService(Description="Server Variables",
              Namespace="http://www.microsoft.com/",
              Name="MyName")]
 public class ServerVariables: WebService {
    [ WebMethod(Description="Returns the time as stored on the Server",
    EnableSession=false)]
    public string Time() {
       return Context.Timestamp.TimeOfDay.ToString();
    }
 }
 
// </Snippet1>
