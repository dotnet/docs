---
title: What's new in .NET 8
description: Learn about the new features introduced in .NET 8.
ms.date: 02/21/2023
ms.topic: overview
ms.author: gewarren
author: gewarren
---
# What's new in .NET 8

.NET 8 is the successor to [.NET 7](dotnet-7.md). It will be [supported for 3 years](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) as a long-term support (LTS) release.

This article has been updated for .NET 8 Preview 1.

> [!IMPORTANT]
> - This information relates to a pre-release product that may be substantially modified before it's commercially released. Microsoft makes no warranties, express or implied, with respect to the information provided here.
> - Most of the other .NET documentation on <https://learn.microsoft.com> has not yet been updated for .NET 8.

## 'dotnet publish' and 'dotnet pack'

The `dotnet publish` and `dotnet pack` commands now produce `Release` assets by default. For more information, see 

## Native AOT

The option to [publish as native AOT](../deploying/native-aot/index.md) was first introduced in .NET 7. Publishing an app with native AOT creates a fully self-contained version of your app that doesn't need a runtime&mdash;everything is included in a single file.

.NET 8 adds support for the x64 and Arm64 architectures on *macOS*.

Also, the size of native AOT apps on Linux are now up to 50% smaller. The following table shows the size of a "Hello World" app published with native AOT that includes the entire .NET runtime on .NET 7 vs. .NET 8:

| Operating system                      | .NET 7  | .NET 8 Preview 1 |
| ------------------------------------- | ------- | ---------------- |
| Linux x64 (with -p:StripSymbols=true) | 3.76 MB | 1.84 MB          |
| Windows x64                           | 2.85 MB | 1.77 MB          |

## CodeGen

Arm64 perf improvements, SIMD improvements, support for AVX-512 ISA extensions, JIT throughput improvements, loop/general optimizations.

## .NET container images

  - Images use [Debian 12 (Bookworm)](https://wiki.debian.org/DebianBookworm). Debian is the default Linux distro in the .NET container images.
  - Images include a non-root user. This user makes the images *non-root* capable. To run as non-root, add a one-liner at the end of your Dockerfiles or a similar instruction in your Kubernetes manifests: `USER app`. The default port also changed from port `80` to `8080`. We also added a new environment variable to make it easier to change ports: `ASPNETCORE_HTTP_PORTS`. It accepts a list of ports, which is simpler than the format required by `ASPNETCORE_URLS`. If you change the port back to port `80` using these variables, you can't run as non-root.
  - Preview container images are now tagged with a tag that ends in `-preview` instead of just using the version number. For example, to pull the .NET 8 Preview SDK, use the following tag:

    `docker run --rm -it mcr.microsoft.com/dotnet/sdk:8.0-preview`
  - Ubuntu Chiseled images are available. This type of image is for developers that want the benefit of appliance-style computing. Chiseled images have a reduced attacked surface because they're ultra-small, have no package manager or shell, and are *non-root*.

## Minimum support baselines for Linux

The minimum support baselines for Linux have been updated for .NET 8:

- .NET will be built targeting Ubuntu 16.04, for all architectures. That's primarily important for defining the minimum `glibc` version for .NET 8. For example, .NET 8 will fail to even start on Ubuntu 14.04.
- For Red Hat Enterprise Linux (RHEL), we will support RHEL 8+, dropping RHEL 7.
- We'll only publish a support statement for RHEL, however, we intend that support to apply to other RHEL ecosystem distros.

## System.Text.Json serialization

Various improvements have been made to <xref:System.Text.Json?displayProperty=fullName> serialization and deserialization functionality.

- Performance and reliability enhancements of the [source generator](../../standard/serialization/system-text-json/source-generation.md) when used in conjunction with ASP.NET Core in Native AOT apps.
- The [source generator](../../standard/serialization/system-text-json/source-generation.md) now supports serializing types with [`required`](../../standard/serialization/system-text-json/required-properties.md) and [`init`](../../../csharp/language-reference/keywords/init.md) properties. These were both already supported in reflection-based serialization.
- [Customize handling of members that aren't in the JSON payload.](../../standard/serialization/system-text-json/missing-members.md)
- Support for serializing properties from interface hierarchies. The following code shows an example where the properties from both the immediately implemented interface and its base interface are serialized.
  
  ```csharp
  IDerived value = new Derived { Base = 0, Derived =1 };
  JsonSerializer.Serialize(value); // {"Base":0,"Derived":1}

  public interface IBase
  {
      public int Base { get; set; }
  }

  public interface IDerived : IBase
  {
      public int Derived { get; set; }
  }

  public class Derived : IDerived
  {
      public int Base { get; set; }
      public int Derived { get; set; }
  }
  ```

- <xref:System.Text.Json.JsonNamingPolicy> includes new naming policies for `snake_case` (with an underscore) and `kebab-case` (with a hyphen) property name conversions. Use these policies similarly to the existing <xref:System.Text.Json.JsonNamingPolicy.CamelCase?displayProperty=nameWithType> policy:

  ```csharp
  var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
  JsonSerializer.Serialize(new { PropertyName = "value" }, options); // { "property_name" : "value" }
  ```

  - JsonSerializer.MakeReadOnly() gives you explicit control over when a JsonSerializerOptions instance is frozen. (Also check it with IsReadOnly.)

For more information about JSON serialization in general, see [JSON serialization and deserialization in .NET](../../standard/serialization/system-text-json/overview.md).

## .NET libraries

.NET 8 brings new and improved APIs. Some of the API improvements are discussed in other sections of this page, such as [System.Text.Json serialization](#systemtextjson-serialization). The following table summarizes some other API additions.

| Description | APIs |
| - | - |
| 

  - System.Random and System.Security.Cryptography.RandomNumberGenerator: Shuffle() and GetItems()
  - System.Numerics and System.Runtime.Intrinsics
    - Improved acceleration of <xref:System.Runtime.Intrinsics.Vector256%601>, <xref:System.Numerics.Matrix3x2>, and <xref:System.Numerics.Matrix4x4>. Added initial implementation of `Vector512<T>`.
    - Hardware intrinsics are annotated with `ConstExpected` attribute.
    - Added the Lerp API to <xref:System.Numerics.IFloatingPointIeee754%601> and therefore to `float` <xref:System.Single>, `double` <xref:System.Double>, and <xref:System.Half>. This allows efficiently and correctly performing a linear interpolation between two values.

  - Performance-focused types
    - New `System.Collections.Frozen` namespace provides `FrozenDictionary<TKey, TValue>` and `FrozenSet<T>` that don't allow any changes to keys/values once created. That requirement allows faster read operations (e.g. `TryGetValue()`). These types are particularly useful for collections populated on first use and then persisted for the duration of a long-lived service.
    - New `IndexOfAnyValues<T>` type.
      - New overloads of methods like <xref:System.String.IndexOfAny%2A?displayProperty=nameWithType> and <xref:System.MemoryExtensions.IndexOfAny%2A?displayProperty=nameWithType> accept an instance of the new type for optimized searching.
      - New `String.IndexOfAnyInRange` method.
    - New `CompositeFormat` type is useful for optimizing format strings that aren't known at compile time (e.g. it's loaded from a resource file). A little extra time is spent up front to do work such as parsing the string, but it saves it from being done on each use.
    - New `XxHash3` and `XxHash128` types provide implementations of the fast XXH3 and XXH128 hash algorithms.



## See also

- [Breaking changes in .NET 8](../compatibility/8.0.md)
<!-- - [.NET blog: Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)-->
<!-- - [.NET blog: ASP.NET Core updates in .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-net-8-preview-1/) -->
