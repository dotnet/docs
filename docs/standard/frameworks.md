---
title: Target frameworks in SDK-style projects - .NET
description: Learn about target frameworks for .NET apps and libraries.
ms.date: 11/23/2021
ms.prod: "dotnet"
ms.custom: "updateeachrelease"
ms.technology: dotnet-standard
---
# Target frameworks in SDK-style projects

When you target a framework in an app or library, you're specifying the set of APIs that you'd like to make available to the app or library. You specify the target framework in your project file using a target framework moniker (TFM).

An app or library can target a version of [.NET Standard](net-standard.md). .NET Standard versions represent standardized sets of APIs across all .NET implementations. For example, a library can target .NET Standard 1.6 and gain access to APIs that function across .NET Core and .NET Framework using the same codebase.

An app or library can also target a specific .NET implementation to gain access to implementation-specific APIs. For example, an app that targets Xamarin.iOS (for example, `Xamarin.iOS10`) has access to Xamarin-provided iOS API wrappers for iOS 10, or an app that targets Universal Windows Platform (UWP, `uap10.0`) has access to APIs that compile for devices that run Windows 10.

For some target frameworks, such as .NET Framework, the APIs are defined by the assemblies that the framework installs on a system and may include application framework APIs (for example, ASP.NET).

For package-based target frameworks (for example, .NET 5+, .NET Core, and .NET Standard), the APIs are defined by the NuGet packages included in the app or library.

## Latest versions

The following table defines the most common target frameworks, how they're referenced, and which version of [.NET Standard](net-standard.md) they implement. These target framework versions are the latest stable versions. Prerelease versions aren't shown. A target framework moniker (TFM) is a standardized token format for specifying the target framework of a .NET app or library.

| Target framework      | Latest <br/> stable version | Target framework moniker (TFM) | Implemented <br/> .NET Standard version |
| :-: | :-: | :-: | :-: |
| .NET 6                | 6                           | net6.0                         | N/A                                     |
| .NET 5                | 5                           | net5.0                         | N/A                                     |
| .NET Standard         | 2.1                         | netstandard2.1                 | N/A                                     |
| .NET Core             | 3.1                         | netcoreapp3.1                  | 2.1                                     |
| .NET Framework        | 4.8                         | net48                          | 2.0                                     |

## Supported target frameworks

A target framework is typically referenced by a TFM. The following table shows the target frameworks supported by the .NET SDK and the NuGet client. Equivalents are shown within brackets. For example, `win81` is an equivalent TFM to `netcore451`.

| Target Framework           | TFM |
| -------------------------- | --- |
| .NET 5+ (and .NET Core)    | netcoreapp1.0<br>netcoreapp1.1<br>netcoreapp2.0<br>netcoreapp2.1<br>netcoreapp2.2<br>netcoreapp3.0<br>netcoreapp3.1<br>net5.0*<br>net6.0* |
| .NET Standard              | netstandard1.0<br>netstandard1.1<br>netstandard1.2<br>netstandard1.3<br>netstandard1.4<br>netstandard1.5<br>netstandard1.6<br>netstandard2.0<br>netstandard2.1 |
| .NET Framework             | net11<br>net20<br>net35<br>net40<br>net403<br>net45<br>net451<br>net452<br>net46<br>net461<br>net462<br>net47<br>net471<br>net472<br>net48 |
| Windows Store              | netcore [netcore45]<br>netcore45 [win] [win8]<br>netcore451 [win81] |
| .NET Micro Framework       | netmf |
| Silverlight                | sl4<br>sl5 |
| Windows Phone              | wp [wp7]<br>wp7<br>wp75<br>wp8<br>wp81<br>wpa81 |
| Universal Windows Platform | uap [uap10.0]<br>uap10.0 [win10] [netcore50] |

