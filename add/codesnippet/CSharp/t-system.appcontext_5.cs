using System;
using System.Reflection;

[assembly: AssemblyVersion("2.0.0.0")]

public static class StringLibrary
{
   public static int SubstringStartsAt(String fullString, String substr)
   {
      bool flag;
      if (AppContext.TryGetSwitch("StringLibrary.DoNotUseCultureSensitiveComparison", out flag) && flag == true)
         return fullString.IndexOf(substr, StringComparison.Ordinal);
      else
         return fullString.IndexOf(substr, StringComparison.CurrentCulture);
         
   }
}