// System.Net.WebPermissionAttribute.Connect;System.Net.WebPermissionAttribute.Accept;

// Demonstrate how to use the WebPermissionAttribute to specify an allowable ConnectPattern.


using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.IO;

public class WebPermissionAttribute_AcceptConnect{

// <Snippet1>
// <Snippet2>

	// Deny access to a specific resource by setting the ConnectPattern property. 
   [WebPermission(SecurityAction.Deny, ConnectPattern=@"http://www\.contoso\.com/")]

public void Connect() 
     {
        // Create a Connection.  
        HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
        Console.WriteLine("This line should never be printed");
     }

// </Snippet2>
// </Snippet1>

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
