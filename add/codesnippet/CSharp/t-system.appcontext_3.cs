using System;
using System.Reflection;

[assembly: AssemblyVersion("2.0.0.0")]

public static class StringLibrary
{
   public static int SubstringStartsAt(String fullString, String substr)
   {
      return fullString.IndexOf(substr, StringComparison.CurrentCulture);
   }
}