\* .NET 5 and later TFMs include some operating system-specific variations. For more information, see the following section, [.NET 5+ OS-specific TFMs](#net-5-os-specific-tfms).

### .NET 5+ OS-specific TFMs

The `net5.0` and `net6.0` TFMs include technologies that work across different platforms. Specifying an *OS-specific TFM* makes APIs that are specific to an operating system available to your app, for example, Windows Forms or iOS bindings. OS-specific TFMs also inherit every API available to their base TFM, for example, the `net5.0` TFM.

.NET 5 introduced the `net5.0-windows` OS-specific TFM, which includes Windows-specific bindings for WinForms, WPF, and UWP APIs. .NET 6 introduces further OS-specific TFMs.

The following table shows the compatibility of the .NET 5+ TFMs.

| TFM                | Compatible with                                                                                                         |
|--------------------|-------------------------------------------------------------------------------------------------------------------------|
| net5.0             | net1..4 (with NU1701 warning)<br />netcoreapp1..3.1 (warning when WinForms or WPF is referenced)<br />netstandard1..2.1 |
| net5.0-windows     | netcoreapp1..3.1 (plus everything else inherited from `net5.0`)                                                         |
| net6.0             | (subsequent version of `net5.0`)                                                                                        |
| net6.0-android     | `xamarin.android` (+everything else inherited from `net6.0`)                                                            |
| net6.0-ios         | `xamarin.ios` (+everything else inherited from `net6.0`)                                                                |
| net6.0-macos       | `xamarin.mac` (+everything else inherited from `net6.0`)                                                                |
| net6.0-maccatalyst | `xamarin.ios` (+everything else inherited from `net6.0`)                                                                |
| net6.0-tvos        | `xamarin.tvos` (+everything else inherited from `net6.0`)                                                               |
| net6.0-windows     | (subsequent version of `net5.0-windows`)                                                                                |

To make your app portable across different platforms but still have access to OS-specific APIs, you can target multiple OS-specific TFMs and add platform guards around OS-specific API calls using `#if` preprocessor directives.

#### Suggested targets

Use these guidelines to determine which TFM to use in your app:

- Apps that are portable to multiple platforms should target a base TFM, for example, `net5.0`. This includes most libraries but also ASP.NET Core and Entity Framework.

- Platform-specific libraries should target platform-specific flavors. For example, WinForms and WPF projects should target `net5.0-windows` or `net6.0-windows`.

- Cross-platform application models (Xamarin Forms, ASP.NET Core) and bridge packs (Xamarin Essentials) should at least target the base TFM, for example, `net6.0`, but might also target additional platform-specific flavors to light-up more APIs or features.

#### OS version in TFMs

You can also specify an optional OS version at the end of an OS-specific TFM, for example, `net6.0-ios15.0`. The version indicates which APIs are available to your app or library. It does not control the OS version that your app or library supports at run time. It's used to select the reference assemblies that your project compiles against, and to select assets from NuGet packages. Think of this version as the "platform version" or "OS API version" to disambiguate it from the run-time OS version.

When an OS-specific TFM doesn't specify the platform version explicitly, it has an implied value that can be inferred from the base TFM and platform name. For example, the default platform value for iOS in .NET 6 is `15.0`, which means that `net6.0-ios` is shorthand for the canonical `net6.0-ios15.0` TFM. The implied platform version for a newer base TFM may be higher, for example, a future `net7.0-ios` TFM could map to `net7.0-ios16.0`. The shorthand form is intended for use in project files only, and is expanded to the canonical form by the .NET SDK's MSBuild targets before being passed to other tools, such as NuGet.

The .NET SDK is designed to be able to support newly released APIs for an individual platform without a new version of the base TFM. This enables you to access platform-specific functionality without waiting for a major release of .NET. You can gain access to these newly released APIs by incrementing the platform version in the TFM. For example, if the iOS platform added iOS 15.1 APIs in a .NET 6.0.x SDK update, you could access them by using the TFM `net6.0-ios15.1`.

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

Target frameworks are specified in a project file. When a single target framework is specified, use the [TargetFramework element](../core/project-sdk/msbuild-props.md#targetframework). The following console app project file demonstrates how to target .NET 5:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

</Project>
```

When you specify multiple target frameworks, you may conditionally reference assemblies for each target framework. In your code, you can conditionally compile against those assemblies by using preprocessor symbols with *if-then-else* logic.

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

The build system is aware of preprocessor symbols representing the target frameworks shown in the [Supported target framework versions](#supported-target-frameworks) table when you're using SDK-style projects. When using a symbol that represents a .NET Standard, .NET Core, or .NET 5 TFM, replace dots and hyphens with an underscore and change lowercase letters to uppercase (for example, the symbol for `netstandard1.4` is `NETSTANDARD1_4`).

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
- [dotnet/standard GitHub repository](https://github.com/dotnet/standard)
- [NuGet Tools GitHub Repository](https://github.com/joelverhagen/NuGetTools)
- [Framework Profiles in .NET](https://blog.stephencleary.com/2012/05/framework-profiles-in-net.html)
- [Platform compatibility analyzer](analyzers/platform-compat-analyzer.md)
