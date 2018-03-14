// <Snippet1>
<%@ WebService Language="C#" Class="Util" %>
 
 using System.Web.Services;
 
 public class Util: WebService {
      [ WebMethod(Description="Obtains the User Name",EnableSession=false) ]
      public string GetUserName() {
         return User.Identity.Name;
      }
 }
    
// </Snippet1>
