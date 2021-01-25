---
title: Target frameworks in SDK-style projects - .NET
description: Learn about target frameworks for .NET apps and libraries.
ms.date: 11/06/2020
ms.prod: "dotnet"
ms.custom: "updateeachrelease"
ms.technology: dotnet-standard
---
# Target frameworks in SDK-style projects

When you target a framework in an app or library, you're specifying the set of APIs that you'd like to make available to the app or library. You specify the target framework in your project file using a target framework moniker (TFM).

An app or library can target a version of [.NET Standard](net-standard.md). .NET Standard versions represent standardized sets of APIs across all .NET implementations. For example, a library can target .NET Standard 1.6 and gain access to APIs that function across .NET Core and .NET Framework using the same codebase.

An app or library can also target a specific .NET implementation to gain access to implementation-specific APIs. For example, an app that targets Xamarin.iOS (for example, `Xamarin.iOS10`) has access to Xamarin-provided iOS API wrappers for iOS 10, or an app that targets Universal Windows Platform (UWP, `uap10.0`) has access to APIs that compile for devices that run Windows 10.

For some target frameworks, such as .NET Framework, the APIs are defined by the assemblies that the framework installs on a system and may include application framework APIs (for example, ASP.NET).

For package-based target frameworks (for example, .NET 5, .NET Core, and .NET Standard), the APIs are defined by the NuGet packages included in the app or library.

## Latest versions

The following table defines the most common target frameworks, how they're referenced, and which version of [.NET Standard](net-standard.md) they implement. These target framework versions are the latest stable versions. Pre-release versions aren't shown. A target framework moniker (TFM) is a standardized token format for specifying the target framework of a .NET app or library.

| Target framework      | Latest <br/> stable version | Target framework moniker (TFM) | Implemented <br/> .NET Standard version |
| :-: | :-: | :-: | :-: |
| .NET 5                | 5.0                         | net5.0                         | N/A                                     |
| .NET Standard         | 2.1                         | netstandard2.1                 | N/A                                     |
| .NET Core             | 3.1                         | netcoreapp3.1                  | 2.1                                     |
| .NET Framework        | 4.8                         | net48                          | 2.0                                     |

## Supported target frameworks

A target framework is typically referenced by a TFM. The following table shows the target frameworks supported by the .NET SDK and the NuGet client. Equivalents are shown within brackets. For example, `win81` is an equivalent TFM to `netcore451`.

| Target Framework           | TFM |
| -------------------------- | --- |
| .NET 5 (and .NET Core)     | netcoreapp1.0<br>netcoreapp1.1<br>netcoreapp2.0<br>netcoreapp2.1<br>netcoreapp2.2<br>netcoreapp3.0<br>netcoreapp3.1<br>net5.0* |
| .NET Standard              | netstandard1.0<br>netstandard1.1<br>netstandard1.2<br>netstandard1.3<br>netstandard1.4<br>netstandard1.5<br>netstandard1.6<br>netstandard2.0<br>netstandard2.1 |
| .NET Framework             | net11<br>net20<br>net35<br>net40<br>net403<br>net45<br>net451<br>net452<br>net46<br>net461<br>net462<br>net47<br>net471<br>net472<br>net48 |
| Windows Store              | netcore [netcore45]<br>netcore45 [win] [win8]<br>netcore451 [win81] |
| .NET Micro Framework       | netmf |
| Silverlight                | sl4<br>sl5 |
| Windows Phone              | wp [wp7]<br>wp7<br>wp75<br>wp8<br>wp81<br>wpa81 |
| Universal Windows Platform | uap [uap10.0]<br>uap10.0 [win10] [netcore50] |

