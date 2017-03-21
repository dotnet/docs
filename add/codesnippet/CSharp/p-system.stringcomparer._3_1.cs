   private void CompareCurrentCultureStringComparer()
   {
      StringComparer stringComparer1 = StringComparer.CurrentCulture;
      StringComparer stringComparer2 = StringComparer.CurrentCulture;
      // Displays false
      Console.WriteLine(StringComparer.ReferenceEquals(stringComparer1, 
                                                       stringComparer2));
   }