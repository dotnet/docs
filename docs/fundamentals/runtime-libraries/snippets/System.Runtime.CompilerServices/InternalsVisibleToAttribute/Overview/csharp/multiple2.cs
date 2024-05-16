using System;
using System.Runtime.CompilerServices;

// <Snippet4>
[assembly:InternalsVisibleTo("Friend2a"), 
          InternalsVisibleTo("Friend2b")]
// </Snippet4>
          
namespace Utilities
{
   public class StringUtilities
   {
      internal static string ToTitleCase(string value)
      {
         string retval = null;
         for (int ctr = 0; ctr <= value.Length - 1; ctr++)
            if (ctr == 0)     
               retval += Char.ToUpper(value[ctr]);
            else if (ctr > 0 && Char.IsWhiteSpace(value[ctr - 1]))
               retval += Char.ToUpper(value[ctr]);
            else
               retval += value[ctr];     
         return retval;            
      }
   }
}