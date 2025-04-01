using System;

public class Example
{
    public static void Run()
    {
        Example ex = new Example();
        ex.Standalone();
        Console.WriteLine("---");
        ex.Embedded();
    }

    private void Standalone()
    {
        // <Snippet2>
        // Instantiate a standalone .resources file from its filename.
        var rr1 = new System.Resources.ResourceReader("Resources1.resources");

        // Instantiate a standalone .resources file from a stream.
        var fs = new System.IO.FileStream(@".\Resources2.resources",
                                          System.IO.FileMode.Open);
        var rr2 = new System.Resources.ResourceReader(fs);
        // </Snippet2>                                       

        Console.WriteLine($"rr1: {rr1 != null}");
        Console.WriteLine($"rr2: {rr2 != null}");
    }

    private void Embedded()
    {
        // <Snippet3>
        System.Reflection.Assembly assem =
                     System.Reflection.Assembly.LoadFrom(@".\MyLibrary.dll");
        System.IO.Stream fs =
                     assem.GetManifestResourceStream("MyCompany.LibraryResources.resources");
        var rr = new System.Resources.ResourceReader(fs);
        // </Snippet3>

        if (fs == null)
        {
            Console.WriteLine(fs == null);
            foreach (var name in assem.GetManifestResourceNames())
                Console.WriteLine(name);

            return;
        }
        else
        {
            Console.WriteLine(fs == null);
        }
    }
}
