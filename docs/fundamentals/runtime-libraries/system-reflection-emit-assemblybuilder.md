---
title: System.Reflection.Emit.AssemblyBuilder class
description: Learn about the System.Reflection.Emit.AssemblyBuilder class.
ms.date: 12/31/2023
---
# System.Reflection.Emit.AssemblyBuilder class

[!INCLUDE [context](includes/context.md)]

A dynamic assembly is an assembly that is created using the Reflection Emit APIs. A dynamic assembly can reference types defined in another dynamic or static assembly. You can use <xref:System.Reflection.Emit.AssemblyBuilder> to generate dynamic assemblies in memory and execute their code during the same application run. In .NET 9 we added a new `PersistedAssemblyBuilder` with fully managed implementation of reflection emit that allows you save the assembly into a file. In .NET Framework, you can do both&mdash;run the dynamic assembly and save it to a file. The dynamic assembly created for saving is called a *persisted* assembly, while the regular memory-only assembly is called *transient* or *runnable*. In .NET Framework, a dynamic assembly can consist of one or more dynamic modules. In .NET Core and .NET 5+, a dynamic assembly can only consist of one dynamic module.

The way you create an <xref:System.Reflection.Emit.AssemblyBuilder> instance differs for each implementation, but further steps for defining a module, type, method, or enum, and for writing IL, are quite similar.

## Runnable dynamic assemblies in .NET

To get a runnable <xref:System.Reflection.Emit.AssemblyBuilder> object, use the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> method.
Dynamic assemblies can be created using one of the following access modes:

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.Run?displayProperty=nameWithType>

  The dynamic assembly represented by an <xref:System.Reflection.Emit.AssemblyBuilder> can be used to execute the emitted code.

- <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndCollect?displayProperty=nameWithType>

  The dynamic assembly represented by an <xref:System.Reflection.Emit.AssemblyBuilder> can be used to execute the emitted code and is automatically reclaimed by garbage collector.

The access mode must be specified by providing the appropriate <xref:System.Reflection.Emit.AssemblyBuilderAccess> value in the call to the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicAssembly%2A?displayProperty=nameWithType> method when the dynamic assembly is defined and cannot be changed later. The runtime uses the access mode of a dynamic assembly to optimize the assembly's internal representation.

The following example demonstrates how to create and run an assembly:

```csharp
public void CreateAndRunAssembly(string assemblyPath)
{
    AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("MyAssembly"), AssemblyBuilderAccess.Run);
    ModuleBuilder mob = ab.DefineDynamicModule("MyModule");
    TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
    MethodBuilder mb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                                   typeof(int), new Type[] {typeof(int), typeof(int)});
    ILGenerator il = mb.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldarg_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Ret);

    Type type = tb.CreateType();

    MethodInfo method = type.GetMethod("SumMethod");
    Console.WriteLine(method.Invoke(null, new object[] { 5, 10 }));
}
```

## Persisted dynamic assemblies in .NET

The <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A?displayProperty=nameWithType> API wasn't originally ported to .NET (Core) because the implementation depended heavily on Windows-specific native code that also wasn't ported. In .NET 9 we added a fully managed `Reflection.Emit` implementation that supports saving. This implementation has no dependency on the pre-existing, runtime-specific `Reflection.Emit` implementation. That is, now there are two different implementations in .NET, runnable and persisted. To run the persisted assembly, first save it into a memory stream or a file, then load it back. Before `PersistedAssemblyBuilder`, because you could only run a generated assembly and not save it, it was difficult to debug these in-memory assemblies. Advantages of saving a dynamic assembly to a file are:

- You can verify the generated assembly with tools such as ILVerify, or decompile and manually examine it with tools such as ILSpy.
- The saved assembly can be loaded directly, no need to compile again, which can decrease application startup time.

To create a `PersistedAssemblyBuilder` instance, use the `public PersistedAssemblyBuilder(AssemblyName name, Assembly coreAssembly, IEnumerable<CustomAttributeBuilder>? assemblyAttributes = null)` constructor. The `coreAssembly` parameter is used to resolve base runtime types and can be used for resolving reference assembly versioning:

