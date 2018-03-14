//<snippet1>
// This code example demonstrates the RegexCompilationInfo constructor
// and the Regex.CompileToAssembly() method.
// compile: csc genFishRegex.cs

namespace MyApp
{
    using System;
    using System.Reflection;
    using System.Text.RegularExpressions;
    class GenFishRegEx
    {
        public static void Main()
        {
// Pattern = Group matches one or more word characters, 
//           one or more white space characters, 
//           group matches the string "fish".
        string pat = @"(\w+)\s+(fish)";

// Create the compilation information.
// Case-insensitive matching; type name = "FishRegex"; 
// namespace = "MyApp"; type is public.
        RegexCompilationInfo rci = new RegexCompilationInfo(
                    pat, RegexOptions.IgnoreCase, 
                    "FishRegex", "MyApp", true);

// Setup to compile.
        AssemblyName an = new AssemblyName();
        an.Name = "FishRegex";
        RegexCompilationInfo[] rciList = { rci };

// Compile the regular expression.
        Regex.CompileToAssembly(rciList, an);
        }
    }
}
//</snippet1>
