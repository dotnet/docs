---
title: Migrate C++/CLI projects to .NET
description: Learn about porting C++/CLI projects to .NET.
author: mjrousos
ms.date: 01/23/2024
ms.topic: upgrade-and-migration-article
---

# How to port a C++/CLI project to .NET

Beginning with Visual Studio 2019, [C++/CLI projects](/cpp/dotnet/dotnet-programming-with-cpp-cli-visual-cpp) can target .NET. This support makes it possible to port Windows desktop applications with C++/CLI interop layers from .NET Framework to .NET. This article describes how to port C++/CLI projects from .NET Framework to .NET.

## C++/CLI .NET Core limitations

There are some important limitations with C++/CLI projects and .NET compared to .NET Framework:

- Compiling a C++/CLI project to an executable isn't supported. You must compile to a DLL.
- C++/CLI support for .NET is Windows only.
- C++/CLI projects can't target .NET Standard.
- C++/CLI projects don't support the newer SDK-style project file format. Instead, C++/CLI projects use the same _.vcxproj_ file format that other Visual Studio C++ projects use.
- C++/CLI projects can't target multiple .NET platforms. If you need to build a C++/CLI project for both .NET and .NET Framework, use separate project files.
- .NET doesn't support `-clr:pure` or `-clr:safe` compilation, only the newer `-clr:netcore` option (which is equivalent to `-clr` for .NET Framework).

## Port a C++/CLI project

To port a C++/CLI project to .NET, make the following changes to the _.vcxproj_ file. These migration steps differ from the steps needed for other project types because C++/CLI projects don't use SDK-style project files.

01. Replace `<CLRSupport>true</CLRSupport>` properties with `<CLRSupport>NetCore</CLRSupport>`. This property is often in configuration-specific property groups, so you might need to replace it in multiple places.
01. Replace `<TargetFrameworkVersion>` properties with `<TargetFramework>net8.0</TargetFramework>`. Be sure to change the tag and value.
01. Remove any .NET Framework references to `System`, `System.Data`, `System.Windows.Forms`, and `System.Xml`, like `<Reference Include="System" />`. .NET SDK assemblies are automatically referenced when using `<CLRSupport>NetCore</CLRSupport>`.
01. Update API usage in _.cpp_ files, as necessary, to remove APIs unavailable to .NET. Because C++/CLI projects tend to be fairly thin interop layers, there are often not many changes needed. You can use the [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) to identify unsupported .NET APIs used by C++/CLI binaries.
01. If your project was an executable, perform the following steps:
    01. Change the project type to a library.
    01. Create a new .NET executable project.
    01. In the .NET executable project, add reference the C++/CLI .NET library.

### WPF and Windows Forms usage

.NET C++/CLI projects can use Windows Forms and WPF APIs. To use these Windows desktop APIs, you need to add explicit framework references to the UI libraries. SDK-style projects that use Windows desktop APIs reference the necessary framework libraries automatically by using the `Microsoft.NET.Sdk.WindowsDesktop` SDK. Because C++/CLI projects don't use the SDK-style project format, they need to add explicit framework references when targeting .NET Core.

To use Windows Forms APIs, add this reference to the _.vcxproj_ file:

```xml
<!-- Reference all of Windows Forms -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WindowsForms" />
```

To use WPF APIs, add this reference to the _.vcxproj_ file:

```xml
<!-- Reference all of WPF -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WPF" />
```

To use both Windows Forms and WPF APIs, add this reference to the _.vcxproj_ file:

```xml
<!-- Reference the entirety of the Windows desktop framework:
     Windows Forms, WPF, and the types that provide integration between them -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App" />
```

Currently, it's not possible to add these references by using Visual Studio's reference manager. Instead, update the project file by editing it manually. In Visual Studio, you need to unload the project first. You can also use another editor like Visual Studio Code.

## Build without MSBuild

It's also possible to build C++/CLI projects without using MSBuild. Follow these steps to build a C++/CLI project for .NET Core directly with _cl.exe_ and _link.exe_:

01. When compiling, pass `-clr:netcore` to _cl.exe_.
01. Reference necessary .NET reference assemblies.
01. When linking, provide the .NET app host directory as a `LibPath`, so that _ijwhost.lib_ can be found.
01. Copy _ijwhost.dll_ from the .NET app host directory to the project's output directory.
01. Make sure a [_runtimeconfig.json_](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md) file exists for the first component of the application that runs managed code. For latest versions of Visual Studio, a _runtime.config_ file is created and copied automatically.

    For older versions of Visual Studio, if the application has a native entry point, you need to manually create the following _runtimeconfig.json_ file for the first C++/CLI library to use the .NET runtime. If a C++/CLI library is called from a managed entry point, the library doesn't need a _runtimeconfig.json_ file, because the entry point assembly has one that is used when starting the runtime.

    ```json
    {
       "runtimeOptions": {
          "tfm": "net8.0",
          "framework": {
          "name": "Microsoft.NETCore.App",
          "version": "8.0.0"
          }
       }
    }
    ```

> [!NOTE]
> C++/CLI assemblies that target .NET 7 or a later version are always loaded into the default <xref:System.Runtime.Loader.AssemblyLoadContext>. However, in .NET 6 and earlier versions, C++/CLI assemblies might be loaded multiple times, each time into a new `AssemblyLoadContext`. If the first time that managed code in a C++/CLI assembly is executed:
>
> - Is from a native caller, the assembly is loaded into a separate `AssemblyLoadContext`.
> - Is from a managed caller, the assembly is loaded into the same `AssemblyLoadContext` as the caller, usually the default.
>
> To always load your C++/CLI assembly into the default `AssemblyLoadContext`, you can add an "initialize" style call from your entry-point assembly to your C++/CLI assembly. For more information, see this [dotnet/runtime issue](https://github.com/dotnet/runtime/issues/61105).
