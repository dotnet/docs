//<Snippet1>
using System;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ProviderOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayCSharpCompilerInfo();
            DisplayVBCompilerInfo();
            Console.WriteLine("Press Enter key to exit.");
            Console.ReadLine();
        }
        static void DisplayCSharpCompilerInfo()
        {
            Dictionary<string, string> provOptions =
            new Dictionary<string, string>();

            provOptions.Add("CompilerVersion", "v4");
            // Get the provider for Microsoft.CSharp
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp", provOptions);

            // Display the C# language provider information.
            Console.WriteLine("CSharp provider is {0}",
                provider.ToString());
            Console.WriteLine("  Provider hash code:     {0}",
                provider.GetHashCode().ToString());
            Console.WriteLine("  Default file extension: {0}",
                provider.FileExtension);

            Console.WriteLine();
        }

        static void DisplayVBCompilerInfo()
        {
            Dictionary<string, string> provOptions =
            new Dictionary<string, string>();

            provOptions.Add("CompilerVersion", "v3.5");
            // Get the provider for Microsoft.VisualBasic
            CodeDomProvider provider = CodeDomProvider.CreateProvider("VisualBasic", provOptions);

            // Display the Visual Basic language provider information.
            Console.WriteLine("Visual Basic provider is {0}",
                provider.ToString());
            Console.WriteLine("  Provider hash code:     {0}",
                provider.GetHashCode().ToString());
            Console.WriteLine("  Default file extension: {0}",
                provider.FileExtension);

            Console.WriteLine();
        }
    }
}
//</Snippet1>