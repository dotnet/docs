// System.Net.WebPermission.AddPermission(NetworkAccess, regex);
// System.Net.WebPermission.IsSubsetOf;
/**
  * This program shows how to use the  AddPermission(NetworkAccess, regex) and 
  * IsSubset methods of WebPermission class.
  * It creates two WebPermission instances with the Connect access rights for the 
  * specified URIs.
  * For he first WebPermission instance, a Connect access right is given to the 
  * URLs with the host fragment www.microsoft.com. This is done by using
  * the AddPermission(NetworkAccess, regex) method. 
  * Then, a third WebPermission instance is created with the Connect access right to 
  * the URLs of the first and second WebPermission instances. 
  * Finally, the attributes, values and children of that instance are displayed.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;
using System.Text.RegularExpressions;

class WebPermissionIsSubset{

  static void Main() 
  {
    try
    {
      WebPermissionIsSubset myWebPermissionIsSubset = new WebPermissionIsSubset();
      myWebPermissionIsSubset.CheckSubset();
    }
    
    catch(SecurityException e) 
    {
        Console.WriteLine("SecurityException : " + e.Message);
    }
    
    catch(Exception e)
    {
        Console.WriteLine("Exception : " + e.Message);
    }    
  } 

  public void CheckSubset() 
  {
// <Snippet1>
    // Create a WebPermission.
    WebPermission myWebPermission1 = new WebPermission();

    // Allow Connect access to the specified URLs.
    myWebPermission1.AddPermission(NetworkAccess.Connect,new Regex("http://www\\.contoso\\.com/.*", 
      RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline));
     
    myWebPermission1.Demand();

// </Snippet1>
  
    // Create another WebPermission with the specified URL.  
    WebPermission myWebPermission2 = new WebPermission(NetworkAccess.Connect,"http://www.contoso.com");
    // Check whether all callers higher in the call stack have been granted the permission.
    myWebPermission2.Demand();
     
// <Snippet2>

    WebPermission myWebPermission3 = null;
    // Check which permissions have the Connect access to more number of URLs.
    if(myWebPermission2.IsSubsetOf(myWebPermission1))
    {
      Console.WriteLine("\n WebPermission2 is the Subset of WebPermission1\n");  
      myWebPermission3 = myWebPermission1;
    }
    else if(myWebPermission1.IsSubsetOf(myWebPermission2))
    {
      Console.WriteLine("\n WebPermission1 is the Subset of WebPermission2");  
      myWebPermission3 = myWebPermission2;
    }
    else
    {
      // Create the third permission.
      myWebPermission3 = (WebPermission)myWebPermission1.Union(myWebPermission2);
    }

// </Snippet2>  
    // Prints the attributes , values and childrens of XML encoded instances.

    Console.WriteLine("\nAttributes and Values of third WebPermission instance are : ");    
    PrintKeysAndValues(myWebPermission3.ToXml().Attributes,myWebPermission3.ToXml().Children);
   }

    private void PrintKeysAndValues(Hashtable myHashtable,IEnumerable myList) 
    {
     // Get the enumerator that can iterate through Hashtable.
    IDictionaryEnumerator myEnumerator = myHashtable.GetEnumerator();
    Console.WriteLine("\t-KEY-\t-VALUE-");
    while (myEnumerator.MoveNext())
      Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
    Console.WriteLine();

    IEnumerator myEnumerator1 = myList.GetEnumerator();
    Console.WriteLine("The Children are : ");
    while (myEnumerator1.MoveNext())
        Console.Write("\t{0}", myEnumerator1.Current);
    }
   }