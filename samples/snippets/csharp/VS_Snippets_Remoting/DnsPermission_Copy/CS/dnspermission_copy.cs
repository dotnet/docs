/*
   This program demonstrates the 'Copy' method of 'DnsPermission' class.
   It creates an identical copy of 'DnsPermission' instance.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;

class DnsPermissionExample {

   public static void Main() {
     try 
     {
       DnsPermissionExample dnsPermissionExampleObj = new DnsPermissionExample();
       dnsPermissionExampleObj.UseDns();
     }
     catch(SecurityException e) 
     {
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
   public void UseDns() {
      // Create a DnsPermission instance.
      DnsPermission myPermission = new DnsPermission(PermissionState.Unrestricted);
      // Check for permission.
      myPermission.Demand();
      // Create an identical copy of the above 'DnsPermission' object.
      DnsPermission myPermissionCopy = (DnsPermission)myPermission.Copy();
      Console.WriteLine("Attributes and Values of 'DnsPermission' instance :");
      // Print the attributes and values.
      PrintKeysAndValues(myPermission.ToXml().Attributes);
      Console.WriteLine("Attribute and values of copied instance :");
      PrintKeysAndValues(myPermissionCopy.ToXml().Attributes);
   }

   private void PrintKeysAndValues(Hashtable myHashtable) {
      // Get the enumerator that can iterate through the hash table.
      IDictionaryEnumerator myEnumerator = myHashtable.GetEnumerator();
      Console.WriteLine("\t-KEY-\t-VALUE-");
      while (myEnumerator.MoveNext())
         Console.WriteLine("\t{0}:\t{1}", myEnumerator.Key, myEnumerator.Value);
      Console.WriteLine();
   }
// </Snippet1>
};

