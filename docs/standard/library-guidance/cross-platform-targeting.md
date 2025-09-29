---
title: Cross-platform targeting for .NET libraries
description: Best practice recommendations for creating cross-platform .NET libraries.
ms.date: 08/20/2025
---

# Cross-platform targeting

Modern .NET supports multiple operating systems and devices. It's important for .NET open-source libraries to support as many developers as possible, whether they're building an ASP.NET website hosted in Azure, or a .NET game in Unity.

When choosing target frameworks for your library, it's important to distinguish between two different goals:

- **Modern APIs and patterns**: Your library leans into the benefits of the recent versions of the .NET platform. You use modern language patterns and support advanced deployment models like Native Ahead-of-Time compilation on the CoreCLR.
- **Breadth targeting**: Your library supports a wide range of .NET implementations and versions to maximize compatibility across different user scenarios.

These goals don't always require the same approach. If your target applications all use modern .NET, your libraries can target the same modern .NET versions without needing to target older frameworks.

## .NET and .NET Standard targets

.NET and .NET Standard targets are the best way to add cross-platform support to a .NET library.

* .NET versions 5 through 10 are implementations of .NET. Each version is a single product with a uniform set of capabilities and APIs that can be used for Windows desktop apps and cross-platform console apps, cloud services, and websites.
* [.NET Standard](../net-standard.md) is a specification of .NET APIs that are available on all .NET implementations. Targeting .NET Standard lets you produce libraries that are constrained to use APIs that are in a given version of .NET Standard, which means it's usable by all platforms that implement that version of .NET Standard.

