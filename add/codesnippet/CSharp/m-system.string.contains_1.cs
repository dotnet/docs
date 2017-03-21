using System;

public static class StringExtensions
{
   public static bool Contains(this String str, String substring, 
                               StringComparison comp)
   {                            
      if (substring == null)
         throw new ArgumentNullException("substring", 
                                         "substring cannot be null.");
      else if (! Enum.IsDefined(typeof(StringComparison), comp))
         throw new ArgumentException("comp is not a member of StringComparison",
                                     "comp");

      return str.IndexOf(substring, comp) >= 0;                      
   }
}