// System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Connect;

// Demonstrate how to use the WebPermissionAttribute  ConnectPattern property.

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.IO;
using System.Text.RegularExpressions;

public class WebPermissionAttribute_Connect
{
  //<Snippet1>	
  
  // Set the WebPermissionAttribute  ConnectPattern property.
  [WebPermission(SecurityAction.Deny, ConnectPattern=@"http://www\.contoso\.com/Private/.*")]

public static void CheckConnectPermission(string uriToCheck) 
{
	WebPermission permissionToCheck = new WebPermission();
	permissionToCheck.AddPermission(NetworkAccess.Connect, uriToCheck);
	permissionToCheck.Demand();
}

public static void demoDenySite() {
	//Pass the security check.
	CheckConnectPermission("http://www.contoso.com/Public/page.htm");
	Console.WriteLine("Public page has passed Connect permission check");

	try 
	{
		//Throw a SecurityException.
		CheckConnectPermission("http://www.contoso.com/Private/page.htm");
		Console.WriteLine("This line will not be printed");
	}
	catch (SecurityException e) 
	{
		Console.WriteLine("Expected exception" + e.Message);
	}

 }

//</Snippet1>
		static void Main()
		{
             demoDenySite();
			
		}
	}
