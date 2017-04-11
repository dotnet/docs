// <Snippet1>
<%@ WebService Language="C#" class="MyUser" %>
 
 using System.Web.Services;
 using System.Web.Services.Protocols;
 
 public class MyUser : WebService {
 
      [ SoapDocumentMethod(Action="http://www.contoso.com/GetUserName")]
      public string GetUserName() {
       return User.Identity.Name;
      }
 }

// </Snippet1>
