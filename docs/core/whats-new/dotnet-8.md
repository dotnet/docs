---
title: What's new in .NET 8
description: Learn about the new .NET features introduced in .NET 8.
titleSuffix: ""
ms.date: 03/14/2023
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 8

.NET 8 is the successor to [.NET 7](dotnet-7.md). It will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release.

This article has been updated for .NET 8 Preview 2.

> [!IMPORTANT]
>
> - This information relates to a pre-release product that may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.
> - Most of the other .NET documentation on <https://learn.microsoft.com> has not yet been updated for .NET 8.

## 'dotnet publish' and 'dotnet pack'

Since the [`dotnet publish`](../tools/dotnet-publish.md) and [`dotnet pack`](../tools/dotnet-pack.md) commands are intended to produce production assets, they now produce `Release` assets by default.

The following output shows the different behavior between `dotnet build` and `dotnet publish`, and how you can revert to publishing `Debug` assets by setting the `PublishRelease` property to `false`.

```console
/app# dotnet new console
/app# dotnet build
  app -> /app/bin/Debug/net8.0/app.dll
/app# dotnet publish
  app -> /app/bin/Release/net8.0/app.dll
  app -> /app/bin/Release/net8.0/publish/
/app# dotnet publish -p:PublishRelease=false
  app -> /app/bin/Debug/net8.0/app.dll
  app -> /app/bin/Debug/net8.0/publish/
```

For more information, see ['dotnet pack' uses Release config](../compatibility/sdk/8.0/dotnet-pack-config.md) and ['dotnet publish' uses Release config](../compatibility/sdk/8.0/dotnet-publish-config.md).

## System.Text.Json serialization

Various improvements have been made to <xref:System.Text.Json?displayProperty=fullName> serialization and deserialization functionality.

