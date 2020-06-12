using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AssemblySnippets
{
    static class MetadataLoadContextSnippets
    {
        public static void SnippetsResolver()
        {
            //<SnippetCoreAssembly>
            var resolver = new PathAssemblyResolver(new string[] { "ExampleAssembly.dll", typeof(object).Assembly.Location });
            //</SnippetCoreAssembly>
        }

        public static void SnippetsMetadataLoadContext()
        {
            //<SnippetRuntimeAssemblies>
            // Get the array of runtime assemblies.
            string[] runtimeAssemblies = Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll");

            // Create the list of assembly paths consisting of runtime assemblies and the inspected assembly.
            var paths = new List<string>(runtimeAssemblies);
            paths.Add("ExampleAssembly.dll");

            // Create PathAssemblyResolver that can resolve assemblies using the created list.
            var resolver = new PathAssemblyResolver(paths);
            //</SnippetRuntimeAssemblies>

            //<SnippetCreateContext>
            var mlc = new MetadataLoadContext(resolver);

            using (mlc)
            {
                // Load assembly into MetadataLoadContext.
                Assembly assembly = mlc.LoadFromAssemblyPath("ExampleAssembly.dll");
                AssemblyName name = assembly.GetName();

                // Print assembly attribute information.
                Console.WriteLine($"{name.Name} has following attributes: ");

                foreach (CustomAttributeData attr in assembly.GetCustomAttributesData())
                {
                    try
                    {
                        Console.WriteLine(attr.AttributeType);
                    }
                    catch (FileNotFoundException ex)
                    {
                        // We are missing the required dependency assembly.
                        Console.WriteLine($"Error while getting attribute type: {ex.Message}");
                    }
                }
            }
            //</SnippetCreateContext>
        }
    }
}
