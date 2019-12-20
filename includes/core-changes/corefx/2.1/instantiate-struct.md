### Private fields added to built-in struct types

Private fields were added to built-in struct types in [reference assemblies](../../../../docs/standard/assembly/reference-assemblies.md). As a result, in C#, struct types must always be instantiated by using the [new operator](../../../../docs/csharp/language-reference/operators/new-operator.md) or [default literal](../../../../docs/csharp/language-reference/operators/default.md#default-literal), or by initializing each of the private fields.

#### Change description

In .NET Core 2.0 and previous versions, some built-in struct types, for example, <xref:System.ConsoleKeyInfo>, could be instantiated without using the `new` operator or [default literal](../../../../docs/csharp/language-reference/operators/default.md#default-literal) in C#. This was because the [reference assemblies](../../../../docs/standard/assembly/reference-assemblies.md) used by the C# compiler didn't contain the private fields for the structs. All private fields for .NET struct types are added to the reference assemblies starting in .NET Core 2.1.

For example, the following C# code compiles in .NET Core 2.0, but not in .NET Core 2.1:

```csharp
ConsoleKeyInfo key;    // Struct type

if (key.ToString() == "y")
{
    Console.WriteLine("Yes!");
}
```

In .NET Core 2.1, the previous code results in the following compiler error: **CS0165 - Use of unassigned local variable 'key'**

#### Version introduced

2.1

#### Recommended action

Instantiate struct types by using the `new` operator or [default literal](../../../../docs/csharp/language-reference/operators/default.md#default-literal).

For example:

```csharp
ConsoleKeyInfo key = new ConsoleKeyInfo();    // Struct type.

if (key.ToString() == "y")
    Console.WriteLine("Yes!");
```

```csharp
ConsoleKeyInfo key = default;    // Struct type.

if (key.ToString() == "y")
    Console.WriteLine("Yes!");
```

```csharp
ConsoleKeyInfo[] keys = new ConsoleKeyInfo[5];    // Array of structs.

for (int i = 0; i < keys.Length; i++)
{
    // Initialize each array element with the new operator.
    keys[i] = new ConsoleKeyInfo();
}
```

#### Category

CoreFx

#### Affected APIs

- <xref:System.ArraySegment%601.Enumerator?displayProperty=fullName>
- <xref:System.ArraySegment%601?displayProperty=fullName>
- <xref:System.Boolean?displayProperty=fullName>
- <xref:System.Buffers.MemoryHandle?displayProperty=fullName>
- <xref:System.Buffers.StandardFormat?displayProperty=fullName>
- <xref:System.Byte?displayProperty=fullName>
- <xref:System.Char?displayProperty=fullName>
- <xref:System.Collections.DictionaryEntry?displayProperty=fullName>
- <xref:System.Collections.Generic.Dictionary%602.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.Dictionary%602.KeyCollection.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.Dictionary%602.ValueCollection.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.HashSet%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.KeyValuePair%602?displayProperty=fullName>
- <xref:System.Collections.Generic.LinkedList%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.List%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.Queue%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.SortedDictionary%602.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.SortedDictionary%602.KeyCollection.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.SortedDictionary%602.ValueCollection.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.SortedSet%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Generic.Stack%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableArray%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableArray%601?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableDictionary%602.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableHashSet%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableList%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableQueue%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableSortedDictionary%602.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableSortedSet%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Immutable.ImmutableStack%601.Enumerator?displayProperty=fullName>
- <xref:System.Collections.Specialized.BitVector32.Section?displayProperty=fullName>
- <xref:System.Collections.Specialized.BitVector32?displayProperty=fullName>
- <xref:System.ComponentModel.Composition.ReflectionModel.LazyMemberInfo>
- <xref:System.ComponentModel.Design.Serialization.MemberRelationship?displayProperty=fullName>
- <xref:System.ConsoleKeyInfo?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlBinary?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlBoolean?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlByte?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlDateTime?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlDecimal?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlDouble?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlGuid?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlInt16?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlInt32?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlInt64?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlMoney?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlSingle?displayProperty=fullName>
- <xref:System.Data.SqlTypes.SqlString?displayProperty=fullName>
- <xref:System.DateTime?displayProperty=fullName>
- <xref:System.DateTimeOffset?displayProperty=fullName>
- <xref:System.Decimal?displayProperty=fullName>
- <xref:System.Diagnostics.CounterSample?displayProperty=fullName>
- <xref:System.Diagnostics.SymbolStore.SymbolToken?displayProperty=fullName>
- <xref:System.Diagnostics.Tracing.EventSource.EventData?displayProperty=fullName>
- <xref:System.Diagnostics.Tracing.EventSourceOptions?displayProperty=fullName>
- <xref:System.Double?displayProperty=fullName>
- <xref:System.Drawing.CharacterRange?displayProperty=fullName>
- <xref:System.Drawing.Point?displayProperty=fullName>
- <xref:System.Drawing.PointF?displayProperty=fullName>
- <xref:System.Drawing.Rectangle?displayProperty=fullName>
- <xref:System.Drawing.RectangleF?displayProperty=fullName>
- <xref:System.Drawing.Size?displayProperty=fullName>
- <xref:System.Drawing.SizeF?displayProperty=fullName>
- <xref:System.Guid?displayProperty=fullName>
- <xref:System.HashCode?displayProperty=fullName>
- <xref:System.Int16?displayProperty=fullName>
- <xref:System.Int32?displayProperty=fullName>
- <xref:System.Int64?displayProperty=fullName>
- <xref:System.IntPtr?displayProperty=fullName>
- <xref:System.IO.Pipelines.FlushResult?displayProperty=fullName>
- <xref:System.IO.Pipelines.ReadResult?displayProperty=fullName>
- <xref:System.IO.WaitForChangedResult?displayProperty=fullName>
- <xref:System.Memory%601?displayProperty=fullName>
- <xref:System.ModuleHandle?displayProperty=fullName>
- <xref:System.Net.Security.SslApplicationProtocol?displayProperty=fullName>
- <xref:System.Net.Sockets.IPPacketInformation?displayProperty=fullName>
- <xref:System.Net.Sockets.SocketInformation?displayProperty=fullName>
- <xref:System.Net.Sockets.UdpReceiveResult?displayProperty=fullName>
- <xref:System.Net.WebSockets.ValueWebSocketReceiveResult?displayProperty=fullName>
- <xref:System.Nullable%601?displayProperty=fullName>
- <xref:System.Numerics.BigInteger?displayProperty=fullName>
- <xref:System.Numerics.Complex?displayProperty=fullName>
- <xref:System.Numerics.Vector%601?displayProperty=fullName>
- <xref:System.ReadOnlyMemory%601?displayProperty=fullName>
- <xref:System.ReadOnlySpan%601.Enumerator?displayProperty=fullName>
- <xref:System.ReadOnlySpan%601?displayProperty=fullName>
- <xref:System.Reflection.CustomAttributeNamedArgument?displayProperty=fullName>
- <xref:System.Reflection.CustomAttributeTypedArgument?displayProperty=fullName>
- <xref:System.Reflection.Emit.Label?displayProperty=fullName>
- <xref:System.Reflection.Emit.OpCode?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ArrayShape?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyFile?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyFileHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyFileHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyFileHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyReference?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyReferenceHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyReferenceHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.AssemblyReferenceHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Blob?displayProperty=fullName>
- <xref:System.Reflection.Metadata.BlobBuilder.Blobs?displayProperty=fullName>
- <xref:System.Reflection.Metadata.BlobContentId?displayProperty=fullName>
- <xref:System.Reflection.Metadata.BlobHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.BlobReader?displayProperty=fullName>
- <xref:System.Reflection.Metadata.BlobWriter?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Constant?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ConstantHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttribute?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttributeHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttributeHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttributeHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttributeNamedArgument%601?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttributeTypedArgument%601?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomAttributeValue%601?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomDebugInformation?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomDebugInformationHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomDebugInformationHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.CustomDebugInformationHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DeclarativeSecurityAttribute?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DeclarativeSecurityAttributeHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DeclarativeSecurityAttributeHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DeclarativeSecurityAttributeHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Document?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DocumentHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DocumentHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DocumentHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.DocumentNameBlobHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.ArrayShapeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.BlobEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.CustomAttributeArrayTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.CustomAttributeElementTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.CustomAttributeNamedArgumentsEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.CustomModifiersEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.EditAndContinueLogEntry?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.ExceptionRegionEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.FixedArgumentsEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.GenericTypeArgumentsEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.InstructionEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.LabelHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.LiteralEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.LiteralsEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.LocalVariablesEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.LocalVariableTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.MethodBodyStreamEncoder.MethodBody?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.MethodBodyStreamEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.MethodSignatureEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.NamedArgumentsEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.NamedArgumentTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.NameEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.ParametersEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.ParameterTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.PermissionSetEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.ReturnTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.ScalarEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.SignatureDecoder%602?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.SignatureTypeEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Ecma335.VectorEncoder?displayProperty=fullName>
- <xref:System.Reflection.Metadata.EntityHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.EventAccessors?displayProperty=fullName>
- <xref:System.Reflection.Metadata.EventDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.EventDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.EventDefinitionHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.EventDefinitionHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ExceptionRegion?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ExportedType?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ExportedTypeHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ExportedTypeHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ExportedTypeHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.FieldDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.FieldDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.FieldDefinitionHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.FieldDefinitionHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameter?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterConstraint?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterConstraintHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterConstraintHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterConstraintHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GenericParameterHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.GuidHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Handle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportDefinitionCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportDefinitionCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportScope?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportScopeCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportScopeCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ImportScopeHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.InterfaceImplementation?displayProperty=fullName>
- <xref:System.Reflection.Metadata.InterfaceImplementationHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.InterfaceImplementationHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.InterfaceImplementationHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalConstant?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalConstantHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalConstantHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalConstantHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalScope?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalScopeHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalScopeHandleCollection.ChildrenEnumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalScopeHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalScopeHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalVariable?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalVariableHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalVariableHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.LocalVariableHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ManifestResource?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ManifestResourceHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ManifestResourceHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ManifestResourceHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MemberReference?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MemberReferenceHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MemberReferenceHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MemberReferenceHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MetadataStringComparer?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDebugInformation?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDebugInformationHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDebugInformationHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDebugInformationHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDefinitionHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodDefinitionHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodImplementation?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodImplementationHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodImplementationHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodImplementationHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodImport?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodSignature%601?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodSpecification?displayProperty=fullName>
- <xref:System.Reflection.Metadata.MethodSpecificationHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ModuleDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ModuleDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ModuleReference?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ModuleReferenceHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.NamespaceDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.NamespaceDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.Parameter?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ParameterHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ParameterHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ParameterHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.PropertyAccessors?displayProperty=fullName>
- <xref:System.Reflection.Metadata.PropertyDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.PropertyDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.PropertyDefinitionHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.PropertyDefinitionHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.ReservedBlob%601?displayProperty=fullName>
- <xref:System.Reflection.Metadata.SequencePoint?displayProperty=fullName>
- <xref:System.Reflection.Metadata.SequencePointCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.SequencePointCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.SignatureHeader?displayProperty=fullName>
- <xref:System.Reflection.Metadata.StandaloneSignature?displayProperty=fullName>
- <xref:System.Reflection.Metadata.StandaloneSignatureHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.StringHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeDefinition?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeDefinitionHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeDefinitionHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeDefinitionHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeLayout?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeReference?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeReferenceHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeReferenceHandleCollection.Enumerator?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeReferenceHandleCollection?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeSpecification?displayProperty=fullName>
- <xref:System.Reflection.Metadata.TypeSpecificationHandle?displayProperty=fullName>
- <xref:System.Reflection.Metadata.UserStringHandle?displayProperty=fullName>
- <xref:System.Reflection.ParameterModifier?displayProperty=fullName>
- <xref:System.Reflection.PortableExecutable.CodeViewDebugDirectoryData?displayProperty=fullName>
- <xref:System.Reflection.PortableExecutable.DebugDirectoryEntry?displayProperty=fullName>
- <xref:System.Reflection.PortableExecutable.PEMemoryBlock?displayProperty=fullName>
- <xref:System.Reflection.PortableExecutable.SectionHeader?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.AsyncTaskMethodBuilder%601?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.AsyncTaskMethodBuilder?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder%601?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.AsyncValueTaskMethodBuilder?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.AsyncVoidMethodBuilder?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ConfiguredTaskAwaitable%601.ConfiguredTaskAwaiter?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ConfiguredTaskAwaitable%601?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ConfiguredTaskAwaitable?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable%601?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable%601.ConfiguredValueTaskAwaiter?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.TaskAwaiter%601?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.TaskAwaiter?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ValueTaskAwaiter%601?displayProperty=fullName>
- <xref:System.Runtime.CompilerServices.ValueTaskAwaiter%601?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.ArrayWithOffset?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.GCHandle?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.HandleRef?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.OSPlatform?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken?displayProperty=fullName>
- <xref:System.Runtime.Serialization.SerializationEntry?displayProperty=fullName>
- <xref:System.Runtime.Serialization.StreamingContext?displayProperty=fullName>
- <xref:System.RuntimeArgumentHandle?displayProperty=fullName>
- <xref:System.RuntimeFieldHandle?displayProperty=fullName>
- <xref:System.RuntimeMethodHandle?displayProperty=fullName>
- <xref:System.RuntimeTypeHandle?displayProperty=fullName>
- <xref:System.SByte?displayProperty=fullName>
- <xref:System.Security.Cryptography.CngProperty?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECCurve?displayProperty=fullName>
- <xref:System.Security.Cryptography.HashAlgorithmName?displayProperty=fullName>
- <xref:System.Security.Cryptography.X509Certificates.X509ChainStatus?displayProperty=fullName>
- <xref:System.Security.Cryptography.Xml.X509IssuerSerial?displayProperty=fullName>
- <xref:System.ServiceProcess.SessionChangeDescription?displayProperty=fullName>
- <xref:System.Single?displayProperty=fullName>
- <xref:System.Span%601.Enumerator?displayProperty=fullName>
- <xref:System.Span%601?displayProperty=fullName>
- <xref:System.Threading.AsyncFlowControl?displayProperty=fullName>
- <xref:System.Threading.AsyncLocalValueChangedArgs%601?displayProperty=fullName>
- <xref:System.Threading.CancellationToken?displayProperty=fullName>
- <xref:System.Threading.CancellationTokenRegistration?displayProperty=fullName>
- <xref:System.Threading.LockCookie?displayProperty=fullName>
- <xref:System.Threading.SpinLock?displayProperty=fullName>
- <xref:System.Threading.SpinWait?displayProperty=fullName>
- <xref:System.Threading.Tasks.Dataflow.DataflowMessageHeader?displayProperty=fullName>
- <xref:System.Threading.Tasks.ParallelLoopResult?displayProperty=fullName>
- <xref:System.Threading.Tasks.ValueTask%601?displayProperty=fullName>
- <xref:System.TimeSpan?displayProperty=fullName>
- <xref:System.TimeZoneInfo.TransitionTime?displayProperty=fullName>
- <xref:System.Transactions.TransactionOptions?displayProperty=fullName>
- <xref:System.TypedReference?displayProperty=fullName>
- <xref:System.TypedReference?displayProperty=fullName>
- <xref:System.UInt16?displayProperty=fullName>
- <xref:System.UInt32?displayProperty=fullName>
- <xref:System.UInt64?displayProperty=fullName>
- <xref:System.UIntPtr?displayProperty=fullName>
- <xref:System.Windows.Forms.ColorDialog.Color?displayProperty=fullName>
- <xref:System.Windows.Media.Animation.KeyTime?displayProperty=fullName>
- <xref:System.Windows.Media.Animation.RepeatBehavior?displayProperty=fullName>
- <xref:System.Xml.Serialization.XmlDeserializationEvents?displayProperty=fullName>
- <xref:Windows.Foundation.Point?displayProperty=fullName>
- <xref:Windows.Foundation.Rect?displayProperty=fullName>
- <xref:Windows.Foundation.Size?displayProperty=fullName>
- <xref:Windows.UI.Color?displayProperty=fullName>
- <xref:Windows.UI.Xaml.Controls.Primitives.GeneratorPosition?displayProperty=fullName>
- <xref:Windows.UI.Xaml.CornerRadius?displayProperty=fullName>
- <xref:Windows.UI.Xaml.Duration?displayProperty=fullName>
- <xref:Windows.UI.Xaml.GridLength?displayProperty=fullName>
- <xref:Windows.UI.Xaml.Media.Matrix?displayProperty=fullName>
- <xref:Windows.UI.Xaml.Media.Media3D.Matrix3D?displayProperty=fullName>
- <xref:Windows.UI.Xaml.Thickness?displayProperty=fullName>

<!--

### Affected APIs

- `T:System.ConsoleKeyInfo`
- `T:System.Memory{T}`
- `T:System.Collections.Immutable.ImmutableArray{T}`

Plus too many others to list.

-->
