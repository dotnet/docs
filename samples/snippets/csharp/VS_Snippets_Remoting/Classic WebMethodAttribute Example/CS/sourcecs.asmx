// <Snippet1>
<%@ WebService Language="C#" Class="Util"%>
    using System;
    using System.Web.Services;
    public class Util: WebService {
       public string GetUserName() {
          return User.Identity.Name;
       }
    
       [ WebMethod(Description="Obtains the Server Machine Name",
       EnableSession=true)]
       public string GetMachineName() {
          return Server.MachineName;
       }
    }

// </Snippet1>
