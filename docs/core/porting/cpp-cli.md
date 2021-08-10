---
title: Migrating C++/CLI projects to .NET Core
description: Learn about porting C++/CLI projects to .NET Core.
author: mjrousos
ms.date: 01/10/2020
---

# How to port a C++/CLI project to .NET Core

Beginning with .NET Core 3.1 and Visual Studio 2019 version 16.4, [C++/CLI projects](/cpp/dotnet/dotnet-programming-with-cpp-cli-visual-cpp) can target .NET Core. This support makes it possible to port Windows desktop applications with C++/CLI interop layers to .NET Core. This article describes how to port C++/CLI projects from .NET Framework to .NET Core 3.1.

## C++/CLI .NET Core limitations

There are some important limitations to porting C++/CLI projects to .NET Core compared to other languages:

* C++/CLI support for .NET Core is Windows only.
* C++/CLI projects can't target .NET Standard, only .NET Core (or .NET Framework).
* C++/CLI projects don't support the new SDK-style project file format. Instead, even when targeting .NET Core, C++/CLI projects use the existing vcxproj file format.
* C++/CLI projects can't multitarget multiple .NET platforms. If you need to build a C++/CLI project for both .NET Framework and .NET Core, use separate project files.
* .NET Core doesn't support `-clr:pure` or `-clr:safe` compilation, only the new `-clr:netcore` option (which is equivalent to `-clr` for .NET Framework).

## Port a C++/CLI project

To port a C++/CLI project to .NET Core, make the following changes to the vcxproj file. These migration steps differ from the steps needed for other project types because C++/CLI projects don't use SDK-style project files.

1. Replace `<CLRSupport>true</CLRSupport>` properties with `<CLRSupport>NetCore</CLRSupport>`. This property is often in configuration-specific property groups, so you may need to replace it in multiple places.
2. Replace `<TargetFrameworkVersion>` properties with `<TargetFramework>netcoreapp3.1</TargetFramework>`.
3. Remove any .NET Framework references (like `<Reference Include="System" />`). .NET Core SDK assemblies are automatically referenced when using `<CLRSupport>NetCore</CLRSupport>`.
4. Update API usage in cpp files, as necessary, to remove APIs unavailable to .NET Core. Because C++/CLI projects tend to be fairly thin interop layers, there are often not many changes needed. The [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) can be used to identify unsupported .NET APIs used by C++/CLI binaries just as with purely managed binaries.

### WPF and Windows Forms usage

.NET Core C++/CLI projects can use Windows Forms and WPF APIs. To use these Windows desktop APIs, you need to add explicit framework references to the UI libraries. SDK-style projects that use Windows desktop APIs reference the necessary framework libraries automatically by using the `Microsoft.NET.Sdk.WindowsDesktop` SDK. Because C++/CLI projects don't use the SDK-style project format, they need to add explicit framework references when targeting .NET Core.

To use Windows Forms APIs, add this reference to the vcxproj file:

```xml
<!-- Reference all of Windows Forms -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WindowsForms" />
```

To use WPF APIs, add this reference to the vcxproj file:

```xml
<!-- Reference all of WPF -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WPF" />
```

To use both Windows Forms and WPF APIs, add this reference to the vcxproj file:

```xml
<!-- Reference the entirety of the Windows desktop framework:
     Windows Forms, WPF, and the types that provide integration between them -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App" />
```

Currently, it's not possible to add these references using Visual Studio's reference manager. Instead, update the project file manually. This update can be done in Visual Studio by unloading the project and then editing the project file. You can also use another editor like VS Code.

## Build without MSBuild

It's also possible to build C++/CLI projects without using MSBuild. Follow these steps to build a C++/CLI project for .NET Core directly with *cl.exe* and *link.exe*:

1. When compiling, pass `-clr:netcore` to *cl.exe*.
2. Reference necessary .NET Core reference assemblies.
3. When linking, provide the .NET Core app host directory as a `LibPath` (so that *ijwhost.lib* can be found).
4. Copy *ijwhost.dll* (from the .NET Core app host directory) to the project's output directory.
5. Make sure a [runtimeconfig.json](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md) file exists for the first component of the application that will run managed code. If the application has a managed entry point, a `runtime.config` file will be created and copied automatically. If the application has a native entry point, though, you need to create a `runtimeconfig.json` file for the first C++/CLI library to use the .NET Core runtime.

## Known issues

There are a few known issues to look out for when working with C++/CLI projects targeting .NET Core.

* A WPF framework reference in .NET Core C++/CLI projects currently causes some extraneous warnings about being unable to import symbols. These warnings can be safely ignored and should be fixed soon.
* If the application has a native entry point, the C++/CLI library that first executes managed code needs a [runtimeconfig.json](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md) file. This config file is used when the .NET Core runtime starts. C++/CLI projects don't create `runtimeconfig.json` files automatically at build time yet, so the file must be generated manually. If a C++/CLI library is called from a managed entry point, then the C++/CLI library doesn't need a `runtimeconfig.json` file (since the entry point assembly will have one that is used when starting the runtime). A simple sample `runtimeconfig.json` file is shown below. For more information, see the [spec on GitHub](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md).

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

* On Windows 7, loading a .NET Core C++/CLI assembly when the entry application is native may exhibit failing behavior. This failing behavior is due to the Windows 7 loader not respecting non-`mscoree.dll` entry points for C++/CLI assemblies. The recommended course of action is to convert the entry application to managed code. Scenarios involving Thread Local Storage (TLS) are specifically unsupported in all cases on Windows 7.
