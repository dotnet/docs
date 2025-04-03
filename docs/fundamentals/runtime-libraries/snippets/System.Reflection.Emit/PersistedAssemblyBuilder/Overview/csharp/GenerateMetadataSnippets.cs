using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Resources;

public class SnippetExamples
{
   public static void Main()
   {
        SetEntryPoint();
        SetResource();
        ReadResource();
   }
    // <Snippet1>
    public static void SetEntryPoint()
    {
        PersistedAssemblyBuilder ab = new(new AssemblyName("MyAssembly"), typeof(object).Assembly);
        TypeBuilder tb = ab.DefineDynamicModule("MyModule").DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
        // ...
        MethodBuilder entryPoint = tb.DefineMethod("Main", MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Static);
        ILGenerator il2 = entryPoint.GetILGenerator();
        // ...
        il2.Emit(OpCodes.Ret);
        tb.CreateType();

        MetadataBuilder metadataBuilder = ab.GenerateMetadata(out BlobBuilder ilStream, out BlobBuilder fieldData);

        ManagedPEBuilder peBuilder = new(
                        header: PEHeaderBuilder.CreateExecutableHeader(),
                        metadataRootBuilder: new MetadataRootBuilder(metadataBuilder),
                        ilStream: ilStream,
                        mappedFieldData: fieldData,
                        entryPoint: MetadataTokens.MethodDefinitionHandle(entryPoint.MetadataToken));

        BlobBuilder peBlob = new();
        peBuilder.Serialize(peBlob);

        // Create the executable:
        using FileStream fileStream = new("MyAssembly.exe", FileMode.Create, FileAccess.Write);
        peBlob.WriteContentTo(fileStream);
    }
    // </Snippet1>
    // <Snippet2>
    public static void SetResource()
    {
        PersistedAssemblyBuilder ab = new(new AssemblyName("MyAssembly"), typeof(object).Assembly);
        ab.DefineDynamicModule("MyModule");
        MetadataBuilder metadata = ab.GenerateMetadata(out BlobBuilder ilStream, out _);

        using MemoryStream stream = new();
        ResourceWriter myResourceWriter = new(stream);
        myResourceWriter.AddResource("AddResource 1", "First added resource");
        myResourceWriter.AddResource("AddResource 2", "Second added resource");
        myResourceWriter.AddResource("AddResource 3", "Third added resource");
        myResourceWriter.Close();

        byte[] data = stream.ToArray();
        BlobBuilder resourceBlob = new();
        resourceBlob.WriteInt32(data.Length);
        resourceBlob.WriteBytes(data);

        metadata.AddManifestResource(
            ManifestResourceAttributes.Public,
            metadata.GetOrAddString("MyResource.resources"),
            implementation: default,
            offset: 0);        

        ManagedPEBuilder peBuilder = new(
                        header: PEHeaderBuilder.CreateLibraryHeader(),
                        metadataRootBuilder: new MetadataRootBuilder(metadata),
                        ilStream: ilStream,
                        managedResources: resourceBlob);

        BlobBuilder blob = new();
        peBuilder.Serialize(blob);

        // Create the assembly:
        using FileStream fileStream = new("MyAssemblyWithResource.dll", FileMode.Create, FileAccess.Write);
        blob.WriteContentTo(fileStream);
    }
    // </Snippet2>
    // <Snippet3>
    public static void ReadResource()
    {
        Assembly readAssembly = Assembly.LoadFile(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "MyAssemblyWithResource.dll"));

        // Use ResourceManager.GetString() to read the resources.
        ResourceManager rm = new("MyResource", readAssembly);
        Console.WriteLine("Using ResourceManager.GetString():");
        Console.WriteLine($"{rm.GetString("AddResource 1", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"{rm.GetString("AddResource 2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"{rm.GetString("AddResource 3", CultureInfo.InvariantCulture)}");

        // Use ResourceSet to enumerate the resources.
        Console.WriteLine();
        Console.WriteLine("Using ResourceSet:");
        ResourceSet resourceSet = rm.GetResourceSet(CultureInfo.InvariantCulture, createIfNotExists: true, tryParents: false);
        foreach (DictionaryEntry entry in resourceSet)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }

        // Use ResourceReader to enumerate the resources.
        Console.WriteLine();
        Console.WriteLine("Using ResourceReader:");
        using Stream stream = readAssembly.GetManifestResourceStream("MyResource.resources")!;
        using ResourceReader reader = new(stream);
        foreach (DictionaryEntry entry in reader)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
    }
    // </Snippet3>    
}
