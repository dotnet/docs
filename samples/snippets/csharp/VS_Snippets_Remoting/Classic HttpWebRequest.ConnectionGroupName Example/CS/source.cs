using System;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using System.Text;

public class TestClass: Page
{

 public static int Main(String[] args)
 {
// <Snippet1>  
  // Create a secure group name.
  SHA1Managed Sha1 = new SHA1Managed();
  Byte[] updHash = Sha1.ComputeHash(Encoding.UTF8.GetBytes("username" + "password" +  "domain"));
  String secureGroupName = Encoding.Default.GetString(updHash);

  // Create a request for a specific URL.
  WebRequest myWebRequest=WebRequest.Create("http://www.contoso.com");

  // Set the authentication credentials for the request.      
  myWebRequest.Credentials = new NetworkCredential("username", "password", "domain"); 
  myWebRequest.ConnectionGroupName = secureGroupName;

  // Get the response.
  WebResponse myWebResponse=myWebRequest.GetResponse();

  // Insert the code that uses myWebResponse here.

  // Close the response.
  myWebResponse.Close();
      
// </Snippet1>

  return 0;
 }
}
