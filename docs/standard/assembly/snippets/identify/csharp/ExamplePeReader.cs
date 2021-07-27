//<SnippetPeReader>
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

static class ExamplePeReader
{
    static bool IsAssembly(string path)
    {
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        // Try to read CLI metadata from the PE file.
        using var peReader = new PEReader(fs);

        if (!peReader.HasMetadata)
        {
            return false; // File does not have CLI metadata.
        }

        // Check that file has an assembly manifest.
        MetadataReader reader = peReader.GetMetadataReader();
        return reader.IsAssembly;
    }

    public static void CheckAssembly()
    {
        string path = Path.Combine(
                RuntimeEnvironment.GetRuntimeDirectory(),
                "System.Net.dll");

        try
        {
            if (IsAssembly(path))
            {
                Console.WriteLine("Yes, the file is an assembly.");
            }
            else
            {
                Console.WriteLine("The file is not an assembly.");
            }
        }
        catch (BadImageFormatException)
        {
            Console.WriteLine("The file is not an executable.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file cannot be found.");
        }
    }

    /* Output: 
    Yes, the file is an assembly.  
    */
}
//</SnippetPeReader>
