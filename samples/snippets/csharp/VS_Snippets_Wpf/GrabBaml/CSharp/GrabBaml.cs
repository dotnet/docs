using System;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Resources;
using System.Windows.Markup.Localizer;

public class GrabBaml
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("this.exe [resource.dll]");
            return;
        }

        Assembly assembly = Assembly.LoadFrom(args[0]);

        foreach(string resourceName in assembly.GetManifestResourceNames())
        {
            Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (ResourceReader reader = new ResourceReader(resourceStream))
            {
                foreach (DictionaryEntry entry in reader)
                {
                    string name = entry.Key as string;     
                
                    if (Path.GetExtension(name).ToUpperInvariant() == ".BAML")
                    {                        
                        Console.WriteLine("Processing baml {0}", name);

                        // <Snippet1>

                        // Obtain the BAML stream.
                        Stream source = entry.Value as Stream;

                        // Create a BamlLocalizer on the stream.
                        BamlLocalizer localizer = new BamlLocalizer(source);
                        BamlLocalizationDictionary resources = localizer.ExtractResources();

                        // Write out all the localizable resources in the BAML.
                        foreach (DictionaryEntry resourceEntry in resources)
                        {
                            BamlLocalizableResourceKey key = resourceEntry.Key as BamlLocalizableResourceKey;
                            BamlLocalizableResource value = resourceEntry.Value as BamlLocalizableResource;
                            Console.WriteLine(
                                "    {0}.{1}.{2} = {3}",
                                key.Uid,
                                key.ClassName,
                                key.PropertyName,
                                value.Content
                                );                                
                        }
                        // </Snippet1>
                        
                        Console.WriteLine("Done");
                    }
                }
            }
        }        
        
    }
}