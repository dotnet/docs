// System.Net.WebPermission.WebPermission(NetworkAccess,Regex);
/*
   This program demonstrates the  'WebPermission(NetworkAccess,Regex)' constructor of 'WebPermission' class.
   First  a 'Regex' object is created that will accept all the urls which is having the hostfragment of
   'www.contoso.com'.Then a 'WebPermission' object created by passing the 'NetworkAccess' permission and 
   'Regex' object as parameters. It  checks the 'WebPermission' for all the url's having the host fragment 
    as 'www.contoso.com'.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Collections;

class WebPermission_regexConstructor {

    static void Main()
    {
      try
      {
        WebPermission_regexConstructor myWebPermissionRegex = new WebPermission_regexConstructor();
        myWebPermissionRegex.CreateRegexConstructor();
      }
      catch(SecurityException e) 
      {
        Console.WriteLine("SecurityException raised: " + e.Message);
      }
      catch(Exception e)
      {
        Console.WriteLine("Exception raised: " + e.Message);
      }         
  }

    public void CreateRegexConstructor()
    {

// <Snippet1>

      // Create an instance of 'Regex' that accepts all  URL's containing the host 
      // fragment 'www.contoso.com'.
      Regex myRegex = new Regex(@"http://www\.contoso\.com/.*");

     // Create a WebPermission that gives the permissions to all the hosts containing 
     // the same fragment.
     WebPermission myWebPermission = new WebPermission(NetworkAccess.Connect,myRegex);
        
     // Checks all callers higher in the call stack have been granted the permission.
     myWebPermission.Demand();
      
// </Snippet1>

     Console.WriteLine("Attribute and Values of WebPermission are : \n");
     // Display the Attributes,Values and Children of the XML encoded copied instance.
     PrintKeysAndValues(myWebPermission.ToXml().Attributes,myWebPermission.ToXml().Children);

   }

    private void PrintKeysAndValues(Hashtable myHashtable,IEnumerable myList) 
     {
       // Get the enumerator that can iterate through Hashtable.
       IDictionaryEnumerator myEnumerator = myHashtable.GetEnumerator();
       Console.WriteLine("\t-ATTRIBUTES-\t-VALUE-");
       while (myEnumerator.MoveNext())
       {Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);}
       Console.WriteLine();

       IEnumerator myEnumerator1 = myList.GetEnumerator();
       Console.WriteLine("\nThe Children are : ");
       while (myEnumerator1.MoveNext())
       {Console.Write("\t{0}", myEnumerator1.Current);}
    }
 }