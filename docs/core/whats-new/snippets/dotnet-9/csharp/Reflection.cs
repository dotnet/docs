using System.Reflection.Emit;
using System.Reflection;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.IO;

internal class Reflection
{
    // <SaveAssembly>
    public void CreateAndSaveAssembly(string assemblyPath)
    {
        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(
            new AssemblyName("MyAssembly"),
            typeof(object).Assembly
            );
        TypeBuilder tb = ab.DefineDynamicModule("MyModule")
            .DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);

        MethodBuilder entryPoint = tb.DefineMethod(
            "Main",
            MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Static
            );
        ILGenerator il = entryPoint.GetILGenerator();
        // ...
        il.Emit(OpCodes.Ret);

        tb.CreateType();

        MetadataBuilder metadataBuilder = ab.GenerateMetadata(
            out BlobBuilder ilStream,
            out BlobBuilder fieldData
            );
        PEHeaderBuilder peHeaderBuilder = new PEHeaderBuilder(
                        imageCharacteristics: Characteristics.ExecutableImage);

        ManagedPEBuilder peBuilder = new ManagedPEBuilder(
                        header: peHeaderBuilder,
                        metadataRootBuilder: new MetadataRootBuilder(metadataBuilder),
                        ilStream: ilStream,
                        mappedFieldData: fieldData,
                        entryPoint: MetadataTokens.MethodDefinitionHandle(entryPoint.MetadataToken)
                        );

        BlobBuilder peBlob = new BlobBuilder();
        peBuilder.Serialize(peBlob);

        using var fileStream = new FileStream("MyAssembly.exe", FileMode.Create, FileAccess.Write);
        peBlob.WriteContentTo(fileStream);
    }

    public static void UseAssembly(string assemblyPath)
    {
        Assembly assembly = Assembly.LoadFrom(assemblyPath);
        Type? type = assembly.GetType("MyType");
        MethodInfo? method = type?.GetMethod("SumMethod");
        Console.WriteLine(method?.Invoke(null, [5, 10]));
    }
    // </SaveAssembly>
}
