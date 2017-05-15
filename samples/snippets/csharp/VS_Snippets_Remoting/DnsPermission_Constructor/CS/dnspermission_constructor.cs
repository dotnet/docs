/*
   This program demonstrates the 'Constructor' of 'DnsPermission' class.
   It creates an instance of 'DnsPermission' class and checks for permission.Then it 
   creates a 'SecurityElement' object and  prints it's attributes which hold the  XML
   encoding of 'DnsPermission' instance .
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;

class DnsPermissionExample {

   public static void Main() {
      try {
         DnsPermissionExample dnsPermissionExampleObj = new DnsPermissionExample();
     dnsPermissionExampleObj.useDns();
      }
      catch(SecurityException e) {
      Console.WriteLine("SecurityException caught!!!");
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
// <Snippet1>   
   public void useDns() {

      // Create a DnsPermission instance.
      DnsPermission permission = new DnsPermission(PermissionState.Unrestricted);

      // Check for permission.
      permission.Demand();
      // Create a SecurityElement object to hold XML encoding of the DnsPermission instance.
      SecurityElement securityElementObj = permission.ToXml();    
      Console.WriteLine("Tag, Attributes and Values of 'DnsPermission' instance :");
      Console.WriteLine("\n\tTag :" + securityElementObj.Tag);
      // Print the attributes and values.
      PrintKeysAndValues(securityElementObj.Attributes);
   }

   private void PrintKeysAndValues(Hashtable myList) {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator myEnumerator = myList.GetEnumerator();
      Console.WriteLine("\n\t-KEY-\t-VALUE-");
      while (myEnumerator.MoveNext())
         Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
      Console.WriteLine();
   }
// </Snippet1>   
};
