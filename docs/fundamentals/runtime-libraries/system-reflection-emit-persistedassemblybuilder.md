---
title: System.Reflection.Emit.PersistedAssemblyBuilder class
description: Learn about the System.Reflection.Emit.PersistedAssemblyBuilder class.
ms.date: 05/10/2024
ms.topic: article
---
# Persisted dynamic assemblies in .NET

[!INCLUDE [context](includes/context.md)]

The <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A?displayProperty=nameWithType> API wasn't originally ported to .NET (Core) because the implementation depended heavily on Windows-specific native code that also wasn't ported. New in .NET 9, the <xref:System.Reflection.Emit.PersistedAssemblyBuilder> class adds a fully managed `Reflection.Emit` implementation that supports saving. This implementation has no dependency on the pre-existing, runtime-specific `Reflection.Emit` implementation. That is, now there are two different implementations in .NET, runnable and persisted. To run the persisted assembly, first save it into a memory stream or a file, then load it back.

Before `PersistedAssemblyBuilder`, you could only run a generated assembly and not save it. Since the assembly was in-memory only, it was difficult to debug. Advantages of saving a dynamic assembly to a file are:

- You can verify the generated assembly with tools such as ILVerify, or decompile and manually examine it with tools such as ILSpy.
- The saved assembly can be loaded directly, no need to compile again, which can decrease application startup time.

To create a `PersistedAssemblyBuilder` instance, use the <xref:System.Reflection.Emit.PersistedAssemblyBuilder.%23ctor(System.Reflection.AssemblyName,System.Reflection.Assembly,System.Collections.Generic.IEnumerable{System.Reflection.Emit.CustomAttributeBuilder})> constructor. The `coreAssembly` parameter is used to resolve base runtime types and can be used for resolving reference assembly versioning:

- If `Reflection.Emit` is used to generate an assembly that will only be executed on the same runtime version as the runtime version that the compiler is running on (typically in-proc), the core assembly can be simply `typeof(object).Assembly`. The following example demonstrates how to create and save an assembly to a stream and run it with the current runtime assembly:

  :::code language="csharp" source="./snippets/System.Reflection.Emit/PersistedAssemblyBuilder/Overview/csharp/CreateAndRunAssembly.cs" id="Snippet1":::

- If `Reflection.Emit` is used to generate an assembly that targets a specific TFM, open the reference assemblies for the given TFM using `MetadataLoadContext` and use the value of the [MetadataLoadContext.CoreAssembly](xref:System.Reflection.MetadataLoadContext.CoreAssembly) property for `coreAssembly`. This value allows the generator to run on one .NET runtime version and target a different .NET runtime version. You should use types returned by the `MetadataLoadContext` instance when referencing core types. For example, instead of `typeof(int)`, find the `System.Int32` type in `MetadataLoadContext.CoreAssembly` by name:

  :::code language="csharp" source="./snippets/System.Reflection.Emit/PersistedAssemblyBuilder/Overview/csharp/CreateAndRunAssembly.cs" id="Snippet2":::

## Set entry point for an executable

To set the entry point for an executable or to set other options for the assembly file, you can call the `public MetadataBuilder GenerateMetadata(out BlobBuilder ilStream, out BlobBuilder mappedFieldData)` method and use the populated metadata to generate the assembly with desired options, for example:

:::code language="csharp" source="./snippets/System.Reflection.Emit/PersistedAssemblyBuilder/Overview/csharp/GenerateMetadataSnippets.cs" id="Snippet1":::

## Emit symbols and generate PDB

The symbols metadata is populated into the `pdbBuilder` out parameter when you call the <xref:System.Reflection.Emit.PersistedAssemblyBuilder.GenerateMetadata(System.Reflection.Metadata.BlobBuilder@,System.Reflection.Metadata.BlobBuilder@)> method on a `PersistedAssemblyBuilder` instance. To create an assembly with a portable PDB:

