using System;
using System.Runtime.CompilerServices;

// <Snippet3>
[assembly:InternalsVisibleTo("Friend1a")]
[assembly:InternalsVisibleTo("Friend1b")]
// </Snippet3>

public class StringUtilities
{
   internal string ToTitleCase(string value)
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
