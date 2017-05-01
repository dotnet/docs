// <Snippet1>
using System;
using System.Globalization;
using System.Runtime.CompilerServices;

public class Utility
{
   [MethodImplAttribute(MethodImplOptions.NoInlining)] 
   public static string GetCalendarName(Calendar cal)
   {
      return cal.ToString().Replace("System.Globalization.", "").
                 Replace("Calendar", "");
   }
}
// </Snippet1>
