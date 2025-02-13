---
title: Target frameworks in SDK-style projects - .NET
description: Learn about target frameworks for .NET apps and libraries.
ms.date: 11/11/2024
ms.service: dotnet
ms.custom: updateeachrelease
ms.subservice: standard-library
f1_keywords:
- http://schemas.microsoft.com/developer/msbuild/2003#TargetFramework
---
# Target frameworks in SDK-style projects

When you target a framework in an app or library, you're specifying the set of APIs that you'd like to make available to the app or library. You specify the target framework in your project file using a target framework moniker (TFM).

An app or library can target a version of [.NET Standard](net-standard.md). .NET Standard versions represent standardized sets of APIs across all .NET implementations. For example, a library can target .NET Standard 1.6 and gain access to APIs that function across .NET Core and .NET Framework using the same codebase.

An app or library can also target a specific .NET implementation to gain access to implementation-specific APIs. For example, an app that targets Universal Windows Platform (UWP, `uap10.0`) has access to APIs that compile for devices that run Windows 10.

For some target frameworks, such as .NET Framework, the APIs are defined by the assemblies that the framework installs on a system and may include application framework APIs (for example, ASP.NET).

For package-based target frameworks (for example, .NET 5+, .NET Core, and .NET Standard), the APIs are defined by the NuGet packages included in the app or library.

## Latest versions

The following table defines the most common target frameworks, how they're referenced, and which version of [.NET Standard](net-standard.md) they implement. These target framework versions are the latest stable versions. Prerelease versions aren't shown. A *target framework moniker* (TFM) is a standardized token format for specifying the target framework of a .NET app or library.

| Target framework | Latest <br/> stable version | Target framework moniker (TFM) | Implemented <br/> .NET Standard version |
|:----------------:|:---------------------------:|:------------------------------:|:---------------------------------------:|
| .NET 9           | 9                           | net9.0                         | 2.1                                     |
| .NET 8           | 8                           | net8.0                         | 2.1                                     |
| .NET Standard    | 2.1                         | netstandard2.1                 | N/A                                     |
| .NET Core        | 3.1                         | netcoreapp3.1                  | 2.1                                     |
| .NET Framework   | 4.8.1                       | net481                         | 2.0                                     |

## Supported target frameworks

A target framework is typically referenced by a TFM. The following table shows the target frameworks supported by the .NET SDK and the NuGet client. Equivalents are shown within brackets. For example, `win81` is an equivalent TFM to `netcore451`.

| Target Framework           | TFM |
| -------------------------- | --- |
| .NET 5+ (and .NET Core)    | netcoreapp1.0<br>netcoreapp1.1<br>netcoreapp2.0<br>netcoreapp2.1<br>netcoreapp2.2<br>netcoreapp3.0<br>netcoreapp3.1<br>net5.0*<br>net6.0*<br>net7.0*<br>net8.0* |
| .NET Standard              | netstandard1.0<br>netstandard1.1<br>netstandard1.2<br>netstandard1.3<br>netstandard1.4<br>netstandard1.5<br>netstandard1.6<br>netstandard2.0<br>netstandard2.1 |
| .NET Framework             | net11<br>net20<br>net35<br>net40<br>net403<br>net45<br>net451<br>net452<br>net46<br>net461<br>net462<br>net47<br>net471<br>net472<br>net48<br>net481 |
| Windows Store              | netcore [netcore45]<br>netcore45 [win] [win8]<br>netcore451 [win81] |
| .NET Micro Framework       | netmf |
| Silverlight                | sl4<br>sl5 |
| Windows Phone              | wp [wp7]<br>wp7<br>wp75<br>wp8<br>wp81<br>wpa81 |
| Universal Windows Platform | uap [uap10.0]<br>uap10.0 [win10] [netcore50] |

