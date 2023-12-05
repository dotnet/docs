---
title: Migrate C++/CLI projects to .NET Core and .NET 5+
description: Learn about porting C++/CLI projects to .NET Core and .NET 5 and later versions.
author: mjrousos
ms.date: 10/27/2023
---

# How to port a C++/CLI project to .NET Core or .NET 5+

Beginning with .NET Core 3.1 and Visual Studio 2019, [C++/CLI projects](/cpp/dotnet/dotnet-programming-with-cpp-cli-visual-cpp) can target .NET Core. This support makes it possible to port Windows desktop applications with C++/CLI interop layers to .NET Core/.NET 5+. This article describes how to port C++/CLI projects from .NET Framework to .NET Core 3.1.

## C++/CLI .NET Core limitations

There are some important limitations to porting C++/CLI projects to .NET Core compared to other languages:

- C++/CLI support for .NET Core is Windows only.
- C++/CLI projects can't target .NET Standard, only .NET Core or .NET Framework.
- C++/CLI projects don't support the new SDK-style project file format. Instead, even when targeting .NET Core, C++/CLI projects use the existing *.vcxproj* file format.
- C++/CLI projects can't multitarget multiple .NET platforms. If you need to build a C++/CLI project for both .NET Framework and .NET Core, use separate project files.
- .NET Core doesn't support `-clr:pure` or `-clr:safe` compilation, only the new `-clr:netcore` option (which is equivalent to `-clr` for .NET Framework).

## Port a C++/CLI project

To port a C++/CLI project to .NET Core, make the following changes to the *.vcxproj* file. These migration steps differ from the steps needed for other project types because C++/CLI projects don't use SDK-style project files.

1. Replace `<CLRSupport>true</CLRSupport>` properties with `<CLRSupport>NetCore</CLRSupport>`. This property is often in configuration-specific property groups, so you might need to replace it in multiple places.
2. Replace `<TargetFrameworkVersion>` properties with `<TargetFramework>netcoreapp3.1</TargetFramework>`. Be sure to change the tag as well as the value.
3. Remove any .NET Framework references to `System`, `System.Data`, `System.Windows.Forms`, and `System.Xml`, like `<Reference Include="System" />`. .NET Core SDK assemblies are automatically referenced when using `<CLRSupport>NetCore</CLRSupport>`.
4. Update API usage in *.cpp* files, as necessary, to remove APIs unavailable to .NET Core. Because C++/CLI projects tend to be fairly thin interop layers, there are often not many changes needed. You can use the [.NET Portability Analyzer](../../standard/analyzers/portability-analyzer.md) to identify unsupported .NET APIs used by C++/CLI binaries just as with purely managed binaries.

### WPF and Windows Forms usage

.NET Core C++/CLI projects can use Windows Forms and WPF APIs. To use these Windows desktop APIs, you need to add explicit framework references to the UI libraries. SDK-style projects that use Windows desktop APIs reference the necessary framework libraries automatically by using the `Microsoft.NET.Sdk.WindowsDesktop` SDK. Because C++/CLI projects don't use the SDK-style project format, they need to add explicit framework references when targeting .NET Core.

To use Windows Forms APIs, add this reference to the *.vcxproj* file:

```xml
<!-- Reference all of Windows Forms -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WindowsForms" />
```

To use WPF APIs, add this reference to the *.vcxproj* file:

```xml
<!-- Reference all of WPF -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App.WPF" />
```

To use both Windows Forms and WPF APIs, add this reference to the *.vcxproj* file:

```xml
<!-- Reference the entirety of the Windows desktop framework:
     Windows Forms, WPF, and the types that provide integration between them -->
<FrameworkReference Include="Microsoft.WindowsDesktop.App" />
```

Currently, it's not possible to add these references by using Visual Studio's reference manager. Instead, update the project file by editing it manually. In Visual Studio, you need to unload the project first. You can also use another editor like Visual Studio Code.

## Build without MSBuild

It's also possible to build C++/CLI projects without using MSBuild. Follow these steps to build a C++/CLI project for .NET Core directly with *cl.exe* and *link.exe*:

1. When compiling, pass `-clr:netcore` to *cl.exe*.
2. Reference necessary .NET Core reference assemblies.
3. When linking, provide the .NET Core app host directory as a `LibPath`, so that *ijwhost.lib* can be found.
4. Copy *ijwhost.dll* from the .NET Core app host directory to the project's output directory.
5. Make sure a [runtimeconfig.json](https://github.com/dotnet/sdk/blob/main/documentation/specs/runtime-configuration-file.md) file exists for the first component of the application that will run managed code. For latest versions of Visual Studio, a *runtime.config* file is created and copied automatically.

   For older versions of Visual Studio, if the application has a native entry point, you need to manually create the following *runtimeconfig.json* file for the first C++/CLI library to use the .NET Core runtime. If a C++/CLI library is called from a managed entry point, the library doesn't need a *runtimeconfig.json* file, because the entry point assembly has one that's used when starting the runtime.

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

> [!NOTE]
> C++/CLI assemblies that target .NET 7 or a later version are always loaded into the default <xref:System.Runtime.Loader.AssemblyLoadContext>. However, in .NET 6 and earlier versions, C++/CLI assemblies might be loaded multiple times, each time into a new `AssemblyLoadContext`. If the first time that managed code in a C++/CLI assembly is executed:
>
> - Is from a native caller, the assembly is loaded into a separate `AssemblyLoadContext`.
> - Is from a managed caller, the assembly is loaded into the same `AssemblyLoadContext` as the caller, usually the default.
>
> To always load your C++/CLI assembly into the default `AssemblyLoadContext`, you can add an "initialize" style call from your entry-point assembly to your C++/CLI assembly. For more information, see this [dotnet/runtime issue](https://github.com/dotnet/runtime/issues/61105).
