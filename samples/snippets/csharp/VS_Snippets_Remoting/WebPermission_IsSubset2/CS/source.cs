// System.Net.WebPermission.AddPermission(NetworkAccess, regex);System.Net.WebPermission.IsSubsetOf;
/**
  * This program shows the use of the AddPermission(NetworkAccess, regex) and 
  * IsSubset methods of the WebPermission class.
  * It creates two WebPermission instances with the Connect access rights for the specified
  * URIs. The second URI being a subset of the first one.
  * Then the IsSubsetOf method is called to verify that the second URI is indeed a subset
  * of the firts one. The result of the call to the IsSubsetOf is then displayed.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;
using System.Text.RegularExpressions;

public class Sample
{

  public static void myIsSubsetExample()
  {
//<Snippet1>

    // Create the target permission.
    WebPermission targetPermission = new WebPermission();
    targetPermission.AddPermission(NetworkAccess.Connect, new Regex("www\\.contoso\\.com/Public/.*"));

    // Create the permission for a URI matching target.
    WebPermission connectPermission = new WebPermission();
    connectPermission.AddPermission(NetworkAccess.Connect, "www.contoso.com/Public/default.htm");

    //The following statement prints true.
    Console.WriteLine("Is the second URI a subset of the first one?: " + connectPermission.IsSubsetOf(targetPermission));

//</Snippet1>
  }
  public  static void Main() 
  {
    // Verify that the second URI is a subset of the first one.
    myIsSubsetExample();
  } 
}