\* .NET 5 and later TFMs include some operating system-specific variations. For more information, see the following section, [.NET 5+ OS-specific TFMs](#net-5-os-specific-tfms).

### .NET 5+ OS-specific TFMs

The `net5.0`, `net6.0`, `net7.0`, `net8.0`, and `net.0` TFMs include technologies that work across different platforms. Specifying an *OS-specific TFM* makes APIs that are specific to an operating system available to your app, for example, Windows Forms or iOS bindings. OS-specific TFMs also inherit every API available to their base TFM, for example, the `net9.0` TFM.

.NET 5 introduced the `net5.0-windows` OS-specific TFM, which includes Windows-specific bindings for WinForms, WPF, and UWP APIs. .NET 6 and later versions have additional OS-specific TFMs, for example, `net6.0-ios`.

The following table shows the compatibility of the .NET 5+ TFMs.

| TFM                  | Compatible with                                                  |
|----------------------|------------------------------------------------------------------|
| `net5.0`             | net1..4 (with NU1701 warning)<br />netcoreapp1..3.1 (warning when WinForms or WPF is referenced)<br />netstandard1..2.1 |
| `net5.0-windows`     | netcoreapp1..3.1 (plus everything else inherited from `net5.0`)  |
| `net6.0`             | (Subsequent version of `net5.0`)                                 |
| `net6.0-android`     | `xamarin.android` (plus everything else inherited from `net6.0`) |
| `net6.0-ios`         | Everything inherited from `net6.0`                               |
| `net6.0-maccatalyst` | Everything inherited from `net6.0`                               |
| `net6.0-macos`       | Everything inherited from `net6.0`                               |
| `net6.0-tvos`        | Everything inherited from `net6.0`                               |
| `net6.0-windows`     | (Subsequent version of `net5.0-windows`)                         |
| `net7.0`             | (Subsequent version of `net6.0`)                                 |
| `net7.0-android`     | (Subsequent version of `net6.0-android`)                         |
| `net7.0-ios`         | (Subsequent version of `net6.0-ios`)                             |
| `net7.0-maccatalyst` | (Subsequent version of `net6.0-maccatalyst`)                     |
| `net7.0-macos`       | (Subsequent version of `net6.0-macos`)                           |
| `net7.0-tizen`       | `tizen40` (plus everything else inherited from `net7.0`)         |
| `net7.0-tvos`        | (Subsequent version of `net6.0-tvos`)                            |
| `net7.0-windows`     | (Subsequent version of `net6.0-windows`)                         |
| `net8.0`             | (Subsequent version of `net7.0`)                                 |
| `net8.0-android`     | (Subsequent version of `net7.0-android`)                         |
| `net8.0-browser`     | Everything inherited from `net8.0`                               |
| `net8.0-ios`         | (Subsequent version of `net7.0-ios`)                             |
| `net8.0-maccatalyst` | (Subsequent version of `net7.0-maccatalyst`)                     |
| `net8.0-macos`       | (Subsequent version of `net7.0-macos`)                           |
| `net8.0-tizen`       | (Subsequent version of `net7.0-tizen`)                           |
| `net8.0-tvos`        | (Subsequent version of `net7.0-tvos`)                            |
| `net8.0-windows`     | (Subsequent version of `net7.0-windows`)                         |
| `net9.0`             | (Subsequent version of `net8.0`)                                 |
| `net9.0-android`     | (Subsequent version of `net8.0-android`)                         |
| `net9.0-browser`     | (Subsequent version of `net8.0-browser`)                         |
| `net9.0-ios`         | (Subsequent version of `net8.0-ios`)                             |
| `net9.0-maccatalyst` | (Subsequent version of `net8.0-maccatalyst`)                     |
| `net9.0-macos`       | (Subsequent version of `net8.0-macos`)                           |
| `net9.0-tizen`       | (Subsequent version of `net8.0-tizen`)                           |
| `net9.0-tvos`        | (Subsequent version of `net8.0-tvos`)                            |
| `net9.0-windows`     | (Subsequent version of `net8.0-windows`)                         |

To make your app portable across different platforms but still have access to OS-specific APIs, you can target multiple OS-specific TFMs and add platform guards around OS-specific API calls using `#if` preprocessor directives. For a list of the available symbols, see [Preprocessor symbols](#preprocessor-symbols).

#### Suggested targets

Use these guidelines to determine which TFM to use in your app:

- Apps that are portable to multiple platforms should target a base TFM, for example, `net9.0`. This includes most libraries but also ASP.NET Core and Entity Framework.
- Platform-specific libraries should target platform-specific flavors. For example, WinForms and WPF projects should target `net9.0-windows`.
- Cross-platform application models (for example, ASP.NET Core) should at least target the base TFM, for example, `net9.0`, but might also target additional platform-specific flavors to light-up more APIs or features.

#### OS version in TFMs

You can also specify an optional OS version at the end of an OS-specific TFM, for example, `net6.0-ios15.0`. The version indicates which APIs are available to your app or library. It doesn't control the OS version that your app or library supports at run time. It's used to select the reference assemblies that your project compiles against, and to select assets from NuGet packages. Think of this version as the "platform version" or "OS API version" to disambiguate it from the run-time OS version.

When an OS-specific TFM doesn't specify the platform version explicitly, it has an implied value that can be inferred from the base TFM and platform name. For example, the default platform value for Android in .NET 6 is `31.0`, which means that `net6.0-android` is shorthand for the canonical `net6.0-android31.0` TFM. The implied platform version for a newer base TFM may be higher, for example, a future `net8.0-android` TFM could map to `net8.0-android34.0`. The shorthand form is intended for use in project files only, and is expanded to the canonical form by the .NET SDK's MSBuild targets before being passed to other tools, such as NuGet.

The following table shows the default target platform values (TPV) for each .NET release.

| .NET version | Android | iOS  | Mac Catalyst | macOS | tvOS | Tizen | Windows |
|--------------|--------:|-----:|-------------:|------:|-----:|------:|--------:|
| .NET 8       |    34.0 | 17.2 |         17.2 | 14.2  | 17.1 |  10.0 |    10.0 |
| .NET 9       |    35.0 | 18.0 |         18.0 | 15.0  |      |  10.0 |    10.0 |

> [!NOTE]
> On Apple platforms (iOS, macOS, tvOS, and Mac Catalyst) in .NET 8 and earlier,
> the default TPV is the latest supported version in the currently installed workload.
> That means that updating the iOS workload in .NET 8, for example, might result in a higher default
> TPV, if support for a new version of iOS has been added in that workload. In the preceding table,
> the default TPV is the one in the initial release for the stated .NET version.
>
> Starting in .NET 9, this special behavior only applies to executable projects.
> The default TPV for library projects now stays the same for the entirety of
> a major .NET release, like all other platforms.

The .NET SDK is designed to be able to support newly released APIs for an individual platform without a new version of the base TFM. This enables you to access platform-specific functionality without waiting for a major release of .NET. You can gain access to these newly released APIs by incrementing the platform version in the TFM. For example, if the Android platform added API level 32 APIs in a .NET 6.0.x SDK update, you could access them by using the TFM `net6.0-android32.0`.

#### Precedence

If your app references a package that has multiple assets for different TFMs, the assets that are closer in version number are preferred. For example, if your app targets `net6.0-ios` and the package offers assets for `net6.0` and `net5.0-ios`, the `net6.0` assets are used. For more information, see [Precedences](https://github.com/dotnet/designs/blob/main/accepted/2020/net5/net5.md#precedences).

#### Support older OS versions

Although a platform-specific app or library is compiled against APIs from a specific version of that OS, you can make it compatible with earlier OS versions by adding the `SupportedOSPlatformVersion` property to your project file. The `SupportedOSPlatformVersion` property indicates the minimum OS version required to run your app or library. If you don't explicitly specify this minimum run-time OS version in the project, it defaults to the platform version from the TFM.

For your app to run correctly on an older OS version, it can't call APIs that don't exist on that version of the OS. However, you can add guards around calls to newer APIs so they are only called when running on a version of the OS that supports them. This pattern allows you to design your app or library to support running on older OS versions while taking advantage of newer OS functionality when running on newer OS versions.

The `SupportedOSPlatformVersion` value (whether explicit or default) is used by the [platform compatibility analyzer](analyzers/platform-compat-analyzer.md), which detects and warns about unguarded calls to newer APIs. It's burned into the project's compiled assembly as an <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute> assembly attribute, so that the platform compatibility analyzer can detect unguarded calls to that assembly's APIs from projects with a lower `SupportedOSPlatformVersion` value. On some platforms, the `SupportedOSPlatformVersion` value affects platform-specific app packaging and build processes, which is covered in the documentation for those platforms.

Here is an example excerpt of a project file that uses the `TargetFramework` and `SupportedOSPlatformVersion` MSBuild properties to specify that the app or library has access to iOS 15.0 APIs but supports running on iOS 13.0 and above:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0-ios15.0</TargetFramework>
    <SupportedOSPlatformVersion>13.0</SupportedOSPlatformVersion>
  </PropertyGroup>
  ...

</Project>
```

## How to specify a target framework

Target frameworks are specified in a project file. When a single target framework is specified, use the [TargetFramework element](../core/project-sdk/msbuild-props.md#targetframework). The following console app project file demonstrates how to target .NET 9:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>

</Project>
```

When you specify multiple target frameworks, you may conditionally reference assemblies for each target framework. In your code, you can conditionally compile against those assemblies by using [preprocessor symbols](#preprocessor-symbols) with *if-then-else* logic.

The following library project targets APIs of .NET Standard (`netstandard1.4`) and .NET Framework (`net40` and `net45`). Use the plural [TargetFrameworks element](../core/project-sdk/msbuild-props.md#targetframeworks) with multiple target frameworks. The `Condition` attributes include implementation-specific packages when the library is compiled for the two .NET Framework TFMs:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>netstandard1.4;net40;net45</TargetFrameworks>
  </PropertyGroup>

  <!-- Conditionally obtain references for the .NET Framework 4.0 target -->
  <ItemGroup Condition=" '$(TargetFramework)' == 'net40' ">
    <Reference Include="System.Net" />
  </ItemGroup>

  <!-- Conditionally obtain references for the .NET Framework 4.5 target -->
  <ItemGroup Condition=" '$(TargetFramework)' == 'net45' ">
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Threading.Tasks" />
  </ItemGroup>

</Project>
```

Within your library or app, you write conditional code using [preprocessor directives](../csharp/language-reference/preprocessor-directives.md#conditional-compilation) to compile for each target framework:

```csharp
public class MyClass
{
    static void Main()
    {
#if NET40
        Console.WriteLine("Target framework: .NET Framework 4.0");
#elif NET45
        Console.WriteLine("Target framework: .NET Framework 4.5");
#else
        Console.WriteLine("Target framework: .NET Standard 1.4");
#endif
    }
}
```

## Preprocessor symbols

The build system is aware of preprocessor symbols representing the target frameworks shown in the [Supported target framework versions](#supported-target-frameworks) table when you're using SDK-style projects. To convert a .NET Standard, .NET Core, or .NET 5+ TFM to a preprocessor symbol, replace dots and hyphens with an underscore, and change lowercase letters to uppercase (for example, the symbol for `netstandard1.4` is `NETSTANDARD1_4`).

You can disable generation of these symbols via the `DisableImplicitFrameworkDefines` property. For more information about this property, see [DisableImplicitFrameworkDefines](../core/project-sdk/msbuild-props.md#disableimplicitframeworkdefines).

The complete list of preprocessor symbols for .NET target frameworks is:

[!INCLUDE [Preprocessor symbols](../../includes/preprocessor-symbols.md)]

## Deprecated target frameworks

The following target frameworks are deprecated. Packages that target these target frameworks should migrate to the indicated replacements.

| Deprecated TFM                                                                             | Replacement |
| ------------------------------------------------------------------------------------------ | ----------- |
| aspnet50<br>aspnetcore50<br>dnxcore50<br>dnx<br>dnx45<br>dnx451<br>dnx452                  | netcoreapp  |
| dotnet<br>dotnet50<br>dotnet51<br>dotnet52<br>dotnet53<br>dotnet54<br>dotnet55<br>dotnet56 | netstandard |
| netcore50                                                                                  | uap10.0     |
| win                                                                                        | netcore45   |
| win8                                                                                       | netcore45   |
| win81                                                                                      | netcore451  |
| win10                                                                                      | uap10.0     |
| winrt                                                                                      | netcore45   |

## See also

- [Target framework names in .NET 5](https://github.com/dotnet/designs/blob/main/accepted/2020/net5/net5.md)
- [Call Windows Runtime APIs in desktop apps](/windows/apps/desktop/modernize/desktop-to-uwp-enhance)
- [Developing Libraries with Cross Platform Tools](../core/tutorials/libraries.md)
- [.NET Standard](net-standard.md)
- [.NET Core Versioning](../core/versions/index.md)
- [NuGet Tools GitHub Repository](https://github.com/joelverhagen/NuGetTools)
- [Framework Profiles in .NET](https://blog.stephencleary.com/2012/05/framework-profiles-in-net.html)
- [Platform compatibility analyzer](analyzers/platform-compat-analyzer.md)
