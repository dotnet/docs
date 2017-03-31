// <Snippet1>
using System;
using System.Reflection;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
        // Match two or more occurrences of the same character.
        string pattern = @"(\w)\1+";
        
        // Use case-insensitive matching. 
        var rci = new RegexCompilationInfo(pattern, RegexOptions.IgnoreCase,
                                           "DuplicateChars", "CustomRegexes", 
                                           true, TimeSpan.FromSeconds(2));

        // Define an assembly to contain the compiled regular expression.
        var an = new AssemblyName();
        an.Name = "RegexLib";
        RegexCompilationInfo[] rciList = { rci };

        // Compile the regular expression and create the assembly.
        Regex.CompileToAssembly(rciList, an);
   }
}
// </Snippet1>
