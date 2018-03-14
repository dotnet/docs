// System.Net.CredentialCache.Add;System.Net.CredentialCache.CredentialCache();
// System.Net.CredentialCache.Remove;System.Net.CredentialCache.

/*This program demontrates the  'Remove' method, 'Add' method and 'CredentialCache'
constructor of the 'CredentialCache' class.It takes an URL  creates a 'WebRequest' object for the Url. 
The program stores a known set of credentials in a credential cache and removes a credential when it 
is no longer needed.
*/

using System;
using System.Net;

class CredentialCacheSnippet {
     public static void Main(string[] args) 
     {    
        if (args.Length <4) {
        Console.WriteLine("\n Usage:");
        Console.WriteLine("\n CredentialCache_Add_Remove <Url> <User Name> <Password> <Domain Name>");
        Console.WriteLine("\n Example: CredentialCache_Add_Remove http://www.microsoft.com  Catherine cath$ microsoft");
        }
        else if(args.Length ==4){GetPage(args[0],args[1],args[2],args[3]);}
        else{
        Console.WriteLine("\nInvalid arguments.");
        return;
        }             

        Console.WriteLine(" Press any key to continue...");Console.ReadLine();
        return;
    }
  public static void GetPage(string url,string userName,string password,string domainName)
   {
      try 
      {
// <Snippet1>
// <Snippet2>
        CredentialCache myCredentialCache = new CredentialCache();
        // Used Dummy names as credentials. They are to be replaced by credentials applicable locally.
        myCredentialCache.Add(new Uri("http://www.microsoft.com/"),"Basic", new NetworkCredential("user1","passwd1","domain1"));                    
        myCredentialCache.Add(new Uri("http://www.msdn.com/"),"Basic", new NetworkCredential("user2","passwd2","domain2"));
        myCredentialCache.Add(new Uri(url),"Basic", new NetworkCredential(userName,password,domainName));                            
        Console.WriteLine("\nAdded your credentials to the program's CredentialCache");
// </Snippet2>
// <Snippet3>
        // Create a webrequest with the specified url. 
        WebRequest myWebRequest = WebRequest.Create(url); 
        myWebRequest.Credentials = myCredentialCache;
        Console.WriteLine("\nLinked CredentialCache to your request.");
        // Send the request and wait for response.
        WebResponse myWebResponse = myWebRequest.GetResponse(); 
// </Snippet1>

        // Process response here.

        Console.Write("Response received successfully.");
        // Call 'Remove' method to dispose credentials for current Uri as not required further.
        myCredentialCache.Remove(myWebRequest.RequestUri,"Basic");
        Console.WriteLine("\nYour credentials have now been removed from the program's CredentialCache");
        myWebResponse.Close();        
// </Snippet3>
    } 
    catch(WebException e) 
    {
          if (e.Response != null)
              Console.WriteLine("\r\nFailed to obtain a response. The following error occured : {0}",((HttpWebResponse)(e.Response)).StatusDescription); 
          else
              Console.WriteLine("\r\nFailed to obtain a response. The following error occured : {0}",e.Status); 
    }
    catch(Exception e)
    {
        Console.WriteLine("\nThe following exception was raised : {0}",e.Message);
    }
  } 
}
