/*
   This program demonstrates the 'FromXml' method of 'DnsPermission' class.
   It creates an instance of 'DnsPermission' class and prints the XML encoding of that instance.Then it 
   creates a 'SecurityElement' object and adds the attributes corresponding to the above 'DnsPermission'
   object. A new 'DnsPermission' instance is reconstructed from the 'SecurityElement' instance by calling 
   'FromXml' method and it's XML encoding is printed.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;

class DnsPermissionExample {

   public static void Main() {      
      DnsPermissionExample dnsPermissionExampleObj = new DnsPermissionExample();
      dnsPermissionExampleObj.ConstructDnsPermission();
   }
// <Snippet1>
   public void ConstructDnsPermission() {
     try 
     {
       // Create a DnsPermission instance.
       DnsPermission permission = new DnsPermission(PermissionState.None);
       // Create a SecurityElement instance by calling the ToXml method on the 
       // DnsPermission instance.
       // Print its attributes, which hold the  XML encoding of the DnsPermission
       // instance.
       Console.WriteLine("Attributes and Values of 'DnsPermission' instance :");
       PrintKeysAndValues(permission.ToXml().Attributes);

       // Create a SecurityElement instance.
       SecurityElement securityElementObj = new SecurityElement("IPermission");
       // Add attributes and values of the SecurityElement instance corresponding to
       // the permission instance. 
       securityElementObj.AddAttribute("version", "1");
       securityElementObj.AddAttribute("Unrestricted", "true");
       securityElementObj.AddAttribute("class","System.Net.DnsPermission");
                        
       // Reconstruct a DnsPermission instance from an XML encoding.
         DnsPermission permission1 = new DnsPermission(PermissionState.None);
       permission1.FromXml(securityElementObj);

       // Print the attributes and values of the constructed DnsPermission object.
       Console.WriteLine("After reconstruction Attributes and Values of new DnsPermission instance :");
       PrintKeysAndValues(permission1.ToXml().Attributes);
     }
     catch(NullReferenceException e) 
     {
       Console.WriteLine("NullReferenceException caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }
     catch(SecurityException e) 
     {
       Console.WriteLine("SecurityException caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }
     catch(ArgumentNullException e) 
     {
       Console.WriteLine("ArgumentNullException caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }
     catch(Exception e)
     {
       Console.WriteLine("Exception caught!!!");
       Console.WriteLine("Source : " + e.Source);
       Console.WriteLine("Message : " + e.Message);
     }
   }

   private void PrintKeysAndValues(Hashtable myList) {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator myEnumerator = myList.GetEnumerator();
      Console.WriteLine("\t-KEY-\t-VALUE-");
      while (myEnumerator.MoveNext())
         Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
         Console.WriteLine();
   }
// </Snippet1>
};

