
using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Collections;

class WebPermissionExample 
{

  public static void MySample()
  {
// <Snippet1>

    //  Create a Regex that accepts all URLs containing the host fragment www.contoso.com.
    Regex myRegex = new Regex(@"http://www\.contoso\.com/.*");

    // Create a WebPermission that gives permissions to all the hosts containing the same host fragment.
    WebPermission myWebPermission = new WebPermission(NetworkAccess.Connect,myRegex);
    
    //Add connect privileges for a www.adventure-works.com.
    myWebPermission.AddPermission(NetworkAccess.Connect,"http://www.adventure-works.com");
    
    //Add accept privileges for www.alpineskihouse.com.
    myWebPermission.AddPermission(NetworkAccess.Accept, "http://www.alpineskihouse.com/");
    
    // Check whether all callers higher in the call stack have been granted the permission.
    myWebPermission.Demand();
    
    // Get all the URIs with Connect permission.
    IEnumerator myConnectEnum = myWebPermission.ConnectList;
    Console.WriteLine("\nThe 'URIs' with 'Connect' permission are :\n");
    while (myConnectEnum.MoveNext())
    {Console.WriteLine("\t" + myConnectEnum.Current);}
 
    // Get all the URIs with Accept permission.	  
    IEnumerator myAcceptEnum = myWebPermission.AcceptList;
    Console.WriteLine("\n\nThe 'URIs' with 'Accept' permission is :\n");
      
    while (myAcceptEnum.MoveNext())
      {Console.WriteLine("\t" + myAcceptEnum.Current);}

// </Snippet1>
   }

   public static void Main()
   {
     MySample();   
   }
 }