1. Create <xref:System.Diagnostics.SymbolStore.ISymbolDocumentWriter> instances with the <xref:System.Reflection.Emit.ModuleBuilder.DefineDocument(System.String,System.Guid,System.Guid,System.Guid)?displayProperty=nameWithType> method. While emitting the method's IL, also emit the corresponding symbol info.
2. Create a <xref:System.Reflection.Metadata.Ecma335.PortablePdbBuilder> instance using the `pdbBuilder` instance produced by the <xref:System.Reflection.Emit.PersistedAssemblyBuilder.GenerateMetadata(System.Reflection.Metadata.BlobBuilder@,System.Reflection.Metadata.BlobBuilder@)> method.
3. Serialize the `PortablePdbBuilder` into a <xref:System.Reflection.Metadata.Blob>, and write the `Blob` into a PDB file stream (only if you're generating a standalone PDB).
4. Create a <xref:System.Reflection.PortableExecutable.DebugDirectoryBuilder> instance and add a <xref:System.Reflection.PortableExecutable.DebugDirectoryBuilder.AddCodeViewEntry%2A?displayProperty=nameWithType> (standalone PDB) or <xref:System.Reflection.PortableExecutable.DebugDirectoryBuilder.AddEmbeddedPortablePdbEntry%2A?displayProperty=nameWithType>.
5. Set the optional `debugDirectoryBuilder` argument when creating the <xref:System.Reflection.PortableExecutable.PEBuilder> instance.

The following example shows how to emit symbol info and generate a PDB file.

```csharp
static void GenerateAssemblyWithPdb()
{
    PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyAssembly"), typeof(object).Assembly);
    ModuleBuilder mb = ab.DefineDynamicModule("MyModule");
    TypeBuilder tb = mb.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
    MethodBuilder mb1 = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static, typeof(int), [typeof(int), typeof(int)]);
    ISymbolDocumentWriter srcDoc = mb.DefineDocument("MySourceFile.cs", SymLanguageType.CSharp);
    ILGenerator il = mb1.GetILGenerator();
    LocalBuilder local = il.DeclareLocal(typeof(int));
    local.SetLocalSymInfo("myLocal");
    il.MarkSequencePoint(srcDoc, 7, 0, 7, 11);
    ...
    il.Emit(OpCodes.Ret);

    MethodBuilder entryPoint = tb.DefineMethod("Main", MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Static);
    ILGenerator il2 = entryPoint.GetILGenerator();
    il2.BeginScope();
    ...
    il2.EndScope();
    ...
    tb.CreateType();

    MetadataBuilder metadataBuilder = ab.GenerateMetadata(out BlobBuilder ilStream, out _, out MetadataBuilder pdbBuilder);
    MethodDefinitionHandle entryPointHandle = MetadataTokens.MethodDefinitionHandle(entryPoint.MetadataToken);
    DebugDirectoryBuilder debugDirectoryBuilder = GeneratePdb(pdbBuilder, metadataBuilder.GetRowCounts(), entryPointHandle);

    ManagedPEBuilder peBuilder = new ManagedPEBuilder(
                    header: new PEHeaderBuilder(imageCharacteristics: Characteristics.ExecutableImage, subsystem: Subsystem.WindowsCui),
                    metadataRootBuilder: new MetadataRootBuilder(metadataBuilder),
                    ilStream: ilStream,
                    debugDirectoryBuilder: debugDirectoryBuilder,
                    entryPoint: entryPointHandle);

    BlobBuilder peBlob = new BlobBuilder();
    peBuilder.Serialize(peBlob);

    using var fileStream = new FileStream("MyAssembly.exe", FileMode.Create, FileAccess.Write);
    peBlob.WriteContentTo(fileStream);
}

static DebugDirectoryBuilder GeneratePdb(MetadataBuilder pdbBuilder, ImmutableArray<int> rowCounts, MethodDefinitionHandle entryPointHandle)
{
    BlobBuilder portablePdbBlob = new BlobBuilder();
    PortablePdbBuilder portablePdbBuilder = new PortablePdbBuilder(pdbBuilder, rowCounts, entryPointHandle);
    BlobContentId pdbContentId = portablePdbBuilder.Serialize(portablePdbBlob);
    // In case saving PDB to a file
    using FileStream fileStream = new FileStream("MyAssemblyEmbeddedSource.pdb", FileMode.Create, FileAccess.Write);
    portablePdbBlob.WriteContentTo(fileStream);

    DebugDirectoryBuilder debugDirectoryBuilder = new DebugDirectoryBuilder();
    debugDirectoryBuilder.AddCodeViewEntry("MyAssemblyEmbeddedSource.pdb", pdbContentId, portablePdbBuilder.FormatVersion);
    // In case embedded in PE:
    // debugDirectoryBuilder.AddEmbeddedPortablePdbEntry(portablePdbBlob, portablePdbBuilder.FormatVersion);
    return debugDirectoryBuilder;
}
```

Further, you can add <xref:System.Reflection.Metadata.CustomDebugInformation> by calling the <xref:System.Reflection.Metadata.Ecma335.MetadataBuilder.AddCustomDebugInformation(System.Reflection.Metadata.EntityHandle,System.Reflection.Metadata.GuidHandle,System.Reflection.Metadata.BlobHandle)?displayProperty=nameWithType> method from the `pdbBuilder` instance to add source embedding and source indexing advanced PDB information.

```csharp
private static void EmbedSource(MetadataBuilder pdbBuilder)
{
    byte[] sourceBytes = File.ReadAllBytes("MySourceFile2.cs");
    BlobBuilder sourceBlob = new BlobBuilder();
    sourceBlob.WriteBytes(sourceBytes);
    pdbBuilder.AddCustomDebugInformation(MetadataTokens.DocumentHandle(1),
        pdbBuilder.GetOrAddGuid(new Guid("0E8A571B-6926-466E-B4AD-8AB04611F5FE")), pdbBuilder.GetOrAddBlob(sourceBlob));
}
```

## Add resources with PersistedAssemblyBuilder

You can call <xref:System.Reflection.Metadata.Ecma335.MetadataBuilder.AddManifestResource(System.Reflection.ManifestResourceAttributes,System.Reflection.Metadata.StringHandle,System.Reflection.Metadata.EntityHandle,System.UInt32)?displayProperty=nameWithType> to add as many resources as needed. Streams must be concatenated into one <xref:System.Reflection.Metadata.BlobBuilder> that you pass into the <xref:System.Reflection.PortableExecutable.ManagedPEBuilder> argument.
The following example shows how to create resources and attach it to the assembly that's created.

:::code language="csharp" source="./snippets/System.Reflection.Emit/PersistedAssemblyBuilder/Overview/csharp/GenerateMetadataSnippets.cs" id="Snippet2":::

The following example shows how to read resources from the created assembly.

:::code language="csharp" source="./snippets/System.Reflection.Emit/PersistedAssemblyBuilder/Overview/csharp/GenerateMetadataSnippets.cs" id="Snippet3":::

> [!NOTE]
> The metadata tokens for all members are populated on the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A> operation. Don't use the tokens of a generated type and its members before saving, as they'll have default values or throw exceptions. It's safe to use tokens for types that are referenced, not generated.
>
> Some APIs that aren't important for emitting an assembly aren't implemented; for example, `GetCustomAttributes()` is not implemented. With the runtime implementation, you were able to use those APIs after creating the type. For the persisted `AssemblyBuilder`, they throw `NotSupportedException` or `NotImplementedException`. If you have a scenario that requires those APIs, file an issue in the [dotnet/runtime repo](https://github.com/dotnet/runtime).

For an alternative way to generate assembly files, see <xref:System.Reflection.Metadata.Ecma335.MetadataBuilder>.