- If `Reflection.Emit` is used to generate an assembly that's only going to be executed on the same runtime version as the runtime version that the compiler is running on (typically in-proc), the core assembly can be simply `typeof(object).Assembly`. The following example demonstrates how to create and save an assembly to a stream and run it with current runtime assembly:

  ```csharp
  public void CreateSaveAndRunAssembly(string assemblyPath)
  {
      PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyAssembly"), typeof(object).Assembly);
      ModuleBuilder mob = ab.DefineDynamicModule("MyModule");
      TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
      MethodBuilder meb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                                   typeof(int), new Type[] {typeof(int), typeof(int)});
      ILGenerator il = meb.GetILGenerator();
      il.Emit(OpCodes.Ldarg_0);
      il.Emit(OpCodes.Ldarg_1);
      il.Emit(OpCodes.Add);
      il.Emit(OpCodes.Ret);

      tb.CreateType();

      using var stream = new MemoryStream();
      ab.Save(stream);  // or pass filename to save into a file
      stream.Seek(0, SeekOrigin.Begin);
      Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(stream);
      MethodInfo method = assembly.GetType("MyType").GetMethod("SumMethod");
      Console.WriteLine(method.Invoke(null, new object[] { 5, 10 }));
  }
  ```

- If `Reflection.Emit` is used to generate an assembly that targets a specific TFM, open the reference assemblies for the given TFM using `MetadataLoadContext` and use the value of the [MetadataLoadContext.CoreAssembly](xref:System.Reflection.MetadataLoadContext.CoreAssembly) property for `coreAssembly`. This value allows the generator to run on one .NET runtime version and target a different .NET runtime version. Note that, you should use types returned by the MetadataLoadContext instance when referencing core types. For example, instead of `typeof(object)`, you should lookup `System.Object` type in `MetadataLoadContext.CoreAssembly` by name:

  ```csharp
  public void CreatePersistedAssemblyBuilderCoreAssemblyWithMetadataLoadContext(string refAssembliesPath)
  {
      PathAssemblyResolver resolver = new PathAssemblyResolver(Directory.GetFiles(refAssembliesPath, "*.dll"));
      using MetadataLoadContext context = new MetadataLoadContext(resolver);
      Assembly coreAssembly = context.CoreAssembly;
      PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyDynamicAssembly"), coreAssembly);
      TypeBuilder typeBuilder = ab.DefineDynamicModule("MyModule").DefineType("Test", TypeAttributes.Public);
      MethodBuilder methodBuilder = typeBuilder.DefineMethod("Method", MethodAttributes.Public, coreAssembly.GetType("System.Int32"), Type.EmptyTypes);
      // .. add members and save the assembly
  }
  ```

### Set entry point for an executable

In order to set entry point for an executable and/or set other options for the assembly file you could call the `public MetadataBuilder GenerateMetadata(out BlobBuilder ilStream, out BlobBuilder mappedFieldData)` method and use the populated metadata for generating the assembly with desired options, for example:

```csharp
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
```

### Emitting symbols and generating PDB

The symbols metadata populated into the `pdbBuilder` out parameter when `GenerateMetadata(out BlobBuilder ilStream, out BlobBuilder mappedFieldData, out MetadataBuilder pdbBuilder)` method called on `PersistedAssemblyBuilder` instance. The steps for creating an assembly with portable PDB:

1. Create `ISymbolDocumentWriter` instances with `ModuleBuilder.DefineDocument(...)` method, while emitting method's IL also emit the corresponding symbol info.
2. Create `PortablePdbBuilder` instance using the `pdbBuilder` instance produced with `GenerateMetadata(...)` method.
3. Serialize the `PortablePdbBuilder` into a `Blob`, write the `Blob` into a PDB file stream (only in case generating standalone PDB).
4. Create `DebugDirectoryBuilder` instance and add a `CodeViewEntry` (standalone PDB) or `EmbeddedPortablePdbEntry`.
5. Set the optional `debugDirectoryBuilder` argument when creating `PEBuilder` instance.

Following example shows how to emit symbol info and generate PDB:

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

Further you could add CustomDebugInformation by calling the AddCustomDebugInformation method from the `pdbBuilder` instance to add source embedding and source indexing etc. advanced PDB info.

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

### Adding resources with PersistedAssemblyBuilder

With `MetadataBuilder.AddManifestResource(...)` you could add as many resources as needed, but streams have to be concatenated together into one `BlobBuilder` that you pass into `ManagedPEBuilder` argument.
Following example shows how to create resources and attach it to the assembly created:

```csharp
public static void GenerateAssemblyWithResources()
{
    PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(new AssemblyName("MyAssembly"), typeof(object).Assembly);
    ab.DefineDynamicModule("MyModule");
    MetadataBuilder metadata = ab.GenerateMetadata(out BlobBuilder ilStream, out _);

    using MemoryStream stream = new MemoryStream();
    ResourceWriter myResourceWriter = new ResourceWriter(stream);
    myResourceWriter.AddResource("String 1", "First string");
    myResourceWriter.AddResource("String 2", "Second string");
    myResourceWriter.AddResource("String 3", "Third string");
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
```