\* .NET 5.0 and later TFMs include operating system-specific variations. For more information, see the following section, [.NET 5 OS-specific TFMs](#net-5-os-specific-tfms).

### .NET 5 OS-specific TFMs

For each .NET 5.0 and later TFM, for example, `net5.0`, there are TFM variations that include OS-specific bindings. These variations are shown in the following table.

| OS-specific format | Example        |
|--------------------|----------------|
| \<base-tfm>-android | net5.0-android |
| \<base-tfm>-ios     | net5.0-ios     |
| \<base-tfm>-macos   | net5.0-macos   |
| \<base-tfm>-tvos    | net5.0-tvos    |
| \<base-tfm>-watchos | net5.0-watchos |
| \<base-tfm>-windows | net5.0-windows |

The `net5.0` TFM only includes technologies that work cross-platform. Specifying an OS-specific TFM makes APIs that are specific to an operating system available to your app, for example, Windows Forms or iOS bindings. OS-specific TFMs also inherit every API available to the `net5.0` TFM.

To make your app portable across different platforms, you can target multiple OS-specific TFMs and add platform guards around OS-specific API calls using `#if` preprocessor directives.

The following table shows the compatibility of the .NET 5 TFMs with TFMs for previous .NET versions.

| TFM             | Compatible with                                            | Notes |
|-----------------|------------------------------------------------------------|-|
| net5.0          | net1..4 (with NU1701 warning)<br />netcoreapp1..3.1 (warning when WinForms or WPF is referenced)<br />netstandard1..2.1 | |
| net5.0-android  | xamarin.android (plus everything else inherited from `net5.0`) | |
| net5.0-ios      | xamarin.ios (plus everything else inherited from `net5.0`) | |
| net5.0-macos    | xamarin.mac (plus everything else inherited from `net5.0`) | |
| net5.0-tvos     | xamarin.tvos (plus everything else inherited from `net5.0`) | |
| net5.0-watchos  | xamarin.watchos (plus everything else inherited from `net5.0`) | |
| net5.0-windows  | netcoreapp1..3.1 (plus everything else inherited from `net5.0`) | Includes WinForms, WPF, and UWP APIs.<br />For information, see [Call Windows Runtime APIs in desktop apps](/windows/apps/desktop/modernize/desktop-to-uwp-enhance). |

#### Suggested targets

Use these guidelines to determine which TFM to use in your app:

- Apps that are portable to multiple platforms should target `net5.0`. This includes most libraries but also ASP.NET Core and Entity Framework.

- Platform-specific libraries should target platform-specific flavors. For example, WinForms and WPF projects should target `net5.0-windows`.

- Cross-platform application models (Xamarin Forms, ASP.NET Core) and bridge packs (Xamarin Essentials) should at least target `net5.0`, but might also target additional platform-specific flavors to light-up more APIs or features.

#### OS version in TFMs

You can also specify an optional OS version at the end of the TFM, for example, `net5.0-ios13.0`, which indicates what APIs are available to your app. (The .NET 5 SDK will be updated to include support for newer OS versions as they are released.) To gain access to newly released APIs, increment the OS version in the TFM. You can still make your app compatible with earlier OS versions (and add guards around calls to later-version APIs) by adding the `SupportedOSPlatformVersion` element to your project file. The `SupportedOSPlatformVersion` element indicates the minimum OS version required to run your app.

For example, the following project file excerpt specifies that iOS 14 APIs are available to the app, but it can run on iOS 13 or later machines.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net5.0-ios14.0</TargetFramework>
    <SupportedOSPlatformVersion>13.0</SupportedOSPlatformVersion> (minimum os platform version)
  </PropertyGroup>

  ...

</Project>
```

## How to specify a target framework

Target frameworks are specified in a project file. When a single target framework is specified, use the [TargetFramework element](../core/project-sdk/msbuild-props.md#targetframework). The following console app project file demonstrates how to target .NET 5.0:

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

Within your library or app, you write conditional code using [preprocessor directives](../csharp/language-reference/preprocessor-directives/preprocessor-if.md) to compile for each target framework:

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

- [Target framework names in .NET 5](https://github.com/dotnet/designs/blob/master/accepted/2020/net5/net5.md)
- [Developing Libraries with Cross Platform Tools](../core/tutorials/libraries.md)
- [.NET Standard](net-standard.md)
- [.NET Core Versioning](../core/versions/index.md)
- [dotnet/standard GitHub repository](https://github.com/dotnet/standard)
- [NuGet Tools GitHub Repository](https://github.com/joelverhagen/NuGetTools)
- [Framework Profiles in .NET](https://blog.stephencleary.com/2012/05/framework-profiles-in-net.html)
- [Platform compatibility analyzer](analyzers/platform-compat-analyzer.md)