For more information about how .NET compares to .NET Standard, see [.NET 5 and .NET Standard](../net-standard.md#net-5-and-net-standard).

![.NET Standard](./media/cross-platform-targeting/platforms-netstandard.png)

If your project targets .NET or .NET Standard and compiles successfully, it doesn't guarantee that the library will run successfully on all platforms:

- Platform-specific APIs will fail on other platforms. For example, <xref:Microsoft.Win32.Registry?displayProperty=nameWithType> will succeed on Windows and throw <xref:System.PlatformNotSupportedException> when used on any other OS.
- APIs can behave differently. For example, reflection APIs have different performance characteristics when an application uses ahead-of-time compilation on iOS or UWP.

> [!TIP]
> The .NET team offers a [Platform compatibility analyzer](../analyzers/platform-compat-analyzer.md) to help you discover possible issues.

✔️ DO start with including a `net8.0` target or later for new libraries.

> For new libraries, targeting modern .NET (such as .NET 8 or later) provides access to the latest APIs and performance improvements, and enables features like AOT and trimming. Modern .NET versions are cross-platform and provide excellent compatibility across Windows, Linux, and macOS.

✔️ CONSIDER including a `netstandard2.0` target if you need broad compatibility or .NET Framework support.

> .NET Standard 2.0 is supported by .NET Framework 4.6.1+ and all modern .NET implementations. Include this target when you need to support .NET Framework applications or when building libraries for maximum compatibility across different .NET ecosystems.

❌ AVOID including a `netstandard1.x` target.

> .NET Standard 1.x is distributed as a granular set of NuGet packages, which creates a large package dependency graph and results in the download of a lot of packages when building. Modern .NET implementations support .NET Standard 2.0. You should only target .NET Standard 1.x if you specifically need to target an older platform.

✔️ DO include a `netstandard2.0` target if you require a `netstandard1.x` target.

> All platforms supporting .NET Standard 2.0 will use the `netstandard2.0` target and benefit from having a smaller package graph while older platforms will still work and fall back to using the `netstandard1.x` target.

❌ DO NOT include a .NET Standard target if the library relies on a platform-specific app model.

> For example, a UWP control toolkit library depends on an app model that is only available on UWP. App model specific APIs aren't available in .NET Standard.

❌ DO NOT publish for `netstandard2.0` if your project or dependencies multi-target.

> `netstandard2.0` is not a runtime, and multi-targeted projects provide a runtime framework&mdash;specific library, which is required when running on other frameworks.

## Multi-targeting

Sometimes you need to access framework-specific APIs from your libraries. The best way to call framework-specific APIs is to use multi-targeting, which builds your project for many [.NET target frameworks](../frameworks.md) rather than for just one.

To shield your consumers from having to build for individual frameworks, you should strive to have a .NET Standard output plus one or more framework-specific outputs. With you multi-target, all assemblies are packaged inside a single NuGet package. Consumers can then reference the same package and NuGet will pick the appropriate implementation. Your .NET Standard library serves as the fallback library that is used everywhere, except for the cases where your NuGet package offers a framework-specific implementation. Multi-targeting allows you to use conditional compilation in your code and call framework-specific APIs.

![NuGet package with multiple assemblies](./media/cross-platform-targeting/nuget-package-multiple-assemblies.png)

✔️ CONSIDER targeting .NET implementations in addition to .NET Standard.

> Targeting .NET implementations allows you to call platform-specific APIs that are outside of .NET Standard.
>
> Do not drop support for .NET Standard when you do this. Instead, throw from the implementation and offer capability APIs. This way, your library can be used anywhere and supports run-time light-up of features.

```csharp
public static class GpsLocation
{
    // This project uses multi-targeting to expose device-specific APIs to .NET Standard.
    public static async Task<(double latitude, double longitude)> GetCoordinatesAsync()
    {
#if NET462
        return CallDotNetFrameworkApi();
#elif WINDOWS_UWP
        return CallUwpApi();
#else
        throw new PlatformNotSupportedException();
#endif
    }

    // Allows callers to check without having to catch PlatformNotSupportedException
    // or replicating the OS check.
    public static bool IsSupported
    {
        get
        {
#if NET462 || WINDOWS_UWP
            return true;
#else
            return false;
#endif
        }
    }
}
```

✔️ CONSIDER multi-targeting even if your source code is the same for all targets, when your project has any library or package dependencies.

> Your project's dependent packages, either direct or downstream, might use the same code APIs while wrapped inside different versions of the dependent assembly per target framework. Adding specific targets ensures that your consumers do not need to add or update their assembly binding redirects.

❌ AVOID multi-targeting as well as targeting .NET Standard, if your source code is the same for all targets and your project has no library or package dependencies.

> The .NET Standard assembly will automatically be used by NuGet. Targeting individual .NET implementations increases the `*.nupkg` size for no benefit.

✔️ CONSIDER adding a target for `net462` when you're also targeting `netstandard2.0`.

> Using .NET Standard 2.0 from .NET Framework has some issues that were addressed in .NET Framework 4.7.2. You can improve the experience for developers that are still on .NET Framework 4.6.2 - 4.7.1 by offering them a binary that's built for .NET Framework 4.6.2.

✔️ DO distribute your library using a NuGet package.

> NuGet will select the best target for the developer and shield them having to pick the appropriate implementation.

✔️ DO use a project file's `TargetFrameworks` property when multi-targeting.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <!-- This project will output net8.0 and netstandard2.0 assemblies -->
    <TargetFrameworks>net8.0;netstandard2.0</TargetFrameworks>
  </PropertyGroup>
</Project>
```

❌ AVOID changing the assembly name or using different assembly names for each TFM your library compiles. Due to dependencies between libraries, multi-targeting with different assembly names per TFM can break package consumers. An assembly should have the same name across all TFMs.

## Older targets

.NET supports targeting versions of .NET Framework that are out of support as well as platforms that are no longer in common use. While there's value in making your library work on as many targets as possible, having to work around missing APIs can add significant overhead. Considering their reach and limitations, certain frameworks are no longer worth targeting.

❌ DO NOT include a Portable Class Library (PCL) target. For example, `portable-net45+win8+wpa81+wp8`.

> .NET Standard is the modern way to support cross-platform .NET libraries and replaces PCLs.

❌ DO NOT include targets for .NET platforms that are no longer supported. For example, `SL4`, `WP`.

>[!div class="step-by-step"]
>[Previous](get-started.md)
>[Next](strong-naming.md)
