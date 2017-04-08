// System.Net.WebPermission.WebPermission(NetworkAccess, uriString);System.Net.WebPermission.Union;

/**
  * This program shows the use of the WebPermission(NetworkAccess access,string uriString) 
  * constructor and Union method of the WebPermission' class.
  * It creates two instance of the WebPermission class with the  specified access 
  * rights to the predefined URIs.
  * It displays the attributes , values and childrens of those XML encoded 
  * instances. 
  * Then, using the Union method, it creates a third WebPermission instance 
  * via a logical union of the first two.
  * Finally, it displays the attributes , values and childrens of those XML encoded 
  * instances.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;

class WebPermissionUnion 
{

  static void Main()
  {
    try
    {
      WebPermissionUnion myWebPermissionUnion = new WebPermissionUnion();
      myWebPermissionUnion.CreateUnion();
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

  public void CreateUnion() 
  {
// <Snippet1>

    // Create a WebPermission.instance.
    WebPermission myWebPermission1 = new WebPermission(NetworkAccess.Connect,"http://www.contoso.com/default.htm");
    myWebPermission1.Demand();

// </Snippet1>

    // Create another WebPermission instance.
    WebPermission myWebPermission2 = new WebPermission(NetworkAccess.Connect,"http://www.adventure-works.com");
    myWebPermission2.Demand();

    // Print the attributes, values and childrens of the XML encoded instances.
    Console.WriteLine("Attributes and values of the first WebPermission are : ");    
    PrintKeysAndValues(myWebPermission1.ToXml().Attributes,myWebPermission1.ToXml().Children);
    
    Console.WriteLine("\nAttributes and values of the second WebPermission are : ");  
    PrintKeysAndValues(myWebPermission2.ToXml().Attributes,myWebPermission2.ToXml().Children);

// <Snippet2>

    // Create another WebPermission that is the Union of previous two WebPermission 
    // instances.
    WebPermission myWebPermission3 =(WebPermission) myWebPermission1.Union(myWebPermission2);
    Console.WriteLine("\nAttributes and values of the WebPermission after the Union are : ");
    // Display the attributes,values and children.
    Console.WriteLine(myWebPermission3.ToXml().ToString());

// </Snippet2>
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
