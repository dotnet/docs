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