- Performance and reliability enhancements of the [source generator](../../standard/serialization/system-text-json/source-generation.md) when used with ASP.NET Core in Native AOT apps.
- The [source generator](../../standard/serialization/system-text-json/source-generation.md) now supports serializing types with [`required`](../../standard/serialization/system-text-json/required-properties.md) and [`init`](../../csharp/language-reference/keywords/init.md) properties. These were both already supported in reflection-based serialization.
- [Customize handling of members that aren't in the JSON payload.](../../standard/serialization/system-text-json/missing-members.md)
- Support for serializing properties from interface hierarchies. The following code shows an example where the properties from both the immediately implemented interface and its base interface are serialized.
  
  ```csharp
  IDerived value = new DerivedImplement { Base = 0, Derived =1 };
  JsonSerializer.Serialize(value); // {"Base":0,"Derived":1}

  public interface IBase
  {
      public int Base { get; set; }
  }

  public interface IDerived : IBase
  {
      public int Derived { get; set; }
  }

  public class DerivedImplement : IDerived
  {
      public int Base { get; set; }
      public int Derived { get; set; }
  }
  ```

- [`JsonNamingPolicy`](/dotnet/api/system.text.json.jsonnamingpolicy?view=net-8.0&preserve-view=true#properties) includes new naming policies for `snake_case` (with an underscore) and `kebab-case` (with a hyphen) property name conversions. Use these policies similarly to the existing <xref:System.Text.Json.JsonNamingPolicy.CamelCase?displayProperty=nameWithType> policy:

  ```csharp
  var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
  JsonSerializer.Serialize(new { PropertyName = "value" }, options); // { "property_name" : "value" }
  ```

- <xref:System.Text.Json.JsonSerializerOptions.MakeReadOnly?displayProperty=nameWithType> gives you explicit control over when a `JsonSerializerOptions` instance is frozen. (You can also check it with the <xref:System.Text.Json.JsonSerializerOptions.IsReadOnly> property.)

For more information about JSON serialization in general, see [JSON serialization and deserialization in .NET](../../standard/serialization/system-text-json/overview.md).

## Methods for working with randomness

The <xref:System.Random?displayProperty=fullName> and <xref:System.Security.Cryptography.RandomNumberGenerator?displayProperty=fullName> types introduce two new methods for working with randomness.

### GetItems\<T>()

The new <xref:System.Random.GetItems%2A?displayProperty=fullName> and <xref:System.Security.Cryptography.RandomNumberGenerator.GetItems%2A?displayProperty=fullName> methods let you randomly choose a specified number of items from an input set. The following example shows how to use `System.Random.GetItems<T>()` (on the instance provided by the <xref:System.Random.Shared?displayProperty=nameWithType> property) to randomly insert 31 items into an array. This example could be used in a game of "Simon" where players must remember a sequence of colored buttons.

```csharp
private static ReadOnlySpan<Button> s_allButtons = new[]
{
    Button.Red,
    Button.Green,
    Button.Blue,
    Button.Yellow,
};

...

Button[] thisRound = Random.Shared.GetItems(s_allButtons, 31);
// Rest of game goes here ...
```

### Shuffle\<T>()

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

## Performance-focused types

.NET 8 introduces several new types aimed at improving app performance.

- The new <xref:System.Collections.Frozen?displayProperty=fullName> namespace includes the collection types <xref:System.Collections.Frozen.FrozenDictionary%602> and <xref:System.Collections.Frozen.FrozenSet%601>. These types don't allow any changes to keys and values once a collection created. That requirement allows faster read operations (for example, `TryGetValue()`). These types are particularly useful for collections that are populated on first use and then persisted for the duration of a long-lived service, for example:

  ```csharp
  private static readonly FrozenDictionary<string, bool> s_configurationData =
      LoadConfigurationData().ToFrozenDictionary(optimizeForReads: true);
  // ...
  if (s_configurationData.TryGetValue(key, out bool setting) && setting)
  {
      Process();
  }
  ```

- The new <xref:System.Buffers.IndexOfAnyValues%601?displayProperty=fullName> type is designed to be passed to methods that look for the first occurrence of any value in the passed collection. For example, <xref:System.String.IndexOfAny(System.Char[])?displayProperty=nameWithType> looks for the first occurrence of any character in the specified array in the `string` it's called on. NET 8 adds new overloads of methods like <xref:System.String.IndexOfAny%2A?displayProperty=nameWithType> and <xref:System.MemoryExtensions.IndexOfAny%2A?displayProperty=nameWithType> that accept an instance of the new type. When you create an instance of <xref:System.Buffers.IndexOfAnyValues%601?displayProperty=fullName>, all the data that's necessary to optimize subsequent searches is derived *at that time*, meaning the work is done up front.
- The new <xref:System.Text.CompositeFormat?displayProperty=fullName> type is useful for optimizing format strings that aren't known at compile time (for example, if the format string is loaded from a resource file). A little extra time is spent up front to do work such as parsing the string, but it saves the work from being done on each use.

  ```csharp
  private static readonly CompositeFormat s_rangeMessage = CompositeFormat.Parse(LoadRangeMessageResource());
  // ...
  static string GetMessage(int min, int max) =>
      string.Format(CultureInfo.InvariantCulture, s_rangeMessage, min, max);
  ```

- New <xref:System.IO.Hashing.XxHash3?displayProperty=fullName> and <xref:System.IO.Hashing.XxHash128?displayProperty=fullName> types provide implementations of the fast XXH3 and XXH128 hash algorithms.

## System.Numerics and System.Runtime.Intrinsics

This section covers improvements to the <xref:System.Numerics?displayProperty=fullName> and <xref:System.Runtime.Intrinsics?displayProperty=fullName> namespaces.

- <xref:System.Runtime.Intrinsics.Vector256%601>, <xref:System.Numerics.Matrix3x2>, and <xref:System.Numerics.Matrix4x4> have improved hardware acceleration on .NET 8. For example, <xref:System.Runtime.Intrinsics.Vector256%601> was reimplemented to internally be `2x Vector128<T>` operations, where possible. This allows partial acceleration of some functions when `Vector128.IsHardwareAccelerated == true` but `Vector256.IsHardwareAccelerated == false`, such as on Arm64.
- .NET 8 includes the initial implementation of <xref:System.Runtime.Intrinsics.Vector512%601>.
- Hardware intrinsics are now annotated with the `ConstExpected` attribute. This ensures that users are aware when the underlying hardware expects a constant and therefore when a non-constant value may unexpectedly hurt performance.
- The <xref:System.Numerics.IFloatingPointIeee754%601.Lerp(%600,%600,%600)> `Lerp` API has been added to <xref:System.Numerics.IFloatingPointIeee754%601> and therefore to `float` (<xref:System.Single>), `double` (<xref:System.Double>), and <xref:System.Half>. This API allows a linear interpolation between two values to be performed efficiently and correctly.

## Data validation attributes

The <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace includes new data validation attributes intended for validation scenarios in cloud-native services. While the pre-existing `DataAnnotations` validators are geared towards typical UI data-entry validation, such as fields on a form, the new attributes are designed to validate non-user-entry data, such as [configuration options](../extensions/options.md#options-validation). In addition to the new attributes, new properties were added to the <xref:System.ComponentModel.DataAnnotations.RangeAttribute> and <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> types.

| New API | Description|
| - | - |
| <xref:System.ComponentModel.DataAnnotations.RequiredAttribute.DisallowAllDefaultValues?displayProperty=nameWithType> | Validates that structs don't equal their default values. |
| <xref:System.ComponentModel.DataAnnotations.RangeAttribute.MinimumIsExclusive?displayProperty=nameWithType> and <xref:System.ComponentModel.DataAnnotations.RangeAttribute.MaximumIsExclusive?displayProperty=nameWithType> | Specifies whether bounds are included in the allowable range. |
| <xref:System.ComponentModel.DataAnnotations.LengthAttribute?displayProperty=nameWithType> | Specifies both lower and upper bounds for strings or collections. For example, `[Length(10, 20)]` requires at least 10 elements and at most 20 elements in a collection. |
| <xref:System.ComponentModel.DataAnnotations.Base64StringAttribute?displayProperty=nameWithType> | Validates that a string is a valid Base64 representation. |
| <xref:System.ComponentModel.DataAnnotations.AllowedValuesAttribute?displayProperty=nameWithType> and <xref:System.ComponentModel.DataAnnotations.DeniedValuesAttribute?displayProperty=nameWithType> | Specify allow lists and deny lists, respectively. For example, `[AllowedValues("apple", "banana", "mango")]`. |

## Introspection support for function pointers

[Function pointers](../../csharp/language-reference/unsafe-code.md#function-pointers) were introduced in .NET 5, however, the corresponding support for reflection wasn't added at that time. When using `typeof` or reflection on a function pointer, for example, `typeof(delegate*<void>())` or `FieldInfo.FieldType` respectively, an <xref:System.IntPtr> was returned. Starting in .NET 8, a <xref:System.Type?displayProperty=nameWithType> object is returned instead. This type provides access to function pointer metadata, including the calling conventions, return type, and parameters.

> [!NOTE]
> A function pointer instance, which is a physical address to a function, continues to be represented as an <xref:System.IntPtr>. Only the reflection type has changed.

The new functionality is currently implemented only in the CoreCLR runtime and <xref:System.Reflection.MetadataLoadContext>.

New APIs have been added to <xref:System.Type?displayProperty=fullName>, such as <xref:System.Type.IsFunctionPointer>, and to the <xref:System.Reflection.PropertyInfo?displayProperty=fullName>, <xref:System.Reflection.FieldInfo?displayProperty=fullName>, and <xref:System.Reflection.ParameterInfo?displayProperty=fullName>. The following code shows how to use some of the new APIs for reflection.

```csharp
// Sample class that contains a function pointer field:
public unsafe class MyClass
{
    public delegate* unmanaged[Cdecl, SuppressGCTransition]<in int, void> _fp;
}

FieldInfo fieldInfo = typeof(MyClass).GetField(nameof(MyClass._fp));

// Obtain the function pointer type from a field. This used to be the 'IntPtr' type, now it's 'Type':
Type fpType = fieldInfo.FieldType;

// New methods to determine if a type is a function pointer:
Console.WriteLine(fpType.IsFunctionPointer); // True
Console.WriteLine(fpType.IsUnmanagedFunctionPointer); // True

// New methods to obtain the return and parameter types:
Console.WriteLine($"Return type: {fpType.GetFunctionPointerReturnType()}"); // System.Void

foreach (Type parameterType in fpType.GetFunctionPointerParameterTypes())
{
    Console.WriteLine($"Parameter type: {parameterType}"); // System.Int32&
}

// Access to custom modifiers and calling conventions requires a "modified type":
Type modifiedType = fieldInfo.GetModifiedFieldType();

// A modified type forwards most members to its underlying type which can be obtained with Type.UnderlyingSystemType:
Type normalType = modifiedType.UnderlyingSystemType;

// New methods to obtain the calling conventions:
foreach (Type callConv in modifiedType.GetFunctionPointerCallingConventions())
{
    Console.WriteLine($"Calling convention: {callConv}");
    // System.Runtime.CompilerServices.CallConvSuppressGCTransition
    // System.Runtime.CompilerServices.CallConvCdecl
}

// New methods to obtain the custom modifiers:
foreach (Type modreq in modifiedType.GetFunctionPointerParameterTypes()[0].GetRequiredCustomModifiers())
{
    Console.WriteLine($"Required modifier for first parameter: {modreq }");
    // System.Runtime.InteropServices.InAttribute
}
```

## Native AOT

The option to [publish as native AOT](../deploying/native-aot/index.md) was first introduced in .NET 7. Publishing an app with native AOT creates a fully self-contained version of your app that doesn't need a runtime&mdash;everything is included in a single file.

.NET 8 adds support for the x64 and Arm64 architectures on *macOS*.

Also, the sizes of native AOT apps on Linux are now up to 50% smaller. The following table shows the size of a "Hello World" app published with native AOT that includes the entire .NET runtime on .NET 7 vs. .NET 8:

| Operating system                      | .NET 7  | .NET 8 Preview 1 |
| ------------------------------------- | ------- | ---------------- |
| Linux x64 (with -p:StripSymbols=true) | 3.76 MB | 1.84 MB          |
| Windows x64                           | 2.85 MB | 1.77 MB          |

## Code generation

.NET 8 includes improvements to code generation and just-in time (JIT) compilation:

- Arm64 performance improvements
- SIMD improvements
- Cloud-native improvements
- Profile-guided optimization (PGO) improvements
- Support for AVX-512 ISA extensions
- JIT throughput improvements
- Loop and general optimizations

## .NET container images

The following changes have been made to .NET container images for .NET 8:

- The container images now use [Debian 12 (Bookworm)](https://wiki.debian.org/DebianBookworm). Debian is the default Linux distro in the .NET container images.
- Images include a `non-root` user. This user makes the images `non-root` capable. To run as `non-root`, add the following line at the end of your Dockerfile (or a similar instruction in your Kubernetes manifests):

  ```dockerfile
  USER app
  ```

  The default port also changed from port `80` to `8080`. To support this change, a new environment variable `ASPNETCORE_HTTP_PORTS` is available to make it easier to change ports. The variable accepts a list of ports, which is simpler than the format required by `ASPNETCORE_URLS`. If you change the port back to port `80` using one of these variables, you can't run as `non-root`.
- Preview container images tags now have a `-preview` suffix instead of just using the version number. For example, to pull the .NET 8 Preview SDK, use the following tag:

    `docker run --rm -it mcr.microsoft.com/dotnet/sdk:8.0-preview`

  The `-preview` suffix will be removed for release candidate (RC) releases.

- [Chiseled Ubuntu images](https://hub.docker.com/r/ubuntu/dotnet-deps) are available for .NET 8. Chiseled images have a reduced attacked surface because they're ultra-small, have no package manager or shell, and are `non-root`. This type of image is for developers that want the benefit of appliance-style computing. Chiseled images are published to the [.NET nightly artifact registry](https://mcr.microsoft.com/product/dotnet/nightly/aspnet/tags).

## Build your own .NET on Linux

In previous .NET versions, you could build .NET from source, but it required you to create a "source tarball" from the [dotnet/installer](https://github.com/dotnet/installer) repo commit that corresponded to a release. In .NET 8, that's no longer necessary and you can build .NET on Linux directly from the [dotnet/dotnet](https://github.com/dotnet/dotnet) repository. That repo uses [dotnet/source-build](https://github.com/dotnet/source-build) to build .NET runtimes, tools, and SDKs. This is the same build that Red Hat and Canonical use to build .NET.

Building in a container is the easiest approach for most people, since the `dotnet-buildtools/prereqs` container images contain all the required dependencies. For more information, see the [build instructions](https://github.com/dotnet/dotnet#building).

## Minimum support baselines for Linux

The minimum support baselines for Linux have been updated for .NET 8:

- .NET will be built targeting Ubuntu 16.04, for all architectures. That's primarily important for defining the minimum `glibc` version for .NET 8. For example, .NET 8 will fail to even start on Ubuntu 14.04.
- For Red Hat Enterprise Linux (RHEL), .NET supports RHEL 8+ and drops RHEL 7.

For more information, see [Red Hat Enterprise Linux Family support](https://github.com/dotnet/core/blob/main/linux-support.md#red-hat-enterprise-linux-family-support).

## See also

- [Breaking changes in .NET 8](../compatibility/8.0.md)
- [.NET blog: Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)
- [.NET blog: ASP.NET Core updates in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
