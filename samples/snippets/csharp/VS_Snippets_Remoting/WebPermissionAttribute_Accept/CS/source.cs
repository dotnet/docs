// System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;

/*
 * Demonstrate how to use the WebPermissionAttribute to specify the Accept property.
*/


using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.IO;

public class WebPermissionAttribute_AcceptConnect{
//<Snippet1>	


  
// Deny access to a specific resource by setting the Accept property.
[WebPermission(SecurityAction.Deny, Accept=@"http://www.contoso.com/Private.htm")]

public static void CheckAcceptPermission(string uriToCheck) 
{
	WebPermission permissionToCheck = new WebPermission();
	permissionToCheck.AddPermission(NetworkAccess.Accept, uriToCheck);
	permissionToCheck.Demand();
}

public static void demoDenySite() 
{
	//Pass the security check when accessing allowed resources.
	CheckAcceptPermission("http://www.contoso.com/");
	Console.WriteLine("Public page has passed Accept permission check");

	try 
	{
		//Throw a SecurityException when trying to access not allowed resources.
		CheckAcceptPermission("http://www.contoso.com/Private.htm");
		Console.WriteLine("This line will not be printed");
	}
	catch (SecurityException e) 
	{
		Console.WriteLine("Exception trying to access private resource:" + e.Message);
	}

 }

//</Snippet1>
		static void Main()
		{
             demoDenySite();
			
		}
	}
