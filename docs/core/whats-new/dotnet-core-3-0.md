---
title: What's new in .NET Core 3.0
description: Learn about the new features found in .NET Core 3.0.
dev_langs:
  - "csharp"
  - "vb"
author: thraka
ms.author: adegeo
ms.date: 04/11/2019
---

# What's new in .NET Core 3.0 (Preview 3)

This article describes what is new in .NET Core 3.0 (preview 3). One of the biggest enhancements is support for Windows desktop applications (Windows only). By using the .NET Core 3.0 SDK component Windows Desktop, you can port your Windows Forms and Windows Presentation Foundation (WPF) applications. To be clear, the Windows Desktop component is only supported and included on Windows. For more information, see the [Windows desktop](#windows-desktop) section later in this article.

.NET Core 3.0 adds support for C# 8.0.

[Download and get started with .NET Core 3.0 Preview 3](https://aka.ms/netcore3download) right now on Windows, Mac, and Linux. You can see complete details of the release in the [.NET Core 3.0 Preview 3 release notes](https://aka.ms/netcore3releasenotes).

For more information about what was released with each version, see the following announcements:

- [.NET Core 3.0 Preview 3 announcement](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-preview-3/)
- [.NET Core 3.0 Preview 2 announcement](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-preview-2/)
- [.NET Core 3.0 Preview 1 announcement](https://devblogs.microsoft.com/dotnet/announcing-net-core-3-preview-1-and-open-sourcing-windows-desktop-frameworks/)

## .NET Core SDK Windows Installer

The MSI installer for Windows has changed starting with .NET Core 3.0. The SDK installers will now upgrade SDK feature-band releases in place. Feature bands are defined in the *hundreds* groups in the *patch* section of the version number. For example, **3.0.*101*** and **3.0.*201*** are versions in two different feature bands while **3.0.*101*** and **3.0.*199*** are in the same feature band. And, when .NET Core SDK **3.0.*101*** is installed, .NET Core SDK **3.0.*100*** will be removed from the machine if it exists. When .NET Core SDK **3.0.*200*** is installed on the same machine, .NET Core SDK **3.0.*101*** won't be removed.

For more information about versioning, see [Overview of how .NET Core is versioned](../versions/index.md).

## C# 8

.NET Core 3.0 supports C# 8. For more information about C# 8.0 features, see [What's new in C# 8.0](../../csharp/whats-new/csharp-8.md).

## .NET Standard 2.1

Even though .NET Core 3.0 supports **.NET Standard 2.1**, the default `dotnet new classlib` template generates a project that targets **.NET Standard 2.0**. To target **.NET Standard 2.1**, edit your project file and change the `TargetFramework` property to `netstandard2.1`:

```xml
<Project Sdk="Microsoft.NET.Sdk">
 
  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
  </PropertyGroup>
 
</Project>
```

If you're using Visual Studio, you need Visual Studio 2019 as Visual Studio 2017 doesn't support **.NET Standard 2.1** or **.NET Core 3.0**.


## APIs


## IEEE Floating-point improvements

Floating point APIs are being updated to comply with [IEEE 754-2008 revision](https://en.wikipedia.org/wiki/IEEE_754-2008_revision). The goal of these changes is to expose all **required** operations and ensure that they're behaviorally compliant with the IEEE spec. For more information about floating-point improvements, see the [Floating-Point Parsing and Formatting improvements in .NET Core 3.0](https://devblogs.microsoft.com/dotnet/floating-point-parsing-and-formatting-improvements-in-net-core-3-0/) blog post.

Parsing and formatting fixes include:

* Correctly parse and round inputs of any length.
* Correctly parse and format negative zero.
* Correctly parse `Infinity` and `NaN` by doing a case-insensitive check and allowing an optional preceding `+` where applicable.

New <xref:System.Math?displayProperty=nameWithType> APIs include:

* <xref:System.Math.BitIncrement(Double)> and <xref:System.Math.BitDecrement(Double)>\
Corresponds to the `nextUp` and `nextDown` IEEE operations. They return the smallest floating-point number that compares greater or lesser than the input (respectively). For example, `Math.BitIncrement(0.0)` would return `double.Epsilon`.

* <xref:System.Math.MaxMagnitude(Double, Double)> and <xref:System.Math.MinMagnitude(Double, Double)>\
Corresponds to the `maxNumMag` and `minNumMag` IEEE operations, they return the value that is greater or lesser in magnitude of the two inputs (respectively). For example, `Math.MaxMagnitude(2.0, -3.0)` would return `-3.0`.

* <xref:System.Math.ILogB(Double)>\
Corresponds to the `logB` IEEE operation that returns an integral value, it returns the integral base-2 log of the input parameter. This method is effectively the same as `floor(log2(x))`, but done with minimal rounding error.

* <xref:Systen.Math.ScaleB(Double, Int32)>\
Corresponds to the `scaleB` IEEE operation that takes an integral value, it returns effectively `x * pow(2, n)`, but is done with minimal rounding error.

* <xref:System.Math.Log2(Double)>\
Corresponds to the `log2` IEEE operation, it returns the base-2 logarithm. It minimizes rounding error.

* <xref:System.Math.FusedMultiplyAdd(Double, Double, Double)>\
Corresponds to the `fma` IEEE operation, it performs a fused multiply add. That is, it does `(x * y) + z` as a single operation, there-by minimizing the rounding error. An example would be `FusedMultiplyAdd(1e308, 2.0, -1e308)` which returns `1e308`. The regular `(1e308 * 2.0) - 1e308` returns `double.PositiveInfinity`.

* <xref:System.Math.CopySign(Double, Double)>\
Corresponds to the `copySign` IEEE operation, it returns the value of `x`, but with the sign of `y`.

## .NET Platform-Dependent Intrinsics

APIs have been added that allow access to certain perf-oriented CPU instructions, such as the **SIMD** or **Bit Manipulation instruction** sets. These instructions can help achieve significant performance improvements in certain scenarios, such as processing data efficiently in parallel. 

Where appropriate, the .NET libraries have begun using these instructions to improve performance.

For more information, see [.NET Platform Dependent Intrinsics](https://github.com/dotnet/designs/blob/master/accepted/platform-intrinsics.md).


## Default executables

.NET Core now builds [framework-dependent executables](../deploying/index.md#framework-dependent-executables-fde) by default. This behavior is new for applications that use a globally installed version of .NET Core. Previously, only [self-contained deployments](../deploying/index.md#self-contained-deployments-scd) would produce an executable.

During `dotnet build` or `dotnet publish`, an executable is created that matches the environment and platform of the SDK you're using. You can expect the same things with these executables as you would other native executables, such as:

* You can double-click on the executable.
* You can launch the application from a command prompt directly, such as `myapp.exe` on Windows, and `./myapp` on Linux and macOS.

## Build copies dependencies

The `dotnet build` command now copies NuGet dependencies for your application from the NuGet cache to the build output folder. Previously, dependencies were only copied as part of `dotnet publish`.

There are some operations, like linking and razor page publishing that will still require publishing.

## Local dotnet tools

.NET Core 3.0 introduces local tools. Local tools are similar to [global tools](../tools/global-tools.md) but are associated with a particular location on disk. Local tools aren't available globally and are distributed as NuGet packages.

> [!WARNING]
> If you tried local tools in .NET Core 3.0 Preview 1, such as running `dotnet tool restore` or `dotnet tool install`, delete the local tools cache folder. Otherwise, local tools won't work on any newer release. This folder is located at:
>
> On macOS, Linux: `rm -r $HOME/.dotnet/toolResolverCache`
>
> On Windows: `rmdir /s %USERPROFILE%\.dotnet\toolResolverCache`

Local tools rely on a manifest file name `dotnet-tools.json` in your current directory. This manifest file defines the tools to be available at that folder and below. You can distribute the manifest file with your code to ensure that anyone who works with your code can restore and use the same tools.

For both global and local tools, a compatible version of the runtime is required. Many tools currently on NuGet.org target .NET Core Runtime 2.1. To install these tools globally or locally, you would still need to install the [NET Core 2.1 Runtime](https://dotnet.microsoft.com/download/dotnet-core/2.1).


## Windows desktop

.NET Core 3.0 supports Windows desktop applications using Windows Presentation Foundation and Windows Forms. These frameworks also support using modern controls and Fluent styling from the Windows UI XAML Library (WinUI) via [XAML islands](/windows/uwp/xaml-platform/xaml-host-controls).

The Windows Desktop component is part of the Windows .NET Core 3.0 SDK.

You can create a new WPF or Windows Forms app with the following `dotnet` commands:

```console
dotnet new wpf
dotnet new winforms
```

Visual Studio 2019 adds **New Project** templates for .NET Core 3.0 Windows Forms and WPF.

For more information about how to port an existing .NET Framework application, see [Port WPF projects](../porting/winforms.md) and [Port Windows Forms projects](../porting/wpf.md).

## MSIX Deployment for Windows Desktop

[MSIX](https://docs.microsoft.com/windows/msix/) is a new Windows application package format. It can be used to deploy .NET Core 3.0 desktop applications to Windows 10.

The [Windows Application Packaging Project](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-packaging-dot-net), available in Visual Studio 2019, allows you to create MSIX packages with [self-contained](../deploying/index.md#self-contained-deployments-scd) .NET Core applications.

The .NET Core project file must specify the supported runtimes in the `<RuntimeIdentifiers>` property:

```xml
<RuntimeIdentifiers>win-x86;win-x64</RuntimeIdentifiers>
```

## WinForms HighDPI

.NET Core Windows Forms applications can set High DPI mode with <xref:System.Windows.Forms.Application.SetHighDpiMode(System.Windows.Forms.HighDpiMode)>. The `SetHighDpiMode` method sets the corresponding High DPI mode unless the setting has been set by other means like `App.Manifest` or P/Invoke before `Application.Run`.

The possible `highDpiMode` values, as expressed by the <xref:System.Windows.Forms.HighDpiMode> enum are:

* `DpiUnaware`
* `SystemAware`
* `PerMonitor`
* `PerMonitorV2`
* `DpiUnawareGdiScaled`

For more information about High DPI modes, see [High DPI Desktop Application Development on Windows](/windows/desktop/hidpi/high-dpi-desktop-application-development-on-windows).

## Fast built-in JSON support

.NET users have largely relied on [**Json.NET**](https://www.newtonsoft.com/json) and other popular JSON libraries, which continue to be good choices. **Json.NET** uses .NET strings as its base datatype, which is UTF-16 under the hood.

The new built-in JSON support is high-performance, low allocation, and based on `Span<byte>`. Three new main JSON-related types have been added to .NET Core 3.0 the <xref:System.Text.Json?displayProperty=nameWithType> namespace. These types don't *yet* support plain old CLR object (POCO) serialization and deserialization.

### Utf8JsonReader

<xref:System.Text.Json.Utf8JsonReader?displayProperty=nameWithType> is a high-performance, low allocation, forward-only reader for UTF-8 encoded JSON text, read from a `ReadOnlySpan<byte>`. The `Utf8JsonReader` is a foundational, low-level type, that can be leveraged to build custom parsers and deserializers. Reading through a JSON payload using the new `Utf8JsonReader` is 2x faster than using the reader from **Json.NET**. It doesn't allocate until you need to actualize JSON tokens as (UTF-16) strings.

Here is the basic reader loop that prints JSON string and boolean values:

[!CODE-csharp[Utf8JsonReader](~/samples/core/whats-new/whats-new-in-30/cs/program.cs#PrintJson)]

### Utf8JsonWriter

<xref:System.Text.Json.Utf8JsonWriter?displayProperty=nameWithType> provides a high-performance, non-cached, forward-only way to write UTF-8 encoded JSON text from common .NET types like `String`, `Int32`, and `DateTime`. Like the reader, the writer is a foundational, low-level type, that can be leveraged to build custom serializers. Writing a JSON payload using the new `Utf8JsonWriter` is 30-80% faster than using the writer from **Json.NET** and does not allocate.

### JsonDocument

<xref:System.Text.Json.JsonDocument?displayProperty=nameWithType> is built on top of the `Utf8JsonReader`. The `JsonDocument` provides the ability to parse JSON data and build a read-only Document Object Model (DOM) that can be queried to support random access and enumeration. The JSON elements that compose the data can be accessed via the <xref:System.Text.Json.JsonElement> type that is exposed by the `JsonDocument` as a property called `RootElement`. The `JsonElement` contains the JSON array and object enumerators along with APIs to convert JSON text to common .NET types. Parsing a typical JSON payload and accessing all its members using the `JsonDocument` is 2-3x faster than **Json.NET** with little allocations for data that is reasonably sized (that is, < 1 MB).

Here is a sample usage of the `JsonDocument` and `JsonElement` that can be used as a starting point:

[!CODE-csharp[JsonDocument](~/samples/core/whats-new/whats-new-in-30/cs/program.cs#ReadJson)]

