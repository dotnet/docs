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
            Console.WriteLine("Press Enter key to exit.");
            Console.ReadLine();
        }
        static void DisplayCSharpCompilerInfo()
        {
            Dictionary<string, string> provOptions =
            new Dictionary<string, string>();

            provOptions.Add("CompilerVersion", "v3.5");
            // Get the provider for Microsoft.CSharp
            CSharpCodeProvider csProvider = new CSharpCodeProvider(provOptions);

            // Display the C# language provider information.
            Console.WriteLine("CSharp provider is {0}",
                csProvider.ToString());
            Console.WriteLine("  Provider hash code:     {0}",
                csProvider.GetHashCode().ToString());
            Console.WriteLine("  Default file extension: {0}",
                csProvider.FileExtension);

            Console.WriteLine();
        }


    }
}
//</Snippet1>

