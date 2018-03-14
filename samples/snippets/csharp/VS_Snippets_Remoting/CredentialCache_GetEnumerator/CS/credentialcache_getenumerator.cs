// System.Net.CredentialCache.GetEnumerator

/*This program demontrates the  'GetEnumerator' method of the CredentialCache class.
It takes an URL, creates a 'WebRequest' object for the Url. The program stores a known set of credentials
in a credential cache which is then bound to the request. If the url requested has it's credentials in the cache 
the response will be OK . 'GetEnumerator' method is used to enlist all the credentials stored in the
'CredentialCache' object.
*/

using System;
using System.Net;
using System.Collections;

class CredentialCacheSnippet {
 
    public static void Main(string[] args) 
    {
        if (args.Length <4) {
            Console.WriteLine("\n Usage:");
              Console.WriteLine("\n CredentialCache_GetEnumerator <url> <User Name> <Password> <Domain Name>");
              Console.WriteLine("\n Example: CredentialCache_GetEnumerator http://www.microsoft.com  Catherine cath$ microsoft");
            }
        else if(args.Length ==4){GetPage(args[0],args[1],args[2],args[3]);}
        else{
        Console.WriteLine("\n Invalid arguments.");
        return;
        }             

        Console.WriteLine("Press any key to continue...");Console.ReadLine();
        return;
    }
// <Snippet1>
   public static void GetPage(string url,string userName,string password,string domainName)
     {
        try 
        {
            CredentialCache myCredentialCache = new CredentialCache();
            // Dummy Credentials used here.             
            myCredentialCache.Add(new Uri("http://microsoft.com/"),"Basic", new NetworkCredential("user1","passwd1","domain1"));
            myCredentialCache.Add(new Uri("http://msdn.com/"),"Basic", new NetworkCredential("user2","passwd2","domain2"));

            myCredentialCache.Add(new Uri(url),"Basic", new NetworkCredential(userName,password,domainName));    
            // Creates a webrequest with the specified url.                 
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Credentials = myCredentialCache;            
            IEnumerator listCredentials = myCredentialCache.GetEnumerator();
            
            Console.WriteLine("\nDisplaying credentials stored in CredentialCache: ");
            while(listCredentials.MoveNext())
            {
                Display((NetworkCredential)listCredentials.Current);
            }
            Console.WriteLine("\nNow Displaying the same using 'foreach' : ");
            // Can use foreach with CredentialCache(Since GetEnumerator function of IEnumerable has been implemented by 'CredentialCache' class.
            foreach(NetworkCredential credential in myCredentialCache)
                Display(credential);
            // Send the request and waits for response.
         WebResponse myWebResponse = myWebRequest.GetResponse(); 
            
           // Process response here.
            
           Console.WriteLine("\nResponse Received.");
            myWebResponse.Close();
                                  
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
  public static void Display(NetworkCredential credential)
  {
    Console.WriteLine("\n\tUsername : {0} ,Password : {1} ,Domain : {2}",credential.UserName,credential.Password,credential.Domain);
  }
// </Snippet1>
}
