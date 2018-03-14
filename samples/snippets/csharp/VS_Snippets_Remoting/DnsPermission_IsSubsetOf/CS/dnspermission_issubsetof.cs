/*
   This program demonstrates the  'IsSubsetOf' method of 'DnsPermission' class.
   'IsSubsetOf' method returns true, if the current DnsPermission instance allows no
   more access to DNS servers than does the specified 'DnsPermission' instance.
*/

using System;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Collections;

class DnsPermissionExample {
 
   private DnsPermission permission;

   public static void Main() {
     try 
     {
       DnsPermissionExample dnsPermissionExampleObj = new DnsPermissionExample();
       dnsPermissionExampleObj.useDns();
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
   public void useDns() {
      // Create a DnsPermission instance.
      permission = new DnsPermission(PermissionState.Unrestricted);
      DnsPermission dnsPermission1 = new DnsPermission(PermissionState.None);
      // Check for permission.
      permission.Demand();
      dnsPermission1.Demand();
      // Print the attributes and values.
      Console.WriteLine("Attributes and Values of 'DnsPermission' instance :");
      PrintKeysAndValues(permission.ToXml().Attributes);
      Console.WriteLine("Attributes and Values of specified 'DnsPermission' instance :");
      PrintKeysAndValues(dnsPermission1.ToXml().Attributes);
      Subset(dnsPermission1);
   }

   private void Subset(DnsPermission Permission1)
   {
      if(permission.IsSubsetOf(Permission1))
         Console.WriteLine("Current 'DnsPermission' instance is a subset of specified 'DnsPermission' instance.");
      else
         Console.WriteLine("Current 'DnsPermission' instance is not a subset of specified 'DnsPermission' instance.");
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

