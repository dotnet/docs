// <Snippet3>
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

public class RegexCompilationTest
{
   public static void Main()
   {
      RegexCompilationInfo expr;
      List<RegexCompilationInfo> compilationList = new List<RegexCompilationInfo>();

      // Define regular expression to detect duplicate words
      expr = new RegexCompilationInfo(@"\b(?<word>\w+)\s+(\k<word>)\b", 
                 RegexOptions.IgnoreCase | RegexOptions.CultureInvariant, 
                 "DuplicatedString", 
                 "Utilities.RegularExpressions", 
                 true);
      // Add info object to list of objects
      compilationList.Add(expr);

      // Define regular expression to validate format of email address
      expr = new RegexCompilationInfo(@"^(?("")(""[^""]+?""@)|(([0-9A-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Z])@))" + 
                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Z][-\w]*[0-9A-Z]\.)+[zA-Z]{2,6}))$", 
                 RegexOptions.IgnoreCase | RegexOptions.CultureInvariant, 
                 "EmailAddress", 
                 "Utilities.RegularExpressions", 
                 true);
      // Add info object to list of objects
      compilationList.Add(expr);
                                             
      // Apply AssemblyTitle attribute to the new assembly
      //
      // Define the parameter(s) of the AssemblyTitle attribute's constructor 
      Type[] parameters = { typeof(string) };
      // Define the assembly's title
      object[] paramValues = { "General-purpose library of compiled regular expressions" };
      // Get the ConstructorInfo object representing the attribute's constructor
      ConstructorInfo ctor = typeof(System.Reflection.AssemblyTitleAttribute).GetConstructor(parameters);
      // Create the CustomAttributeBuilder object array
      CustomAttributeBuilder[] attBuilder = { new CustomAttributeBuilder(ctor, paramValues) }; 
                                                         
      // Generate assembly with compiled regular expressions
      RegexCompilationInfo[] compilationArray = new RegexCompilationInfo[compilationList.Count];
      AssemblyName assemName = new AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");
      compilationList.CopyTo(compilationArray); 
      Regex.CompileToAssembly(compilationArray, assemName, attBuilder);                                                 
   }
}
// </Snippet3>
