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