---
title: What's new in .NET 8 runtime
description: Learn about the new .NET features introduced in the .NET 8 runtime.
titleSuffix: ""
ms.date: 11/14/2023
ms.topic: whats-new
---
# What's new in the .NET 8 runtime

This article describes new features in the .NET runtime for .NET 8.

## Performance improvements

.NET 8 includes improvements to code generation and just-in time (JIT) compilation:

- Arm64 performance improvements
- SIMD improvements
- Support for AVX-512 ISA extensions (see [Vector512 and AVX-512](#vector512-and-avx-512))
- Cloud-native improvements
- JIT throughput improvements
- Loop and general optimizations
- Optimized access for fields marked with <xref:System.ThreadStaticAttribute>
- Consecutive register allocation. Arm64 has two instructions for table vector lookup, which require that all entities in their tuple operands are present in consecutive registers.
- JIT/NativeAOT can now unroll and auto-vectorize some memory operations with SIMD, such as comparison, copying, and zeroing, if it can determine their sizes at compile time.

In addition, dynamic profile-guided optimization (PGO) has been improved and is now enabled by default. You no longer need to use a [runtime configuration option](../../runtime-config/compilation.md#profile-guided-optimization) to enable it. Dynamic PGO works hand-in-hand with tiered compilation to further optimize code based on additional instrumentation that's put in place during tier 0.

On average, dynamic PGO increases performance by about 15%. In a benchmark suite of ~4600 tests, 23% saw performance improvements of 20% or more.

### Codegen struct promotion

.NET 8 includes a new physical promotion optimization pass for codegen that generalizes the JIT's ability to promote struct variables. This optimization (also called *scalar replacement of aggregates*) replaces the fields of struct variables by primitive variables that the JIT is then able to reason about and optimize more precisely.

The JIT already supported this optimization but with several large limitations including:

- It was only supported for structs with four or fewer fields.
- It was only supported if each field was a primitive type, or a simple struct wrapping a primitive type.

Physical promotion removes these limitations, which fixes a number of long-standing JIT issues.

## Garbage collection

.NET 8 adds a capability to adjust the memory limit on the fly. This is useful in cloud-service scenarios, where demand comes and goes. To be cost-effective, services should scale up and down on resource consumption as the demand fluctuates. When a service detects a decrease in demand, it can scale down resource consumption by reducing its memory limit. Previously, this would fail because the garbage collector (GC) was unaware of the change and might allocate more memory than the new limit. With this change, you can call the <xref:System.GC.RefreshMemoryLimit> API to update the GC with the new memory limit.

There are some limitations to be aware of:

- On 32-bit platforms (for example, Windows x86 and Linux ARM), .NET is unable to establish a new heap hard limit if there isn't already one.
- The API might return a non-zero status code indicating the refresh failed. This can happen if the scale-down is too aggressive and leaves no room for the GC to maneuver. In this case, consider calling `GC.Collect(2, GCCollectionMode.Aggressive)` to shrink the current memory usage, and then try again.
- If you scale up the memory limit beyond the size that the GC believes the process can handle during startup, the `RefreshMemoryLimit` call will succeed, but it won't be able to use more memory than what it perceives as the limit.

The following code snippet shows how to call the API.

```csharp
GC.RefreshMemoryLimit();
```

You can also refresh some of the GC configuration settings related to the memory limit. The following code snippet sets the heap hard limit to 100 mebibytes (MiB):

```csharp
AppContext.SetData("GCHeapHardLimit", (ulong)100 * 1_024 * 1_024);
GC.RefreshMemoryLimit();
```

The API can throw an <xref:System.InvalidOperationException> if the hard limit is invalid, for example, in the case of negative heap hard limit percentages and if the hard limit is too low. This can happen if the heap hard limit that the refresh will set, either because of new AppData settings or implied by the container memory limit changes, is lower than what's already committed.

## Globalization for mobile apps

Mobile apps on iOS, tvOS, and MacCatalyst can opt in to a new *hybrid* globalization mode that uses a lighter ICU bundle. In hybrid mode, globalization data is partially pulled from the ICU bundle and partially from calls into Native APIs. Hybrid mode serves all the [locales supported by mobile](https://github.com/dotnet/icu/blob/dotnet/main/icu-filters/icudt_mobile.json).

Hybrid mode is most suitable for apps that can't work in invariant globalization mode and that use cultures that were trimmed from ICU data on mobile. You can also use it when you want to load a smaller ICU data file. (The *icudt_hybrid.dat* file is 34.5 % smaller than the default ICU data file *icudt.dat*.)

To use hybrid globalization mode, set the `HybridGlobalization` MSBuild property to true:

```xml
<PropertyGroup>
  <HybridGlobalization>true</HybridGlobalization>
</PropertyGroup>
```

There are some limitations to be aware of:

- Due to limitations of Native API, not all globalization APIs are supported in hybrid mode.
- Some of the supported APIs have different behavior.

To check if your application is affected, see [Behavioral differences](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-hybrid-mode.md#behavioral-differences).

## Source-generated COM interop

.NET 8 includes a new source generator that supports interoperating with COM interfaces. You can use the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> to mark an interface as a COM interface for the source generator. The source generator will then generate code to enable calling from C# code to unmanaged code. It also generates code to enable calling from unmanaged code into C#. This source generator integrates with <xref:System.Runtime.InteropServices.LibraryImportAttribute>, and you can use types with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> as parameters and return types in `LibraryImport`-attributed methods.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/Interop.cs":::

The source generator also supports the new <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> attribute to enable you to pass types that implement interfaces with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute to unmanaged code. The source generator will generate the code necessary to expose a COM object that implements the interfaces and forwards calls to the managed implementation.

Methods on interfaces with the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute support all the same types as `LibraryImportAttribute`, and `LibraryImportAttribute` now supports `GeneratedComInterface`-attributed types and `GeneratedComClass`-attributed types.

If your C# code only uses a `GeneratedComInterface`-attributed interface to either wrap a COM object from unmanaged code or wrap a managed object from C# to expose to unmanaged code, you can use the options in the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute.Options> property to customize which code will be generated. These options mean you don't need to write marshallers for scenarios that you know won't be used.

The source generator uses the new <xref:System.Runtime.InteropServices.Marshalling.StrategyBasedComWrappers> type to create and manage the COM object wrappers and the managed object wrappers. This new type handles providing the expected .NET user experience for COM interop, while providing customization points for advanced users. If your application has its own mechanism for defining types from COM or if you need to support scenarios that source-generated COM doesn't currently support, consider using the new <xref:System.Runtime.InteropServices.Marshalling.StrategyBasedComWrappers> type to add the missing features for your scenario and get the same .NET user experience for your COM types.

If you're using Visual Studio, new analyzers and code fixes make it easy to convert your existing COM interop code to use source-generated interop. Next to each interface that has the <xref:System.Runtime.InteropServices.ComImportAttribute>, a lightbulb offers an option to convert to source-generated interop. The fix changes the interface to use the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> attribute. And next to every class that implements an interface with `GeneratedComInterfaceAttribute`, a lightbulb offers an option to add the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> attribute to the type. Once your types are converted, you can move your `DllImport` methods to use `LibraryImportAttribute`.

### Limitations

The COM source generator doesn't support apartment affinity, using the `new` keyword to activate a COM CoClass, and the following APIs:

- <xref:System.Runtime.InteropServices.UnmanagedType.IDispatch>-based interfaces.
- <xref:System.Runtime.InteropServices.UnmanagedType.IInspectable>-based interfaces.
- COM properties and events.

## Configuration-binding source generator

.NET 8 introduces a source generator to provide AOT and trim-friendly [configuration](/aspnet/core/fundamentals/configuration/) in ASP.NET Core. The generator is an alternative to the pre-existing reflection-based implementation.

The source generator probes for <xref:Microsoft.Extensions.Options.ConfigureOptions%601.Configure(%600)>, <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A>, and <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%2A> calls to retrieve type info from. When the generator is enabled in a project, the compiler implicitly chooses generated methods over the pre-existing reflection-based framework implementations.

No source code changes are needed to use the generator. It's enabled by default in AOT-compiled web apps, and when [`PublishTrimmed`](../../deploying/trimming/trimming-options.md#enable-trimming) is set to `true` (.NET 8+ apps). For other project types, the source generator is off by default, but you can opt in by setting the `EnableConfigurationBindingGenerator` property to `true` in your project file:

```xml
<PropertyGroup>
    <EnableConfigurationBindingGenerator>true</EnableConfigurationBindingGenerator>
</PropertyGroup>
```

The following code shows an example of invoking the binder.

:::code language="csharp" source="../snippets/dotnet-8/csharp/WebSDK/ConfigBindingSG.cs":::

## Core .NET libraries

This section contains the following subtopics:

- [Reflection](#reflection)
- [Serialization](#serialization)
- [Time abstraction](#time-abstraction)
- [UTF8 improvements](#utf8-improvements)
- [Methods for working with randomness](#methods-for-working-with-randomness)
- [Performance-focused types](#performance-focused-types)
- [System.Numerics and System.Runtime.Intrinsics](#systemnumerics-and-systemruntimeintrinsics)
- [Data validation](#data-validation)
- [Metrics](#metrics)
- [Cryptography](#cryptography)
- [Networking](#networking)
- [Stream-based ZipFile methods](#stream-based-zipfile-methods)

### Reflection

[Function pointers](../../../csharp/language-reference/unsafe-code.md#function-pointers) were introduced in .NET 5, however, the corresponding support for reflection wasn't added at that time. When using `typeof` or reflection on a function pointer, for example, `typeof(delegate*<void>())` or `FieldInfo.FieldType` respectively, an <xref:System.IntPtr> was returned. Starting in .NET 8, a <xref:System.Type?displayProperty=nameWithType> object is returned instead. This type provides access to function pointer metadata, including the calling conventions, return type, and parameters.

> [!NOTE]
> A function pointer instance, which is a physical address to a function, continues to be represented as an <xref:System.IntPtr>. Only the reflection type has changed.

The new functionality is currently implemented only in the CoreCLR runtime and <xref:System.Reflection.MetadataLoadContext>.

New APIs have been added to <xref:System.Type?displayProperty=fullName>, such as <xref:System.Type.IsFunctionPointer>, and to <xref:System.Reflection.PropertyInfo?displayProperty=fullName>, <xref:System.Reflection.FieldInfo?displayProperty=fullName>, and <xref:System.Reflection.ParameterInfo?displayProperty=fullName>. The following code shows how to use some of the new APIs for reflection.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/FunctionPointerReflection.cs":::

The previous example produces the following output:

```Output
IsFunctionPointer: True
IsUnmanagedFunctionPointer: True
Return type: System.Void
Parameter type: System.Int32&
Calling convention: System.Runtime.CompilerServices.CallConvSuppressGCTransition
Calling convention: System.Runtime.CompilerServices.CallConvCdecl
Required modifier for first parameter: System.Runtime.InteropServices.InAttribute
```

### Serialization

Many improvements have been made to <xref:System.Text.Json?displayProperty=fullName> serialization and deserialization functionality in .NET 8. For example, you can [customize handling of JSON properties that aren't in the POCO](../../../standard/serialization/system-text-json/missing-members.md).

The following sections describe other serialization improvements:

- [Built-in support for additional types](#built-in-support-for-additional-types)
- [Source generator](#source-generator)
- [Interface hierarchies](#interface-hierarchies)
- [Naming policies](#naming-policies)
- [Read-only properties](#read-only-properties)
- [Disable reflection-based default](#disable-reflection-based-default)
- [New JsonNode API methods](#new-jsonnode-api-methods)
- [Non-public members](#non-public-members)
- [Streaming deserialization APIs](#streaming-deserialization-apis)
- [WithAddedModifier extension method](#withaddedmodifier-extension-method)
- [New JsonContent.Create overloads](#new-jsoncontentcreate-overloads)
- [Freeze a JsonSerializerOptions instance](#freeze-a-jsonserializeroptions-instance)

For more information about JSON serialization in general, see [JSON serialization and deserialization in .NET](../../../standard/serialization/system-text-json/overview.md).

#### Built-in support for additional types

The serializer has built-in support for the following additional types.

- <xref:System.Half>, <xref:System.Int128>, and <xref:System.UInt128> numeric types.

  ```csharp
  Console.WriteLine(JsonSerializer.Serialize(
      [ Half.MaxValue, Int128.MaxValue, UInt128.MaxValue ]
  ));
  // [65500,170141183460469231731687303715884105727,340282366920938463463374607431768211455]
  ```

- <xref:System.Memory%601> and <xref:System.ReadOnlyMemory%601> values. `byte` values are serialized to Base64 strings, and other types to JSON arrays.

  ```csharp
  JsonSerializer.Serialize<ReadOnlyMemory<byte>>(new byte[] { 1, 2, 3 }); // "AQID"
  JsonSerializer.Serialize<Memory<int>>(new int[] { 1, 2, 3 }); // [1,2,3]
  ```

#### Source generator

.NET 8 includes enhancements of the System.Text.Json [source generator](../../../standard/serialization/system-text-json/source-generation.md) that are aimed at making the [Native AOT](../../../standard/glossary.md#native-aot) experience on par with the [reflection-based serializer](../../../standard/serialization/system-text-json/reflection-vs-source-generation.md#reflection). For example:

- The source generator now supports serializing types with [`required`](../../../standard/serialization/system-text-json/required-properties.md) and [`init`](../../../csharp/language-reference/keywords/init.md) properties. These were both already supported in reflection-based serialization.
- Improved formatting of source-generated code.
- <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute> feature parity with <xref:System.Text.Json.JsonSerializerOptions>. For more information, see [Specify options (source generation)](../../../standard/serialization/system-text-json/source-generation.md#specify-options).
- Additional diagnostics (such as [SYSLIB1034](../../../fundamentals/syslib-diagnostics/syslib1034.md) and [SYSLIB1039](../../../fundamentals/syslib-diagnostics/syslib1039.md)).
- Don't include types of ignored or inaccessible properties.
- Support for nesting `JsonSerializerContext` declarations within arbitrary type kinds.
- Support for compiler-generated or *unspeakable* types in weakly typed source generation scenarios. Since compiler-generated types can't be explicitly specified by the source generator, <xref:System.Text.Json?displayProperty=fullName> now performs nearest-ancestor resolution at run time. This resolution determines the most appropriate supertype with which to serialize the value.
- New converter type `JsonStringEnumConverter<TEnum>`. The existing <xref:System.Text.Json.Serialization.JsonStringEnumConverter> class isn't supported in Native AOT. You can annotate your enum types as follows:

  ```csharp
  [JsonConverter(typeof(JsonStringEnumConverter<MyEnum>))]
  public enum MyEnum { Value1, Value2, Value3 }

  [JsonSerializable(typeof(MyEnum))]
  public partial class MyContext : JsonSerializerContext { }
  ```

  For more information, see [Serialize enum fields as strings](../../../standard/serialization/system-text-json/source-generation.md#serialize-enum-fields-as-strings).

- New `JsonConverter.Type` property lets you look up the type of a non-generic `JsonConverter` instance:

  ```csharp
  Dictionary<Type, JsonConverter> CreateDictionary(IEnumerable<JsonConverter> converters)
      => converters.Where(converter => converter.Type != null)
                   .ToDictionary(converter => converter.Type!);
  ```

  The property is nullable since it returns `null` for `JsonConverterFactory` instances and `typeof(T)` for `JsonConverter<T>` instances.

##### Chain source generators

The <xref:System.Text.Json.JsonSerializerOptions> class includes a new <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> property that complements the existing <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> property. These properties are used in contract customization for chaining source generators. The addition of the new property means that you don't have to specify all chained components at one call site&mdash;they can be added after the fact. <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> also lets you introspect the chain or remove components from it. For more information, see [Combine source generators](../../../standard/serialization/system-text-json/source-generation.md#combine-source-generators).

In addition, <xref:System.Text.Json.JsonSerializerOptions.AddContext%60%601?displayProperty=nameWithType> is now obsolete. It's been superseded by the <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver> and <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolverChain> properties. For more information, see [SYSLIB0049](../../../fundamentals/syslib-diagnostics/syslib0049.md).

#### Interface hierarchies

.NET 8 adds support for serializing properties from interface hierarchies.

The following code shows an example where the properties from both the immediately implemented interface and its base interface are serialized.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/Serialization.cs" id="InterfaceHierarchies":::

#### Naming policies

[`JsonNamingPolicy`](xref:System.Text.Json.JsonNamingPolicy#properties) includes new naming policies for `snake_case` (with an underscore) and `kebab-case` (with a hyphen) property name conversions. Use these policies similarly to the existing <xref:System.Text.Json.JsonNamingPolicy.CamelCase?displayProperty=nameWithType> policy:

```csharp
var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
};
JsonSerializer.Serialize(new { PropertyName = "value" }, options);
// { "property_name" : "value" }
```

For more information, see [Use a built-in naming policy](../../../standard/serialization/system-text-json/customize-properties.md#use-a-built-in-naming-policy).

#### Read-only properties

You can now deserialize onto read-only fields or properties (that is, those that don't have a `set` accessor).

To opt in to this support globally, set a new option, <xref:System.Text.Json.JsonSerializerOptions.PreferredObjectCreationHandling>, to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate?displayProperty=nameWithType>. If compatibility is a concern, you can also enable the functionality more granularly by placing the `[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]` attribute on specific types whose properties are to be populated, or on individual properties.

For example, consider the following code that deserializes into a `CustomerInfo` type that has two read-only properties.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/Serialization.cs" id="ReadOnlyProperties":::

Prior to .NET 8, the input values were ignored and the `Names` and `Company` properties retained their default values.

```output
{"Names":[],"Company":{"Name":"N/A","PhoneNumber":"N/A"}}
```

Now, the input values are used to populate the read-only properties during deserialization.

```output
{"Names":["John Doe"],"Company":{"Name":"Contoso","PhoneNumber":"N/A"}}
```

For more information about the *populate* deserialization behavior, see [Populate initialized properties](../../../standard/serialization/system-text-json/populate-properties.md).

#### Disable reflection-based default

You can now disable using the reflection-based serializer by default. This disablement is useful to avoid accidental rooting of reflection components that aren't even in use, especially in trimmed and Native AOT apps. To disable default reflection-based serialization by requiring that a <xref:System.Text.Json.JsonSerializerOptions> argument be passed to the <xref:System.Text.Json.JsonSerializer> serialization and deserialization methods, set the `JsonSerializerIsReflectionEnabledByDefault` MSBuild property to `false` in your project file.

Use the new <xref:System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault> API to check the value of the feature switch. If you're a library author building on top of <xref:System.Text.Json?displayProperty=fullName>, you can rely on the property to configure your defaults without accidentally rooting reflection components.

For more information, see [Disable reflection defaults](../../../standard/serialization/system-text-json/source-generation.md#disable-reflection-defaults).

#### New JsonNode API methods

The <xref:System.Text.Json.Nodes.JsonNode> and <xref:System.Text.Json.Nodes.JsonArray?displayProperty=fullName> types include the following new methods.

```csharp
public partial class JsonNode
{
    // Creates a deep clone of the current node and all its descendants.
    public JsonNode DeepClone();

    // Returns true if the two nodes are equivalent JSON representations.
    public static bool DeepEquals(JsonNode? node1, JsonNode? node2);

    // Determines the JsonValueKind of the current node.
    public JsonValueKind GetValueKind(JsonSerializerOptions options = null);

    // If node is the value of a property in the parent
    // object, returns its name.
    // Throws InvalidOperationException otherwise.
    public string GetPropertyName();

    // If node is the element of a parent JsonArray,
    // returns its index.
    // Throws InvalidOperationException otherwise.
    public int GetElementIndex();

    // Replaces this instance with a new value,
    // updating the parent object/array accordingly.
    public void ReplaceWith<T>(T value);

    // Asynchronously parses a stream as UTF-8 encoded data
    // representing a single JSON value into a JsonNode.
    public static Task<JsonNode?> ParseAsync(
        Stream utf8Json,
        JsonNodeOptions? nodeOptions = null,
        JsonDocumentOptions documentOptions = default,
        CancellationToken cancellationToken = default);
}

public partial class JsonArray
{
    // Returns an IEnumerable<T> view of the current array.
    public IEnumerable<T> GetValues<T>();
}
```

#### Non-public members

You can opt non-public members into the serialization contract for a given type using <xref:System.Text.Json.Serialization.JsonIncludeAttribute> and <xref:System.Text.Json.Serialization.JsonConstructorAttribute> attribute annotations.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/Serialization.cs" id="NonPublicMembers":::

For more information, see [Use immutable types and non-public members and accessors](../../../standard/serialization/system-text-json/immutability.md).

#### Streaming deserialization APIs

.NET 8 includes new <xref:System.Collections.Generic.IAsyncEnumerable%601> streaming deserialization extension methods, for example <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsAsyncEnumerable%2A>. Similar methods have existed that return <xref:System.Threading.Tasks.Task%601>, for example, <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType>. The new extension methods invoke streaming APIs and return <xref:System.Collections.Generic.IAsyncEnumerable%601>.

The following code shows how you might use the new extension methods.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/Serialization.cs" id="StreamingDeserialization":::

#### WithAddedModifier extension method

The new <xref:System.Text.Json.Serialization.Metadata.JsonTypeInfoResolver.WithAddedModifier(System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver,System.Action{System.Text.Json.Serialization.Metadata.JsonTypeInfo})> extension method lets you easily introduce modifications to the serialization contracts of arbitrary `IJsonTypeInfoResolver` instances.

```csharp
var options = new JsonSerializerOptions
{
    TypeInfoResolver = MyContext.Default
        .WithAddedModifier(static typeInfo =>
        {
            foreach (JsonPropertyInfo prop in typeInfo.Properties)
            {
                prop.Name = prop.Name.ToUpperInvariant();
            }
        })
};
```

#### New JsonContent.Create overloads

You can now create <xref:System.Net.Http.Json.JsonContent> instances using trim-safe or source-generated contracts. The new methods are:

- <xref:System.Net.Http.Json.JsonContent.Create(System.Object,System.Text.Json.Serialization.Metadata.JsonTypeInfo,System.Net.Http.Headers.MediaTypeHeaderValue)?displayProperty=nameWithType>
- <xref:System.Net.Http.Json.JsonContent.Create%60%601(%60%600,System.Text.Json.Serialization.Metadata.JsonTypeInfo{%60%600},System.Net.Http.Headers.MediaTypeHeaderValue)?displayProperty=nameWithType>

```csharp
var book = new Book(id: 42, "Title", "Author", publishedYear: 2023);
HttpContent content = JsonContent.Create(book, MyContext.Default.Book);

public record Book(int id, string title, string author, int publishedYear);

[JsonSerializable(typeof(Book))]
public partial class MyContext : JsonSerializerContext
{
}
```

#### Freeze a JsonSerializerOptions instance

The following new methods let you control when a <xref:System.Text.Json.JsonSerializerOptions> instance is frozen:

- <xref:System.Text.Json.JsonSerializerOptions.MakeReadOnly?displayProperty=nameWithType>

  This overload is designed to be trim-safe and will therefore throw an exception in cases where the options instance hasn't been configured with a resolver.

- <xref:System.Text.Json.JsonSerializerOptions.MakeReadOnly(System.Boolean)?displayProperty=nameWithType>

  If you pass `true` to this overload, it populates the options instance with the default reflection resolver if one is missing. This method is marked `RequiresUnreferenceCode`/`RequiresDynamicCode` and is therefore unsuitable for Native AOT applications.

The new <xref:System.Text.Json.JsonSerializerOptions.IsReadOnly> property lets you check if the options instance is frozen.

### Time abstraction

The new <xref:System.TimeProvider> class and <xref:System.Threading.ITimer> interface add *time abstraction* functionality, which allows you to mock time in test scenarios. In addition, you can use the time abstraction to mock <xref:System.Threading.Tasks.Task> operations that rely on time progression using <xref:System.Threading.Tasks.Task.Delay%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task.WaitAsync%2A?displayProperty=nameWithType>. The time abstraction supports the following essential time operations:

- Retrieve local and UTC time
- Obtain a timestamp for measuring performance
- Create a timer

The following code snippet shows some usage examples.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/TimeProvider.cs" id="GetElapsedTime":::
:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/TimeProvider.cs" id="TimeProvider":::

### UTF8 improvements

If you want to enable writing out a string-like representation of your type to a destination span, implement the new <xref:System.IUtf8SpanFormattable> interface on your type. This new interface is closely related to <xref:System.ISpanFormattable>, but targets UTF8 and `Span<byte>` instead of UTF16 and `Span<char>`.

<xref:System.IUtf8SpanFormattable> has been implemented on all of the primitive types (plus others), with the exact same shared logic whether targeting `string`, `Span<char>`, or `Span<byte>`. It has full support for all formats (including the new ["B" binary specifier](../../../standard/base-types/standard-numeric-format-strings.md#binary-format-specifier-b)) and all cultures. This means you can now format directly to UTF8 from `Byte`, `Complex`, `Char`, `DateOnly`, `DateTime`, `DateTimeOffset`, `Decimal`, `Double`, `Guid`, `Half`, `IPAddress`, `IPNetwork`, `Int16`, `Int32`, `Int64`, `Int128`, `IntPtr`, `NFloat`, `SByte`, `Single`, `Rune`, `TimeOnly`, `TimeSpan`, `UInt16`, `UInt32`, `UInt64`, `UInt128`, `UIntPtr`, and `Version`.

New <xref:System.Text.Unicode.Utf8.TryWrite%2A?displayProperty=nameWithType> methods provide a UTF8-based counterpart to the existing <xref:System.MemoryExtensions.TryWrite%2A?displayProperty=nameWithType> methods, which are UTF16-based. You can use interpolated string syntax to format a complex expression directly into a span of UTF8 bytes, for example:

```csharp
static bool FormatHexVersion(
    short major,
    short minor,
    short build,
    short revision,
    Span<byte> utf8Bytes,
    out int bytesWritten) =>
    Utf8.TryWrite(
        utf8Bytes,
        CultureInfo.InvariantCulture,
        $"{major:X4}.{minor:X4}.{build:X4}.{revision:X4}",
        out bytesWritten);
```

The implementation recognizes <xref:System.IUtf8SpanFormattable> on the format values and uses their implementations to write their UTF8 representations directly to the destination span.

The implementation also utilizes the new <xref:System.Text.Encoding.TryGetBytes(System.ReadOnlySpan{System.Char},System.Span{System.Byte},System.Int32@)?displayProperty=nameWithType> method, which together with its <xref:System.Text.Encoding.TryGetChars(System.ReadOnlySpan{System.Byte},System.Span{System.Char},System.Int32@)?displayProperty=nameWithType> counterpart, supports encoding and decoding into a destination span. If the span isn't long enough to hold the resulting state, the methods return `false` rather than throwing an exception.

### Methods for working with randomness

The <xref:System.Random?displayProperty=fullName> and <xref:System.Security.Cryptography.RandomNumberGenerator?displayProperty=fullName> types introduce two new methods for working with randomness.

#### GetItems\<T>()

The new <xref:System.Random.GetItems%2A?displayProperty=fullName> and <xref:System.Security.Cryptography.RandomNumberGenerator.GetItems%2A?displayProperty=fullName> methods let you randomly choose a specified number of items from an input set. The following example shows how to use `System.Random.GetItems<T>()` (on the instance provided by the <xref:System.Random.Shared?displayProperty=nameWithType> property) to randomly insert 31 items into an array. This example could be used in a game of "Simon" where players must remember a sequence of colored buttons.

```csharp
private static ReadOnlySpan<Button> s_allButtons = new[]
{
    Button.Red,
    Button.Green,
    Button.Blue,
    Button.Yellow,
};

// ...

Button[] thisRound = Random.Shared.GetItems(s_allButtons, 31);
// Rest of game goes here ...
```

#### Shuffle\<T>()

The new <xref:System.Random.Shuffle%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RandomNumberGenerator.Shuffle%60%601(System.Span{%60%600})?displayProperty=nameWithType> methods let you randomize the order of a span. These methods are useful for reducing training bias in machine learning (so the first thing isn't always training, and the last thing always test).

```csharp
YourType[] trainingData = LoadTrainingData();
Random.Shared.Shuffle(trainingData);

IDataView sourceData = mlContext.Data.LoadFromEnumerable(trainingData);

DataOperationsCatalog.TrainTestData split = mlContext.Data.TrainTestSplit(sourceData);
model = chain.Fit(split.TrainSet);

IDataView predictions = model.Transform(split.TestSet);
// ...
```

### Performance-focused types

.NET 8 introduces several new types aimed at improving app performance.

- The new <xref:System.Collections.Frozen?displayProperty=fullName> namespace includes the collection types <xref:System.Collections.Frozen.FrozenDictionary%602> and <xref:System.Collections.Frozen.FrozenSet%601>. These types don't allow any changes to keys and values once a collection is created. That requirement allows faster read operations (for example, `TryGetValue()`). These types are particularly useful for collections that are populated on first use and then persisted for the duration of a long-lived service, for example:

  ```csharp
  private static readonly FrozenDictionary<string, bool> s_configurationData =
      LoadConfigurationData().ToFrozenDictionary();

  // ...
  if (s_configurationData.TryGetValue(key, out bool setting) && setting)
  {
      Process();
  }
  ```

- Methods like <xref:System.MemoryExtensions.IndexOfAny%2A?displayProperty=nameWithType> look for the first occurrence of *any value in the passed collection*. The new <xref:System.Buffers.SearchValues%601?displayProperty=fullName> type is designed to be passed to such methods. Correspondingly, .NET 8 adds new overloads of methods like <xref:System.MemoryExtensions.IndexOfAny%2A?displayProperty=nameWithType> that accept an instance of the new type. When you create an instance of <xref:System.Buffers.SearchValues%601>, all the data that's necessary to optimize subsequent searches is derived *at that time*, meaning the work is done up front.
- The new <xref:System.Text.CompositeFormat?displayProperty=fullName> type is useful for optimizing format strings that aren't known at compile time (for example, if the format string is loaded from a resource file). A little extra time is spent up front to do work such as parsing the string, but it saves the work from being done on each use.

  ```csharp
  private static readonly CompositeFormat s_rangeMessage =
      CompositeFormat.Parse(LoadRangeMessageResource());

  // ...
  static string GetMessage(int min, int max) =>
      string.Format(CultureInfo.InvariantCulture, s_rangeMessage, min, max);
  ```

- New <xref:System.IO.Hashing.XxHash3?displayProperty=fullName> and <xref:System.IO.Hashing.XxHash128?displayProperty=fullName> types provide implementations of the fast XXH3 and XXH128 hash algorithms.

### System.Numerics and System.Runtime.Intrinsics

This section covers improvements to the <xref:System.Numerics?displayProperty=fullName> and <xref:System.Runtime.Intrinsics?displayProperty=fullName> namespaces.

- <xref:System.Runtime.Intrinsics.Vector256%601>, <xref:System.Numerics.Matrix3x2>, and <xref:System.Numerics.Matrix4x4> have improved hardware acceleration on .NET 8. For example, <xref:System.Runtime.Intrinsics.Vector256%601> was reimplemented to internally be `2x Vector128<T>` operations, where possible. This allows partial acceleration of some functions when `Vector128.IsHardwareAccelerated == true` but `Vector256.IsHardwareAccelerated == false`, such as on Arm64.
- Hardware intrinsics are now annotated with the `ConstExpected` attribute. This ensures that users are aware when the underlying hardware expects a constant and therefore when a non-constant value may unexpectedly hurt performance.
- The <xref:System.Numerics.IFloatingPointIeee754%601.Lerp(%600,%600,%600)> `Lerp` API has been added to <xref:System.Numerics.IFloatingPointIeee754%601> and therefore to `float` (<xref:System.Single>), `double` (<xref:System.Double>), and <xref:System.Half>. This API allows a linear interpolation between two values to be performed efficiently and correctly.

#### Vector512 and AVX-512

.NET Core 3.0 expanded SIMD support to include the platform-specific hardware intrinsics APIs for x86/x64. .NET 5 added support for Arm64 and .NET 7 added the cross-platform hardware intrinsics. .NET 8 furthers SIMD support by introducing <xref:System.Runtime.Intrinsics.Vector512%601> and support for [Intel Advanced Vector Extensions 512 (AVX-512)](https://www.intel.com/content/www/us/en/developer/articles/technical/intel-avx-512-instructions.html) instructions.

Specifically, .NET 8 includes support for the following key features of AVX-512:

- 512-bit vector operations
- Additional 16 SIMD registers
- Additional instructions available for 128-bit, 256-bit, and 512-bit vectors

If you have hardware that supports the functionality, then <xref:System.Runtime.Intrinsics.Vector512.IsHardwareAccelerated?displayProperty=nameWithType> now reports `true`.

.NET 8 also adds several platform-specific classes under the <xref:System.Runtime.Intrinsics.X86?displayProperty=fullName> namespace:

- <xref:System.Runtime.Intrinsics.X86.Avx512F> (foundational)
- <xref:System.Runtime.Intrinsics.X86.Avx512BW> (byte and word)
- <xref:System.Runtime.Intrinsics.X86.Avx512CD> (conflict detection)
- <xref:System.Runtime.Intrinsics.X86.Avx512DQ> (doubleword and quadword)
- <xref:System.Runtime.Intrinsics.X86.Avx512Vbmi> (vector byte manipulation instructions)

These classes follow the same general shape as other instruction set architectures (ISAs) in that they expose an <xref:System.Runtime.Intrinsics.X86.Avx512F.IsSupported> property and a nested <xref:System.Runtime.Intrinsics.X86.Avx512F.X64> class for instructions available only to 64-bit processes. Additionally, each class has a nested <xref:System.Runtime.Intrinsics.X86.Avx512F.VL> class that exposes the `Avx512VL` (vector length) extensions for the corresponding instruction set.

Even if you don't explicitly use `Vector512`-specific or `Avx512F`-specific instructions in your code, you'll likely still benefit from the new AVX-512 support. The JIT can take advantage of the additional registers and instructions implicitly when using <xref:System.Runtime.Intrinsics.Vector128%601> or <xref:System.Runtime.Intrinsics.Vector256%601>. The base class library uses these hardware intrinsics internally in most operations exposed by <xref:System.Span%601> and <xref:System.ReadOnlySpan%601> and in many of the math APIs exposed for the primitive types.

### Data validation

The <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace includes new data validation attributes intended for validation scenarios in cloud-native services. While the pre-existing `DataAnnotations` validators are geared towards typical UI data-entry validation, such as fields on a form, the new attributes are designed to validate non-user-entry data, such as [configuration options](../../extensions/options.md#options-validation). In addition to the new attributes, new properties were added to the <xref:System.ComponentModel.DataAnnotations.RangeAttribute> type.

| New API | Description |
|--|--|
| <xref:System.ComponentModel.DataAnnotations.RangeAttribute.MinimumIsExclusive?displayProperty=nameWithType><br/><xref:System.ComponentModel.DataAnnotations.RangeAttribute.MaximumIsExclusive?displayProperty=nameWithType> | Specifies whether bounds are included in the allowable range. |
| <xref:System.ComponentModel.DataAnnotations.LengthAttribute?displayProperty=nameWithType> | Specifies both lower and upper bounds for strings or collections. For example, `[Length(10, 20)]` requires at least 10 elements and at most 20 elements in a collection. |
| <xref:System.ComponentModel.DataAnnotations.Base64StringAttribute?displayProperty=nameWithType> | Validates that a string is a valid Base64 representation. |
| <xref:System.ComponentModel.DataAnnotations.AllowedValuesAttribute?displayProperty=nameWithType><br/><xref:System.ComponentModel.DataAnnotations.DeniedValuesAttribute?displayProperty=nameWithType> | Specify allow lists and deny lists, respectively. For example, `[AllowedValues("apple", "banana", "mango")]`. |

### Metrics

New APIs let you attach key-value pair tags to <xref:System.Diagnostics.Metrics.Meter> and <xref:System.Diagnostics.Metrics.Instrument> objects when you create them. Aggregators of published metric measurements can use the tags to differentiate the aggregated values.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/Metrics.cs" id="MetricsTags":::

The new APIs include:

- <xref:System.Diagnostics.Metrics.MeterOptions>
- <xref:System.Diagnostics.Metrics.Meter.%23ctor(System.Diagnostics.Metrics.MeterOptions)>
- <xref:System.Diagnostics.Metrics.Meter.CreateCounter%60%601(System.String,System.String,System.String,System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Object}})>

### Cryptography

.NET 8 adds support for the SHA-3 hashing primitives. (SHA-3 is currently supported by Linux with OpenSSL 1.1.1 or later and Windows 11 Build 25324 or later.) APIs where SHA-2 is available now offer a SHA-3 compliment. This includes `SHA3_256`, `SHA3_384`, and `SHA3_512` for hashing; `HMACSHA3_256`, `HMACSHA3_384`, and `HMACSHA3_512` for HMAC; `HashAlgorithmName.SHA3_256`, `HashAlgorithmName.SHA3_384`, and `HashAlgorithmName.SHA3_512` for hashing where the algorithm is configurable; and `RSAEncryptionPadding.OaepSHA3_256`, `RSAEncryptionPadding.OaepSHA3_384`, and `RSAEncryptionPadding.OaepSHA3_512` for RSA OAEP encryption.

The following example shows how to use the APIs, including the `SHA3_256.IsSupported` property to determine if the platform supports SHA-3.

```csharp
// Hashing example
if (SHA3_256.IsSupported)
{
    byte[] hash = SHA3_256.HashData(dataToHash);
}
else
{
    // ...
}

// Signing example
if (SHA3_256.IsSupported)
{
     using ECDsa ec = ECDsa.Create(ECCurve.NamedCurves.nistP256);
     byte[] signature = ec.SignData(dataToBeSigned, HashAlgorithmName.SHA3_256);
}
else
{
    // ...
}
```

SHA-3 support is currently aimed at supporting cryptographic primitives. Higher-level constructions and protocols aren't expected to fully support SHA-3 initially. These protocols include X.509 certificates, <xref:System.Security.Cryptography.Xml.SignedXml>, and COSE.

### Networking

#### Support for HTTPS proxy

Until now, the proxy types that <xref:System.Net.Http.HttpClient> supported all allowed a "man-in-the-middle" to see which site the client is connecting to, even for HTTPS URIs. <xref:System.Net.Http.HttpClient> now supports *HTTPS proxy*, which creates an encrypted channel between the client and the proxy so all requests can be handled with full privacy.

To enable HTTPS proxy, set the `all_proxy` environment variable, or use the <xref:System.Net.WebProxy> class to control the proxy programmatically.

Unix: `export all_proxy=https://x.x.x.x:3218`
Windows: `set all_proxy=https://x.x.x.x:3218`

You can also use the <xref:System.Net.WebProxy> class to control the proxy programmatically.

### Stream-based ZipFile methods

.NET 8 includes new overloads of <xref:System.IO.Compression.ZipFile.CreateFromDirectory%2A?displayProperty=nameWithType> that allow you to collect all the files included in a directory and zip them, then store the resulting zip file into the provided stream. Similarly, new <xref:System.IO.Compression.ZipFile.ExtractToDirectory%2A?displayProperty=nameWithType> overloads let you provide a stream containing a zipped file and extract its contents into the filesystem. These are the new overloads:

```csharp
namespace System.IO.Compression;

public static partial class ZipFile
{
    public static void CreateFromDirectory(
        string sourceDirectoryName, Stream destination);

    public static void CreateFromDirectory(
        string sourceDirectoryName,
        Stream destination,
        CompressionLevel compressionLevel,
        bool includeBaseDirectory);

    public static void CreateFromDirectory(
        string sourceDirectoryName,
        Stream destination,
        CompressionLevel compressionLevel,
        bool includeBaseDirectory,
    Encoding? entryNameEncoding);

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName) { }

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName, bool overwriteFiles) { }

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName, Encoding? entryNameEncoding) { }

    public static void ExtractToDirectory(
        Stream source, string destinationDirectoryName, Encoding? entryNameEncoding, bool overwriteFiles) { }
}
```

These new APIs can be useful when disk space is constrained, because they avoid having to use the disk as an intermediate step.

## Extension libraries

This section contains the following subtopics:

- [Options validation](#options-validation)
- [LoggerMessageAttribute constructors](#loggermessageattribute-constructors)
- [Extensions metrics](#extensions-metrics)
- [Hosted lifecycle services](#hosted-lifecycle-services)
- [Keyed DI services](#keyed-di-services)
- [System.Numerics.Tensors.TensorPrimitives](#systemnumericstensorstensorprimitives)

### Keyed DI services

Keyed dependency injection (DI) services provide a means for registering and retrieving DI services using keys. By using keys, you can scope how you register and consume services. These are some of the new APIs:

- The <xref:Microsoft.Extensions.DependencyInjection.IKeyedServiceProvider> interface.
- The <xref:Microsoft.Extensions.DependencyInjection.ServiceKeyAttribute> attribute, which can be used to inject the key that was used for registration/resolution in the constructor.
- The <xref:Microsoft.Extensions.DependencyInjection.FromKeyedServicesAttribute> attribute, which can be used on service constructor parameters to specify which keyed service to use.
- Various new extension methods for <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> to support keyed services, for example, <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddKeyedScoped%2A?displayProperty=nameWithType>.
- The <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> implementation of <xref:Microsoft.Extensions.DependencyInjection.IKeyedServiceProvider>.

The following example shows you how to use keyed DI services.

:::code language="csharp" source="../snippets/dotnet-8/csharp/WebSDK/KeyedDIServices.cs":::

For more information, see [dotnet/runtime#64427](https://github.com/dotnet/runtime/issues/64427).

### Hosted lifecycle services

Hosted services now have more options for execution during the application lifecycle. <xref:Microsoft.Extensions.Hosting.IHostedService> provided `StartAsync` and `StopAsync`, and now <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService> provides these additional methods:

- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StartingAsync(System.Threading.CancellationToken)>
- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StartedAsync(System.Threading.CancellationToken)>
- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StoppingAsync(System.Threading.CancellationToken)>
- <xref:Microsoft.Extensions.Hosting.IHostedLifecycleService.StoppedAsync(System.Threading.CancellationToken)>

These methods run before and after the existing points respectively.

The following example shows how to use the new APIs.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/HostedLifecycleServices.cs":::

For more information, see [dotnet/runtime#86511](https://github.com/dotnet/runtime/issues/86511).

### Options validation

#### Source generator

To reduce startup overhead and improve the validation feature set, we've introduced a source-code generator that implements the validation logic. The following code shows example models and validator classes.

:::code language="csharp" source="../snippets/dotnet-8/csharp/WebSDK/Validation.cs" id="ValidatorClasses":::

If your app uses dependency injection, you can inject the validation as shown in the following example code.

:::code language="csharp" source="../snippets/dotnet-8/csharp/WebSDK/Validation.cs" id="InjectValidation":::

#### ValidateOptionsResultBuilder type

.NET 8 introduces the <xref:Microsoft.Extensions.Options.ValidateOptionsResultBuilder> type to facilitate the creation of a <xref:Microsoft.Extensions.Options.ValidateOptionsResult> object. Importantly, this builder allows for the accumulation of multiple errors. Previously, creating the <xref:Microsoft.Extensions.Options.ValidateOptionsResult> object that's required to implement <xref:Microsoft.Extensions.Options.IValidateOptions%601.Validate(System.String,%600)?displayProperty=nameWithType> was difficult and sometimes resulted in layered validation errors. If there were multiple errors, the validation process often stopped at the first error.

The following code snippet shows an example usage of <xref:Microsoft.Extensions.Options.ValidateOptionsResultBuilder>.

:::code language="csharp" source="../snippets/dotnet-8/csharp/WebSDK/ResultBuilder.cs" id="BuildResults":::

### LoggerMessageAttribute constructors

<xref:Microsoft.Extensions.Logging.LoggerMessageAttribute> now offers additional constructor overloads. Previously, you had to choose either the parameterless constructor or the constructor that required all of the parameters (event ID, log level, and message). The new overloads offer greater flexibility in specifying the required parameters with reduced code. If you don't supply an event ID, the system generates one automatically.

```csharp
public LoggerMessageAttribute(LogLevel level, string message);
public LoggerMessageAttribute(LogLevel level);
public LoggerMessageAttribute(string message);
```

### Extensions metrics

#### IMeterFactory interface

You can register the new <xref:System.Diagnostics.Metrics.IMeterFactory> interface in dependency injection (DI) containers and use it to create <xref:System.Diagnostics.Metrics.Meter> objects in an isolated manner.

Register the <xref:System.Diagnostics.Metrics.IMeterFactory> to the DI container using the default meter factory implementation:

```csharp
// 'services' is the DI IServiceCollection.
services.AddMetrics();
```

Consumers can then obtain the meter factory and use it to create a new <xref:System.Diagnostics.Metrics.Meter> object.

```csharp
IMeterFactory meterFactory = serviceProvider.GetRequiredService<IMeterFactory>();

MeterOptions options = new MeterOptions("MeterName")
{
    Version = "version",
};

Meter meter = meterFactory.Create(options);
```

#### MetricCollector\<T> class

The new <xref:Microsoft.Extensions.Diagnostics.Metrics.Testing.MetricCollector%601> class lets you record metric measurements along with timestamps. Additionally, the class offers the flexibility to use a time provider of your choice for accurate timestamp generation.

:::code language="csharp" source="../snippets/dotnet-8/csharp/ConsoleApp/MetricCollector.cs" id="MetricCollector":::

### System.Numerics.Tensors.TensorPrimitives

The updated [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors) NuGet package includes APIs in the new <xref:System.Numerics.Tensors.TensorPrimitives?displayProperty=fullName> type that add support for tensor operations. The tensor primitives optimize data-intensive workloads like those of AI and machine learning.

AI workloads like semantic search and retrieval-augmented generation (RAG) extend the natural language capabilities of large language models, such as ChatGPT, by augmenting prompts with relevant data. For these workloads, operations on vectors&mdash;like *cosine similarity* to find the most relevant data to answer a question&mdash;are crucial. The <xref:System.Numerics.Tensors.TensorPrimitives> type provides APIs for vector operations.

For more information, see the [Announcing .NET 8 RC 2 blog post](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc2/).

## Native AOT support

The option to [publish as Native AOT](../../deploying/native-aot/index.md) was first introduced in .NET 7. Publishing an app with Native AOT creates a fully self-contained version of your app that doesn't need a runtime&mdash;everything is included in a single file. .NET 8 brings the following improvements to Native AOT publishing:

- Adds support for the x64 and Arm64 architectures on *macOS*.
- Reduces the sizes of Native AOT apps on Linux by up to 50%. The following table shows the size of a "Hello World" app published with Native AOT that includes the entire .NET runtime on .NET 7 vs. .NET 8:

  | Operating system                        | .NET 7  | .NET 8  |
  |-----------------------------------------|---------|---------|
  | Linux x64 (with `-p:StripSymbols=true`) | 3.76 MB | 1.84 MB |
  | Windows x64                             | 2.85 MB | 1.77 MB |

- Lets you specify an optimization preference: size or speed. By default, the compiler chooses to generate fast code while being mindful of the size of the application. However, you can use the `<OptimizationPreference>` MSBuild property to optimize specifically for one or the other. For more information, see [Optimize AOT deployments](../../deploying/native-aot/optimizing.md).

### Target iOS-like platforms with Native AOT

.NET 8 starts the work to enable Native AOT support for iOS-like platforms. You can now build and run .NET iOS and .NET MAUI applications with Native AOT on the following platforms:

- `ios`
- `iossimulator`
- `maccatalyst`
- `tvos`
- `tvossimulator`

Preliminary testing shows that app size on disk decreases by about 35% for .NET iOS apps that use Native AOT instead of Mono. App size on disk for .NET MAUI iOS apps decreases up to 50%. Additionally, the startup time is also faster. .NET iOS apps have about 28% faster startup time, while .NET MAUI iOS apps have about 50% better startup performance compared to Mono. The .NET 8 support is experimental and only the first step for the feature as a whole. For more information, see the [.NET 8 Performance Improvements in .NET MAUI blog post](https://devblogs.microsoft.com/dotnet/dotnet-8-performance-improvements-in-dotnet-maui/).

Native AOT support is available as an opt-in feature intended for app deployment; Mono is still the default runtime for app development and deployment. To build and run a .NET MAUI application with Native AOT on an iOS device, use `dotnet workload install maui` to install the .NET MAUI workload and `dotnet new maui -n HelloMaui` to create the app. Then, set the MSBuild property `PublishAot` to `true` in the project file.

```xml
<PropertyGroup>
  <PublishAot>true</PublishAot>
</PropertyGroup>
```

When you set the required property and run `dotnet publish` as shown in the following example, the app will be deployed by using Native AOT.

```dotnetcli
dotnet publish -f net8.0-ios -c Release -r ios-arm64  /t:Run
```

#### Limitations

Not all iOS features are compatible with Native AOT. Similarly, not all libraries commonly used in iOS are compatible with NativeAOT. And in addition to the existing [limitations of Native AOT deployment](../../deploying/native-aot/index.md#limitations-of-native-aot-deployment), the following list shows some of the other limitations when targeting iOS-like platforms:

- Using Native AOT is only enabled during app deployment (`dotnet publish`).
- Managed code debugging is only supported with Mono.
- Compatibility with the .NET MAUI framework is limited.

### AOT compilation for Android apps

To decrease app size, .NET and .NET MAUI apps that target Android use *profiled* ahead-of-time (AOT) compilation mode when they're built in Release mode. Profiled AOT compilation affects fewer methods than regular AOT compilation. .NET 8 introduces the `<AndroidStripILAfterAOT>` property that lets you opt-in to further AOT compilation for Android apps to decrease app size even more.

```xml
<PropertyGroup>
  <AndroidStripILAfterAOT>true</AndroidStripILAfterAOT>
</PropertyGroup>
```

By default, setting `AndroidStripILAfterAOT` to `true` overrides the default `AndroidEnableProfiledAot` setting, allowing (nearly) all methods that were AOT-compiled to be trimmed. You can also use profiled AOT and IL stripping together by explicitly setting both properties to `true`:

```xml
<PropertyGroup>
  <AndroidStripILAfterAOT>true</AndroidStripILAfterAOT>
  <AndroidEnableProfiledAot>true</AndroidEnableProfiledAot>
</PropertyGroup>
```

## Cross-built Windows apps

When you build apps that target Windows on non-Windows platforms, the resulting executable is now updated with any specified Win32 resources&mdash;for example, application icon, manifest, version information.

Previously, applications had to be built on Windows in order to have such resources. Fixing this gap in cross-building support has been a popular request, as it was a significant pain point affecting both infrastructure complexity and resource usage.

## See also

- [What's new in .NET 8](overview.md)
