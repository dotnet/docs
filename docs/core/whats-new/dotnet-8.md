---
title: What's new in .NET 8
description: Learn about the new .NET features introduced in .NET 8.
titleSuffix: ""
ms.date: 04/06/2023
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 8

.NET 8 is the successor to [.NET 7](dotnet-7.md). It will be [supported for three years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release. You can [download .NET 8 here](https://dotnet.microsoft.com/download/dotnet).

This article has been updated for .NET 8 Preview 3.

> [!IMPORTANT]
>
> - This information relates to a pre-release product that may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.
> - Much of the other .NET documentation on <https://learn.microsoft.com> has not yet been updated for .NET 8.

## .NET SDK changes

This section contains the following subtopics:

- [Simplified output paths](#simplified-output-paths)
- ['dotnet workload clean' command](#dotnet-workload-clean-command)
- ['dotnet publish' and 'dotnet pack' assets](#dotnet-publish-and-dotnet-pack-assets)

### Simplified output paths

.NET 8 Preview 3 introduces an option to simplify the output path and folder structure for build outputs. Previously, .NET apps produced a deep and complex set of output paths for different build artifacts. The new, simplified output path structure gathers all build outputs into a common location, which makes it easier for tooling to anticipate.

To opt into the new output path format, set the `UseArtifactsOutput` property to `true` in your *Directory.Build.props* file.

By default, the common location is a folder named *.artifacts* in the root of your repository rather than in each project folder. The folder structure under the root artifacts folder is as follows:

```txt
.artifacts
   |_<Type of output>
      |_<Project name>
         |_<Pivot>
```

The following table shows the default values for each level in the folder structure. The values, as well as the default location, can be overridden using properties in the *Directory.build.props* file.

| Folder level | Description |
|---------|---------|
| Type of output | Examples: `bin`, `obj`, `publish`, or `package` |
| Project name | Separates output by each project. This level is omitted if no *Directory.build.props* file is found. |
| Pivot | Distinguishes between builds of a project for different configurations, target frameworks, and runtime identifiers. If multiple elements are needed, they're joined by an underscore (`_`). |

For more information, see the [Simplified output paths](https://github.com/dotnet/designs/blob/simplify-output-paths-2/accepted/2023/simplify-output-paths.md) design proposal.

### 'dotnet workload clean' command

.NET 8 Preview 3 introduces a new command to clean up workload packs that might be left over over the course of several .NET SDK or Visual Studio updates. If you encounter issues when managing workloads, consider using `workload clean` to safely restore to a known state before trying again. The command has two modes:

- `dotnet workload clean`

  Runs [workload garbage collection](https://github.com/dotnet/designs/blob/main/accepted/2021/workloads/workload-installation.md#workload-pack-installation-records-and-garbage-collection) for file-based or MSI-based workloads, which cleans up orphaned packs. Orphaned packs are from uninstalled versions of the .NET SDK or packs where installation records for the pack no longer exist.

  If Visual Studio is installed, the command also lists any workloads that you should clean up manually using Visual Studio.

- `dotnet workload clean --all`

  This mode is more aggressive and cleans every pack on the machine that's of the current SDK workload installation type (and that's not from Visual Studio). It also removes all workload installation records for the running .NET SDK feature band and below.

### 'dotnet publish' and 'dotnet pack' assets

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

## Serialization

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

## Core .NET libraries

This section contains the following subtopics:

- [Methods for working with randomness](#methods-for-working-with-randomness)
- [Performance-focused types](#performance-focused-types)
- [System.Numerics and System.Runtime.Intrinsics](#systemnumerics-and-systemruntimeintrinsics)
- [Data validation](#data-validation)

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

...

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

### System.Numerics and System.Runtime.Intrinsics

This section covers improvements to the <xref:System.Numerics?displayProperty=fullName> and <xref:System.Runtime.Intrinsics?displayProperty=fullName> namespaces.

- <xref:System.Runtime.Intrinsics.Vector256%601>, <xref:System.Numerics.Matrix3x2>, and <xref:System.Numerics.Matrix4x4> have improved hardware acceleration on .NET 8. For example, <xref:System.Runtime.Intrinsics.Vector256%601> was reimplemented to internally be `2x Vector128<T>` operations, where possible. This allows partial acceleration of some functions when `Vector128.IsHardwareAccelerated == true` but `Vector256.IsHardwareAccelerated == false`, such as on Arm64.
- .NET 8 includes the initial implementation of <xref:System.Runtime.Intrinsics.Vector512%601>.
- Hardware intrinsics are now annotated with the `ConstExpected` attribute. This ensures that users are aware when the underlying hardware expects a constant and therefore when a non-constant value may unexpectedly hurt performance.
- The <xref:System.Numerics.IFloatingPointIeee754%601.Lerp(%600,%600,%600)> `Lerp` API has been added to <xref:System.Numerics.IFloatingPointIeee754%601> and therefore to `float` (<xref:System.Single>), `double` (<xref:System.Double>), and <xref:System.Half>. This API allows a linear interpolation between two values to be performed efficiently and correctly.

### Data validation

The <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> namespace includes new data validation attributes intended for validation scenarios in cloud-native services. While the pre-existing `DataAnnotations` validators are geared towards typical UI data-entry validation, such as fields on a form, the new attributes are designed to validate non-user-entry data, such as [configuration options](../extensions/options.md#options-validation). In addition to the new attributes, new properties were added to the <xref:System.ComponentModel.DataAnnotations.RangeAttribute> and <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> types.

| New API | Description|
| - | - |
| <xref:System.ComponentModel.DataAnnotations.RequiredAttribute.DisallowAllDefaultValues?displayProperty=nameWithType> | Validates that structs don't equal their default values. |
| <xref:System.ComponentModel.DataAnnotations.RangeAttribute.MinimumIsExclusive?displayProperty=nameWithType><br/><xref:System.ComponentModel.DataAnnotations.RangeAttribute.MaximumIsExclusive?displayProperty=nameWithType> | Specifies whether bounds are included in the allowable range. |
| <xref:System.ComponentModel.DataAnnotations.LengthAttribute?displayProperty=nameWithType> | Specifies both lower and upper bounds for strings or collections. For example, `[Length(10, 20)]` requires at least 10 elements and at most 20 elements in a collection. |
| <xref:System.ComponentModel.DataAnnotations.Base64StringAttribute?displayProperty=nameWithType> | Validates that a string is a valid Base64 representation. |
| <xref:System.ComponentModel.DataAnnotations.AllowedValuesAttribute?displayProperty=nameWithType><br/><xref:System.ComponentModel.DataAnnotations.DeniedValuesAttribute?displayProperty=nameWithType> | Specify allow lists and deny lists, respectively. For example, `[AllowedValues("apple", "banana", "mango")]`. |

## Extension libraries

### ValidateOptionsResultBuilder type

.NET 8 Preview 3 introduces the <xref:Microsoft.Extensions.Options.ValidateOptionsResultBuilder> type to facilitate the creation of a <xref:Microsoft.Extensions.Options.ValidateOptionsResult> object. Importantly, this builder allows for the accumulation of multiple errors. Previously, creating the <xref:Microsoft.Extensions.Options.ValidateOptionsResult> object that's required to implement <xref:Microsoft.Extensions.Options.IValidateOptions%601.Validate(System.String,%600)?displayProperty=nameWithType> was difficult and sometimes resulted in layered validation errors. If there were multiple errors, the validation process often stopped at the first error.

The following code snippet shows an example usage of <xref:Microsoft.Extensions.Options.ValidateOptionsResultBuilder>:

```csharp
ValidateOptionsResultBuilder builder = new();
builder.AddError("Error: invalid operation code");
builder.AddResult(ValidateOptionsResult.Fail("Invalid request parameters"));
builder.AddError("Malformed link", "Url");

// Build ValidateOptionsResult object has accumulating multiple errors.
ValidateOptionsResult result = builder.Build();

// Reset the builder to allow using it in new validation operation.
builder.Clear();
```

## Source generator for configuration binding

[ASP.NET Core uses configuration providers](/aspnet/core/fundamentals/configuration/) to perform app configuration. The providers read key-value pair data from different sources, such as settings files, environment variables, and Azure Key Vault. <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> is the type that maps configuration values to strongly typed objects. Previously, the mapping was performed using reflection, which can cause issues for trimming and Native AOT. Starting in .NET 8, you can opt into the use of a source generator to generate the binding implementations. The generator probes for <xref:Microsoft.Extensions.Options.ConfigureOptions%601.Configure(%600)>, <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A>, and <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%2A> calls that to retrieve type info from. When the generator is enabled in a project, the compiler implicitly chooses generated methods over the pre-existing reflection-based framework implementations.

To opt into the source generator, set the `EnableMicrosoftExtensionsConfigurationBinderSourceGenerator` to `true` in your project file:

```xml
<PropertyGroup>
    <EnableMicrosoftExtensionsConfigurationBinderSourceGenerator>true</EnableMicrosoftExtensionsConfigurationBinderSourceGenerator>
</PropertyGroup>
```

For Preview 3, you'll also need to download the latest preview version of the [Microsoft.Extensions.Configuration.Binder NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder).

The following code shows an example of invoking the binder.

```csharp
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfigurationSection section = builder.Configuration.GetSection("MyOptions");

// !! Configure call - to be replaced with source-gen'd implementation
builder.Services.Configure<MyOptions>(section);

// !! Get call - to be replaced with source-gen'd implementation
MyOptions options0 = section.Get<MyOptions>();

// !! Bind call - to be replaced with source-gen'd implementation
MyOptions options1 = new MyOptions();
section.Bind(myOptions1);

WebApplication app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();

public class MyOptions
{
    public int A { get; set; }
    public string S { get; set; }
    public byte[] Data { get; set; }
    public Dictionary<string, string> Values { get; set; }
    public List<MyClass> Values2 { get; set; }
}

public class MyClass
{
    public int SomethingElse { get; set; }
}
```

## Reflection improvements

[Function pointers](../../csharp/language-reference/unsafe-code.md#function-pointers) were introduced in .NET 5, however, the corresponding support for reflection wasn't added at that time. When using `typeof` or reflection on a function pointer, for example, `typeof(delegate*<void>())` or `FieldInfo.FieldType` respectively, an <xref:System.IntPtr> was returned. Starting in .NET 8, a <xref:System.Type?displayProperty=nameWithType> object is returned instead. This type provides access to function pointer metadata, including the calling conventions, return type, and parameters.

> [!NOTE]
> A function pointer instance, which is a physical address to a function, continues to be represented as an <xref:System.IntPtr>. Only the reflection type has changed.

The new functionality is currently implemented only in the CoreCLR runtime and <xref:System.Reflection.MetadataLoadContext>.

New APIs have been added to <xref:System.Type?displayProperty=fullName>, such as <xref:System.Type.IsFunctionPointer>, and to <xref:System.Reflection.PropertyInfo?displayProperty=fullName>, <xref:System.Reflection.FieldInfo?displayProperty=fullName>, and <xref:System.Reflection.ParameterInfo?displayProperty=fullName>. The following code shows how to use some of the new APIs for reflection.

```csharp
// Sample class that contains a function pointer field.
public unsafe class UClass
{
    public delegate* unmanaged[Cdecl, SuppressGCTransition]<in int, void> _fp;
}

// ...

FieldInfo fieldInfo = typeof(UClass).GetField(nameof(UClass._fp));

// Obtain the function pointer type from a field.
Type fpType = fieldInfo.FieldType;

// New methods to determine if a type is a function pointer.
Console.WriteLine($"IsFunctionPointer: {fpType.IsFunctionPointer}");
Console.WriteLine($"IsUnmanagedFunctionPointer: {fpType.IsUnmanagedFunctionPointer}");

// New methods to obtain the return and parameter types.
Console.WriteLine($"Return type: {fpType.GetFunctionPointerReturnType()}");

foreach (Type parameterType in fpType.GetFunctionPointerParameterTypes())
{
    Console.WriteLine($"Parameter type: {parameterType}");
}

// Access to custom modifiers and calling conventions requires a "modified type".
Type modifiedType = fieldInfo.GetModifiedFieldType();

// A modified type forwards most members to its underlying type.
Type normalType = modifiedType.UnderlyingSystemType;

// New method to obtain the calling conventions.
foreach (Type callConv in modifiedType.GetFunctionPointerCallingConventions())
{
    Console.WriteLine($"Calling convention: {callConv}");
}

// New method to obtain the custom modifiers.
foreach (Type modreq in modifiedType.GetFunctionPointerParameterTypes()[0].GetRequiredCustomModifiers())
{
    Console.WriteLine($"Required modifier for first parameter: {modreq}");
}
```

The previous example produces the following output:

```txt
IsFunctionPointer: True
IsUnmanagedFunctionPointer: True
Return type: System.Void
Parameter type: System.Int32&
Calling convention: System.Runtime.CompilerServices.CallConvSuppressGCTransition
Calling convention: System.Runtime.CompilerServices.CallConvCdecl
Required modifier for first parameter: System.Runtime.InteropServices.InAttribute
```

## Native AOT support

The option to [publish as native AOT](../deploying/native-aot/index.md) was first introduced in .NET 7. Publishing an app with native AOT creates a fully self-contained version of your app that doesn't need a runtime&mdash;everything is included in a single file.

.NET 8 adds support for the x64 and Arm64 architectures on *macOS*.

Also, the sizes of native AOT apps on Linux are now up to 50% smaller. The following table shows the size of a "Hello World" app published with native AOT that includes the entire .NET runtime on .NET 7 vs. .NET 8:

| Operating system                        | .NET 7  | .NET 8 Preview 1 |
| --------------------------------------- | ------- | ---------------- |
| Linux x64 (with `-p:StripSymbols=true`) | 3.76 MB | 1.84 MB          |
| Windows x64                             | 2.85 MB | 1.77 MB          |

## Performance improvements

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

- [Debian 12](#debian-12)
- [Non-root user](#non-root-user)
- [Preview images](#preview-images)
- [Chiseled Ubuntu images](#chiseled-ubuntu-images)
- [Build multi-platform container images](#build-multi-platform-container-images)

### Debian 12

The container images now use [Debian 12 (Bookworm)](https://wiki.debian.org/DebianBookworm). Debian is the default Linux distro in the .NET container images.

### Non-root user

Images include a `non-root` user. This user makes the images `non-root` capable. To run as `non-root`, add the following line at the end of your Dockerfile (or a similar instruction in your Kubernetes manifests):

```dockerfile
USER app
```

.NET 8 Preview 3 adds an environment variable for the UID for the `non-root` user, which is 64198. This environment variable is useful for the Kubernetes `runAsNonRoot` test, which requires that the container user be set via UID and not by name. This [dockerfile](https://github.com/dotnet/dotnet-docker/blob/e5bc76bca49a1bbf9c11e74a590cf6a9fe9dbf2a/samples/aspnetapp/Dockerfile.alpine-non-root#L27) shows an example usage.

The default port also changed from port `80` to `8080`. To support this change, a new environment variable `ASPNETCORE_HTTP_PORTS` is available to make it easier to change ports. The variable accepts a list of ports, which is simpler than the format required by `ASPNETCORE_URLS`. If you change the port back to port `80` using one of these variables, you can't run as `non-root`.

### Preview images

Preview container images tags now have a `-preview` suffix instead of just using the version number. For example, to pull the .NET 8 Preview SDK, use the following tag:

`docker run --rm -it mcr.microsoft.com/dotnet/sdk:8.0-preview`

The `-preview` suffix will be removed for release candidate (RC) releases.

### Chiseled Ubuntu images

[Chiseled Ubuntu images](https://hub.docker.com/r/ubuntu/dotnet-deps) are available for .NET 8. Chiseled images have a reduced attacked surface because they're ultra-small, have no package manager or shell, and are `non-root`. This type of image is for developers that want the benefit of appliance-style computing. Chiseled images are published to the [.NET nightly artifact registry](https://mcr.microsoft.com/product/dotnet/nightly/aspnet/tags).

### Build multi-platform container images

Docker supports using and building [multi-platform images](https://docs.docker.com/build/building/multi-platform/) that work across multiple environments. .NET 8 introduces a new pattern that enables you to mix and match architectures with the .NET images you build. As an example, if you're using macOS and want to target an x64 cloud service in Azure, you can build the image by using the `--platform` switch as follows:

`docker build --pull -t app --platform linux/amd64`

The .NET SDK now supports `$TARGETARCH` values and the `-a` argument on restore. The following code snippet shows an example:

```dockerfile
RUN dotnet restore -a $TARGETARCH

# Copy everything else and build app.
COPY aspnetapp/. .
RUN dotnet publish -a $TARGETARCH --self-contained false --no-restore -o /app
```

For more information, see the [Improving multi-platform container support](https://devblogs.microsoft.com/dotnet/improving-multiplatform-container-support/) blog post.

## .NET on Linux

### Minimum support baselines for Linux

The minimum support baselines for Linux have been updated for .NET 8:

- .NET will be built targeting Ubuntu 16.04, for all architectures. That's primarily important for defining the minimum `glibc` version for .NET 8. For example, .NET 8 will fail to even start on Ubuntu 14.04.
- For Red Hat Enterprise Linux (RHEL), .NET supports RHEL 8+ and drops RHEL 7.

For more information, see [Red Hat Enterprise Linux Family support](https://github.com/dotnet/core/blob/main/linux-support.md#red-hat-enterprise-linux-family-support).

### Build your own .NET on Linux

In previous .NET versions, you could build .NET from source, but it required you to create a "source tarball" from the [dotnet/installer](https://github.com/dotnet/installer) repo commit that corresponded to a release. In .NET 8, that's no longer necessary and you can build .NET on Linux directly from the [dotnet/dotnet](https://github.com/dotnet/dotnet) repository. That repo uses [dotnet/source-build](https://github.com/dotnet/source-build) to build .NET runtimes, tools, and SDKs. This is the same build that Red Hat and Canonical use to build .NET.

Building in a container is the easiest approach for most people, since the `dotnet-buildtools/prereqs` container images contain all the required dependencies. For more information, see the [build instructions](https://github.com/dotnet/dotnet#building).

## See also

- [Breaking changes in .NET 8](../compatibility/8.0.md)
- [.NET blog: Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)
- [.NET blog: Announcing .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-2/)
- [.NET blog: Announcing .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-3/)
- [.NET blog: ASP.NET Core updates in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-1/)
- [.NET blog: ASP.NET Core updates in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-2/)
