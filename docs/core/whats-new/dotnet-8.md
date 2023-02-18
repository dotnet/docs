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
> - Most of the existing documentation has not yet been updated for .NET 8.

- NativeAOT support for macOS x64 and arm64
- Smaller NativeAOT app size on Linux. The option to publish as Native AOT was first introduced in .NET 7. In .NET 8, we're refining some of the fundamentals such as size. Publishing app with Native AOT creates a fully self-contained version of you app that doesn't need a runtime - everything is included in a single file. We worked on making this single file smaller. Linux builds are now up to 50% smaller.

  This table shows the size of a "Hello World" app with Native AOT that includes the entire .NET runtime:

  | Operating system                      | .NET 7  | .NET 8 Preview 1 |
  | ------------------------------------- | ------- | ---------------- |
  | Linux x64 (with -p:StripSymbols=true) | 3.76 MB | 1.84 MB          |
  | Windows x64                           | 2.85 MB | 1.77 MB          |

- CodeGen:
  - Arm64 perf improvements, SIMD improvements, support for AVX-512 ISA extensions, JIT throughput improvements, loop/general optimizations.
- .NET container images
  - Images use [Debian 12 (Bookworm)](https://wiki.debian.org/DebianBookworm). Debian is the default Linux distro in the .NET container images.
  - Images include a non-root user. This user makes the images *non-root* capable. To run as non-root, add a one-liner at the end of your Dockerfiles or a similar instruction in your Kubernetes manifests: `USER app`. The default port also changed from port `80` to `8080`. We also added a new environment variable to make it easier to change ports: `ASPNETCORE_HTTP_PORTS`. It accepts a list of ports, which is simpler than the format required by `ASPNETCORE_URLS`. If you change the port back to port `80` using these variables, you can't run as non-root.
  - Preview container images are now tagged with a tag that ends in `-preview` instead of just using the version number. For example, to pull the .NET 8 Preview SDK, use the following tag:

    `docker run --rm -it mcr.microsoft.com/dotnet/sdk:8.0-preview`
  - Ubuntu Chiseled images are available. This type of image is for developers that want the benefit of appliance-style computing. Chiseled images have a reduced attacked surface because they're ultra-small, have no package manager or shell, and are *non-root*.
- `dotnet publish` and `dotnet pack` produce `Release` assets by default
- Updated minimum support baselines for Linux
  - .NET will be built targeting Ubuntu 16.04, for all architectures. That's primarily important for defining the minimum `glibc` version for .NET 8. For example, .NET 8 will fail to even start on Ubuntu 14.04.
  - For Red Hat Enterprise Linux (RHEL), we will support RHEL 8+, dropping RHEL 7.
  - We'll only publish a support statement for RHEL, however, we intend that support to apply to other RHEL ecosystem distros.
- Libraries
  - System.Random and System.Security.Cryptography.RandomNumberGenerator: Shuffle() and GetItems()
  - System.Numerics and System.Runtime.Intrinsics
    - Improved acceleration of <xref:System.Runtime.Intrinsics.Vector256%601>, <xref:System.Numerics.Matrix3x2>, and <xref:System.Numerics.Matrix4x4>. Added initial implementation of `Vector512<T>`.
    - Hardware intrinsics are annotated with `ConstExpected` attribute.
    - Added the Lerp API to <xref:System.Numerics.IFloatingPointIeee754%601> and therefore to `float` <xref:System.Single>, `double` <xref:System.Double>, and <xref:System.Half>. This allows efficiently and correctly performing a linear interpolation between two values.
  - System.Text.Json
    - Missing member handling
    - Perf/reliability improvements of source generator when used with ASP.NET Core in NativeAOT apps
    - Source generator now supports serialized types with `required` and `init` properties
    - Serialization support for interface hierarchies
    - New naming policies for snake case and kebab case
    - JsonSerializer.MakeReadOnly() gives you explicit control over when a JsonSerializerOptions instance is frozen. (Also check it with IsReadOnly.)
  - Performance-focused types
    - New `System.Collections.Frozen` namespace provides `FrozenDictionary<TKey, TValue>` and `FrozenSet<T>` that don't allow any changes to keys/values once created. That requirement allows faster read operations (e.g. `TryGetValue()`). These types are particularly useful for collections populated on first use and then persisted for the duration of a long-lived service.
    - New `IndexOfAnyValues<T>` type.
      - New overloads of methods like <xref:System.String.IndexOfAny%2A?displayProperty=nameWithType> and <xref:System.MemoryExtensions.IndexOfAny%2A?displayProperty=nameWithType> accept an instance of the new type for optimized searching.
      - New `String.IndexOfAnyInRange` method.
    - New `CompositeFormat` type is useful for optimizing format strings that aren't known at compile time (e.g. it's loaded from a resource file). A little extra time is spent up front to do work such as parsing the string, but it saves it from being done on each use.
    - New `XxHash3` and `XxHash128` types provide implementations of the fast XXH3 and XXH128 hash algorithms.



## See also

- [Breaking changes in .NET 8](../compatibility/8.0.md)
