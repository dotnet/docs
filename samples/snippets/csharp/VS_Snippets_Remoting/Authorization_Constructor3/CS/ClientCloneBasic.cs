/* This is a client program to test the "CloneBasic" class of IAuthenticationModule_Methods_Props.dll.
 *
 * To demonstrate the functionality of CloneBasic, Client class has been made which makes
 * the webrequest for the protected resource. A site for such a protected resource
  (http://gopik/clonebasicsite/WebForm1.aspx), which would use CloneBasic authentication, has been developed. 
  Pl. see the guidelines.txt file for more  information in setting up the site at your environment.  While
  running this program make sure to refer the 'Authroization_Constructor3.dll'
 */

using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections;
using CloneBasicAuthentication;
 
namespace CloneBasicAuthenticationClient
{
 
	// To test our authentication module, we write a client class. 
	class Client
	{
		public static void Main(string[] args)
		{
			try
			{
				string url,userName,passwd,domain;
				if (args.Length < 4) 	
				{
				   // Proceed with defaults.
					Client.PrintUsage();
					Console.WriteLine("\nTo proceed with defaults values press 'y' ,press any other character to exit:");
					string option = Console.ReadLine();
					if (option == "Y" || option == "y")
					{
						url = "http://gopik/clonebasicsite/WebForm1.aspx";
						userName = "user1";
						passwd = "passwd1";
						domain = "gopik";
					}
					else
						return;
				} 
				else
				{	
					url = args[0];
					userName = args[1];
					passwd = args[2];
					domain = args[3];				
				}
				Console.WriteLine();
			
				CloneBasic authenticationModule = new CloneBasic();
				// Register CloneBasic authentication module with the system.
				AuthenticationManager.Register(authenticationModule);
				Console.WriteLine("\nSuccessfully registered our custom authentication module \"CloneBasic\" ");
				// The AuthenticationManager calls all authentication modules sequentially until one of them responds with;
				// an authorization instance. We have to unregister "Basic" here as it almost always returns an authorization;
				// thereby defeating our purpose to test CloneBasic.
				AuthenticationManager.Unregister("Basic");
		   
				IEnumerator registeredModules = AuthenticationManager.RegisteredModules; 
				Console.WriteLine("\r\nThe following authentication modules are now registered with the system");
				while(registeredModules.MoveNext())
				{
					Console.WriteLine("\r \n Module : {0}",registeredModules.Current); 
					IAuthenticationModule currentAuthenticationModule = (IAuthenticationModule)registeredModules.Current;
					Console.WriteLine("\t  CanPreAuthenticate : {0}",currentAuthenticationModule.CanPreAuthenticate); 
				}			
				// Calling Our Test Client. 
				GetPage(url,userName,passwd,domain);
			}
			catch(Exception e)
			{
				Console.WriteLine("\n The following exception was raised : {0}",e.Message);
			}
		}
		public static void PrintUsage() 
		{			
			Console.WriteLine("\r\nUsage: Try a site which requires CloneBasic(custom made) authentication as below");
			Console.WriteLine("   ClientCloneBasic URLname username password domainname");
			Console.WriteLine("\nExample:");
			Console.WriteLine("\n   ClientCloneBasic http://www.microsoft.com/net/ george george123 microsoft");
		}
		public static void GetPage(string url,string username,string passwd,string domain) 
		{
			try 
			{	
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
				NetworkCredential credentials = new NetworkCredential(username,passwd,domain);
				myHttpWebRequest.Credentials = credentials;
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				Console.WriteLine("\nRequest for protected resource {0} sent",url);
				
				Stream receiveStream = myHttpWebResponse.GetResponseStream();
				Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
				StreamReader readStream = new StreamReader( receiveStream, encode );
				Console.WriteLine("\r\nResponse stream received");
	            
				Char[] read = new Char[256];
				// Read 256 characters at a time.    
				int count = readStream.Read( read, 0, 256 );
				Console.WriteLine("Contents of the response received follows...\r\n");
				
				while (count > 0) 
				{
					// Dump the 256 characters on a string and display the string onto the console.
					Console.Write(read);
					count = readStream.Read(read, 0, 256);
				}
				Console.WriteLine("");
				// Release the resources of stream object.
				readStream.Close();
				// Release the resources of response object.
				myHttpWebResponse.Close(); 
			
			} 
			catch(WebException e) 
			{
				if(e.Response != null)
					Console.WriteLine("\r\n Exception Raised. The following error occured : {0}",((HttpWebResponse)(e.Response)).StatusDescription); 
				else
					Console.WriteLine("\r\n Exception Raised. The following error occured : {0}",e.Status); 
			}
			catch(Exception e)
			{
				Console.WriteLine("\n The following exception was raised : {0}",e.Message);
			}
		}


	} 	
}

