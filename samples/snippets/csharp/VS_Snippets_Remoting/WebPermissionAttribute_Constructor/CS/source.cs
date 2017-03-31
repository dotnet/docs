// System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;


using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.IO;

public class WebPermissionAttribute_AcceptConnect
{

// <Snippet1>

  // Set the declarative security for the URI.
  [WebPermission(SecurityAction.Deny, Connect = @"http://www.contoso.com/")]
  public void Connect() 
  {
    // Throw an exception.   
    try
    {
      HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception : " + e.ToString());
    }
// </Snippet1>
           
 }



 static void Main()
 {
    try
    {
      WebPermissionAttribute_AcceptConnect myWebAttrib = new WebPermissionAttribute_AcceptConnect();
      myWebAttrib.Connect();
    }
    catch(SecurityException e)
    {
      Console.WriteLine("Security Exception raised : "+e.Message);
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception raised : "+ e.Message);        
    }
  }
}
