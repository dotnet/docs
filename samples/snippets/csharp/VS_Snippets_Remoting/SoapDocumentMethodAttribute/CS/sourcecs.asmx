// <Snippet1>
<%@ WebService Language="C#" class="MyUser" %>
 using System;
 using System.Web.Services;
 using System.Web.Services.Protocols;
 
 public class MyUser : WebService {
 
       [ SoapDocumentMethod(Action="http://www.contoso.com/Sample", 
           RequestNamespace="http://www.contoso.com/Request",
           RequestElementName="GetUserNameRequest",
           ResponseNamespace="http://www.contoso.com/Response",
           ResponseElementName="GetUserNameResponse")]
      [ WebMethod(Description="Obtains the User Name") ]
      public UserName GetUserName() {
           string temp;
           int pos;
           UserName NewUser = new UserName();
           
           // Get the full user name, including the domain name if applicable.
           temp = User.Identity.Name;
 
           // Deterime whether the user is part of a domain by searching for a backslash.
           pos = temp.IndexOf("\\");
           
           // Parse the domain name out of the string, if one exists.
           if (pos <= 0)
                 NewUser.Name = User.Identity.Name;
           else {
               NewUser.Name = temp.Remove(0,pos+1);
                 NewUser.Domain = temp.Remove(pos,temp.Length-pos);
           } 
       return NewUser;
      }
 
 }   
 
 public class UserName {
 
     public string Name;
     public string Domain;
 }

// </Snippet1>
