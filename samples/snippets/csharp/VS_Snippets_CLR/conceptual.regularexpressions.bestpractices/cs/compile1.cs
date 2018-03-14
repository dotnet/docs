// <Snippet6>
using System;
using System.Reflection;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      RegexCompilationInfo SentencePattern =
                           new RegexCompilationInfo(@"\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]",
                                                    RegexOptions.Multiline,
                                                    "SentencePattern",
                                                    "Utilities.RegularExpressions",
                                                    true);
      RegexCompilationInfo[] regexes = { SentencePattern };
      AssemblyName assemName = new AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");
      Regex.CompileToAssembly(regexes, assemName);
   }
}
// </Snippet6>
