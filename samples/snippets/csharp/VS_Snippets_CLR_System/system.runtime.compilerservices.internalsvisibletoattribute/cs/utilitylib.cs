// <Snippet5>
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("Friend2")]

namespace Utilities.StringUtilities
{
   public class StringLib
   {
      internal static bool IsFirstLetterUpperCase(String s)
      {
         string first = s.Substring(0, 1);
         return first == first.ToUpper();
      }
   }
}
// </Snippet5>
