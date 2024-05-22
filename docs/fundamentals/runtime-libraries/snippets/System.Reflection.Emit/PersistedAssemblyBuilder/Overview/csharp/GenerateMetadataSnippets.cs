using System;
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
   }
    // <Snippet1>
    public static void SetEntryPoint()
    {
        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyAssembly"), typeof(object).Assembly);
        TypeBuilder tb = ab.DefineDynamicModule("MyModule").DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
        // ...
        MethodBuilder entryPoint = tb.DefineMethod("Main", MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Static);
        ILGenerator il2 = entryPoint.GetILGenerator();
        // ...
        il2.Emit(OpCodes.Ret);
        tb.CreateType();

        MetadataBuilder metadataBuilder = ab.GenerateMetadata(out BlobBuilder ilStream, out BlobBuilder fieldData);
        PEHeaderBuilder peHeaderBuilder = new PEHeaderBuilder(imageCharacteristics: Characteristics.ExecutableImage);

        ManagedPEBuilder peBuilder = new ManagedPEBuilder(
                        header: peHeaderBuilder,
                        metadataRootBuilder: new MetadataRootBuilder(metadataBuilder),
                        ilStream: ilStream,
                        mappedFieldData: fieldData,
                        entryPoint: MetadataTokens.MethodDefinitionHandle(entryPoint.MetadataToken));

        BlobBuilder peBlob = new BlobBuilder();
        peBuilder.Serialize(peBlob);

        // in case saving to a file:
        using var fileStream = new FileStream("MyAssembly.exe", FileMode.Create, FileAccess.Write);
        peBlob.WriteContentTo(fileStream);
    }
    // </Snippet1>
    // <Snippet2>
    public static void SetResource()
    {
        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyAssembly"), typeof(object).Assembly);
        ab.DefineDynamicModule("MyModule");
        MetadataBuilder metadata = ab.GenerateMetadata(out BlobBuilder ilStream, out _);

        using MemoryStream stream = new MemoryStream();
        ResourceWriter myResourceWriter = new ResourceWriter(stream);
        myResourceWriter.AddResource("AddResource 1", "First added resource");
        myResourceWriter.AddResource("AddResource 2", "Second added resource");
        myResourceWriter.AddResource("AddResource 3", "Third added resource");
        myResourceWriter.Close();
        BlobBuilder resourceBlob = new BlobBuilder();
        resourceBlob.WriteBytes(stream.ToArray());
        metadata.AddManifestResource(ManifestResourceAttributes.Public, metadata.GetOrAddString("MyResource"), default, (uint)resourceBlob.Count);

        ManagedPEBuilder peBuilder = new ManagedPEBuilder(
                        header: new PEHeaderBuilder(imageCharacteristics: Characteristics.ExecutableImage | Characteristics.Dll),
                        metadataRootBuilder: new MetadataRootBuilder(metadata),
                        ilStream: ilStream,
                        managedResources: resourceBlob);

        BlobBuilder blob = new BlobBuilder();
        peBuilder.Serialize(blob);
        using var fileStream = new FileStream("MyAssemblyWithResource.dll", FileMode.Create, FileAccess.Write);
        blob.WriteContentTo(fileStream);
    }
    // </Snippet2>
}
