   private void CompareCurrentCultureInsensitiveStringComparer()
   {
      StringComparer stringComparer1, stringComparer2;
      stringComparer1 = StringComparer.CurrentCultureIgnoreCase;
      stringComparer2 = StringComparer.CurrentCultureIgnoreCase;
      // Displays false
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, 
                                                       stringComparer2));
   }