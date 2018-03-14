// System.Net.WebPermission.ToXml;System.Net.WebPermission.FromXml;
/**
  * This program shows the use of the ToXml and FromXml methods of the WebPermission class.
  * It creates a WebPermission instance with the Permissionstate set to None and 
  * displays the attributes and the values of the XML encoded instance .
  * Then a SecurityElement instance is created and it's attributes are 
  * set.
  * Finally, using the FromXml method the WebPermission instance is reconstructed from 
  * the above SecurityElement instance and the attributes are displayed.
*/


using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;

class WebPermission_FromToXml {

  static void Main() 
  {
    try
    {
      WebPermission_FromToXml  myWebPermission_FromToXml = new WebPermission_FromToXml();
      myWebPermission_FromToXml.CallXml();
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
   
  public void CallXml()
  {
// <Snippet1>

    // Create  a WebPermission without permission on the protected resource.
    WebPermission myWebPermission1 = new WebPermission(PermissionState.None);

    // Create a SecurityElement by calling the ToXml method on the WebPermission 
    // instance and display its attributes (which hold the XML encoding of 
    // the WebPermission).
    Console.WriteLine("Attributes and Values of the WebPermission are :");
    myWebPermission1.ToXml().ToString();

    // Create another WebPermission with no permission on the protected resource.
    WebPermission myWebPermission2 = new WebPermission(PermissionState.None);

    //Converts the new WebPermission from XML using myWebPermission1.
    myWebPermission2.FromXml(myWebPermission1.ToXml());

// </Snippet1>

    Console.WriteLine("The Attributes and Values of 'WebPermission' instance after reconstruction are: \n");
    // Display the Attributes and values of the XML encoded instances.
    PrintKeysAndValues(myWebPermission2.ToXml().Attributes);
  }

  private void PrintKeysAndValues(Hashtable myHashtable) 
  {
    // Get the enumerator to iterate through Hashtable.
    IDictionaryEnumerator myEnumerator = myHashtable.GetEnumerator();
    Console.WriteLine("\t-KEY-\t-VALUE-");
    while (myEnumerator.MoveNext())
       Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
    Console.WriteLine();     
   }
 }
