---
title: Tools for porting to .NET Core
description: Learn about porting C++/CLI projects to .NET Core
author: mjrousos
ms.author: 
ms.date: 12/12/2019
---

# How to port a C++/CLI project to .NET Core

Beginning with .NET Core 3.1 and Visual Studio 2019 16.4, C++/CLI projects can be updated to target .NET Core. This allows Windows desktop applications which may use C++/CLI projects as an interop layer between managed and native code to be ported to .NET Core. This article describes how to port C++/CLI projects from .NET Framework to .NET Core 3.1.

## C++/CLI .NET Core limitations

There are some important limitations to porting C++/CLI projects to .NET Core compared to C# or VB projects:

* C++/CLI support for .NET Core is Windows only.
* C++/CLI projects cannot target .NET Standard, only .NET Core (or, of course, .NET Framework).
* C++/CLI projects do not support the new SDK-style project file format. Instead, even when targeting .NET Core, C++/CLI projects use the existing vcxproj file format.
  * Because of this, C++/CLI projects cannot multitarget multiple .NET platforms. If you need to build a C++/CLI project for both .NET Framework and .NET Core, use separate project files.
* .NET Core does not support /clr:pure or /clr:safe compilation, only the new /clr:netcore option (which is equivalent to /clr for .NET Framework).

## C++/CLI porting process

To port a C++/CLI project to .NET Core, make the following changes to the vcxproj project file:

1. Replace `<CLRSupport>true</CLRSupport>` properties with `<CLRSupport>NetCore</CLRSupport>`.
    1. Be aware that this property is often in configuration- and platform-specific property groups, so it may need to be replaced in multiple places.
2. Replace `<TargetFrameworkVersion>` properties with `<TargetFramework>netcoreapp3.1</TargetFramework>`.
3. Remove any .NET Framework references (like `<Reference Include="System" />`). .NET Core SDK assemblies are automatically referenced when using `<CLRSupport>NetCore</CLRSupport>`.
4. Update API usage in cpp files, as necessary, to remove APIs unavailable to .NET Core. Because C++/CLI projects tend to be fairly thin interop layers, there are often not many API changes needed.
    1. The [.NET Portability Analyzer](https://docs.microsoft.com/dotnet/standard/analyzers/portability-analyzer) can be used to identify unsupported .NET APIs used by C++/CLI binaries just as with purely managed binaries. Guidelines for determining code portability and updating projects to work with .NET Core APIs are available in the [library porting guidance](./libraries.md#determining-the-portability-of-your-code).

### WPF and Windows Forms usage

C++/CLI projects that use Windows Forms or WPF APIs can be ported to .NET Core, but need explicit framework references to the UI libraries. SDK-style projects that use Windows desktop APIs reference the necessary framework libraries automatically by using the `Microsoft.NET.Sdk.WindowsDesktop` SDK. Because C++/CLI projects don't use the SDK-style project format, they need to add explicit framework references when targeting .NET Core.

To use Windows Forms APIs, add this reference to the vcxproj:

```xml
<!-- Reference all of Windows Forms -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WindowsForms" />
```

To use WPF APIs, add this reference to the vcxproj:

```xml
<!-- Reference all of WPF -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WPF" />
```

To use both Windows Forms and WPF APIs, add this reference to the vcxproj:

```xml
<!-- Reference the entirety of the Windows desktop framework:
     Windows Forms, WPF, and the types that provide integration between them -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App" />
```

Currently, it is not possible to add these references using Visual Studio's reference manager. The project file needs to be updated manually.

## Building without MSBuild

The MSBuild project system makes it easy to port a vcxproj-based project to .NET Core. If you need to build a C++/CLI project for .NET Core directly with cl.exe and link.exe, it can be done with a few additional steps.

1. When compiling, pass `/clr:netcore` to cl.exe.
2. Reference necessary .NET Core reference assemblies.
3. When linking, provide the .NET Core app host directory as a LibPath (so that ijwhost.lib can be found).
4. Copy ijwhost.dll (from the .NET Core app host directory) to the project's output directory.
5. Make sure a [.runtimeconfig.json](https://github.com/dotnet/cli/blob/master/Documentation/specs/runtime-configuration-file.md) file exists for the first component of the application that will run managed code. If the application has a managed entry point, this will be created and copied automatically. If the application has a native entry point, though, and a C++/CLI library will be the first time the process uses the .NET Core runtime, you will need to create a runtimeconfig.json file for the library.

## Known issues

There are a couple known issues to look out for when working with C++/CLI projects targeting .NET Core.

1. If the application has a native entry point, the C++/CLI library that first executes managed code needs a [.runtimeconfig.json](https://github.com/dotnet/cli/blob/master/Documentation/specs/runtime-configuration-file.md) file to be used when the .NET Core runtime is started. C++/CLI projects don't create .runtimeconfig.json files automatically at build time yet, so the file must be generated manually. If a C++/CLI library is called from a managed entry point (which will have its own .runtimeconfig.json file), then the C++/CLI library doesn't need a .runtimeconfig.json file of its own. A simple sample .runtimeconfig.json file looks like this (see the [spec on GitHub](https://github.com/dotnet/cli/blob/master/Documentation/specs/runtime-configuration-file.md) for more details):
    ```json
    {
          "runtimeOptions": {
             "tfm": "netcoreapp3.1",
             "framework": {
                "name": "Microsoft.NETCore.App",
                "version": "3.1.0"
             }
          }
    }
    ```
2. A WPF framework reference in C++/CLI projects currently causes some extraneous warnings about being unable to import symbols. These can be safely ignored and should be fixed soon.