> [!NOTE]
> The metadata tokens for all members are populated on the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A> operation. Don't use the tokens of a generated type and its members before saving, as they'll have default values or throw exceptions. It's safe to use tokens for types that are referenced, not generated.
>
> Some APIs that aren't important for emitting an assembly aren't implemented; for example, `GetCustomAttributes()` is not implemented. With the runtime implementation, you were able to use those APIs after creating the type. For the persisted `AssemblyBuilder`, they throw `NotSupportedException` or `NotImplementedException`. If you have a scenario that requires those APIs, file an issue in the [dotnet/runtime repo](https://github.com/dotnet/runtime).

For an alternative way to generate assembly files, see <xref:System.Reflection.Metadata.Ecma335.MetadataBuilder>.

## Persisted dynamic assemblies in .NET Framework

In .NET Framework, dynamic assemblies and modules can be saved to files. To support this feature, the <xref:System.Reflection.Emit.AssemblyBuilderAccess> enumeration declares two additional fields: <xref:System.Reflection.Emit.AssemblyBuilderAccess.Save> and <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndSave>.

The dynamic modules in the persistable dynamic assembly are saved when the dynamic assembly is saved using the <xref:System.Reflection.Emit.AssemblyBuilder.Save%2A> method. To generate an executable, the <xref:System.Reflection.Emit.AssemblyBuilder.SetEntryPoint%2A> method must be called to identify the method that is the entry point to the assembly. Assemblies are saved as DLLs by default, unless the <xref:System.Reflection.Emit.AssemblyBuilder.SetEntryPoint%2A> method requests the generation of a console application or a Windows-based application.

The following example demonstrates how to create, save, and run an assembly using .NET Framework.

```csharp
public void CreateRunAndSaveAssembly(string assemblyPath)
{
    AssemblyBuilder ab = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName("MyAssembly"), AssemblyBuilderAccess.RunAndSave);
    ModuleBuilder mob = ab.DefineDynamicModule("MyAssembly.dll");
    TypeBuilder tb = mob.DefineType("MyType", TypeAttributes.Public | TypeAttributes.Class);
    MethodBuilder meb = tb.DefineMethod("SumMethod", MethodAttributes.Public | MethodAttributes.Static,
                                                                   typeof(int), new Type[] {typeof(int), typeof(int)});
    ILGenerator il = meb.GetILGenerator();
    il.Emit(OpCodes.Ldarg_0);
    il.Emit(OpCodes.Ldarg_1);
    il.Emit(OpCodes.Add);
    il.Emit(OpCodes.Ret);

    Type type = tb.CreateType();

    MethodInfo method = type.GetMethod("SumMethod");
    Console.WriteLine(method.Invoke(null, new object[] { 5, 10 }));
    ab.Save("MyAssembly.dll");
}
```

Some methods on the base <xref:System.Reflection.Assembly> class, such as `GetModules` and `GetLoadedModules`, won't work correctly when called from <xref:System.Reflection.Emit.AssemblyBuilder> objects. You can load the defined dynamic assembly and call the methods on the loaded assembly. For example, to ensure that resource modules are included in the returned module list, call `GetModules` on the loaded <xref:System.Reflection.Assembly> object. If a dynamic assembly contains more than one dynamic module, the assembly's manifest file name should match the module's name that's specified as the first argument to the <xref:System.Reflection.Emit.AssemblyBuilder.DefineDynamicModule%2A> method.

The signing of a dynamic assembly using <xref:System.Reflection.AssemblyName.KeyPair%2A> is not effective until the assembly is saved to disk. So, strong names will not work with transient dynamic assemblies.

Dynamic assemblies can reference types defined in another assembly. A transient dynamic assembly can safely reference types defined in another transient dynamic assembly, a persistable dynamic assembly, or a static assembly. However, the common language runtime does not allow a persistable dynamic module to reference a type defined in a transient dynamic module. This is because when the persisted dynamic module is loaded after being saved to disk, the runtime cannot resolve the references to types defined in the transient dynamic module.

### Restrictions on emitting to remote application domains

Some scenarios require a dynamic assembly to be created and executed in a remote application domain. Reflection emit does not allow a dynamic assembly to be emitted directly to a remote application domain. The solution is to emit the dynamic assembly in the current application domain, save the emitted dynamic assembly to disk, and then load the dynamic assembly into the remote application domain. The remoting and application domains are supported only in .NET Framework.
