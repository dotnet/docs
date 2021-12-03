---
title: "Exposing .NET Core components to COM"
description: "This tutorial shows you how to expose a class to COM from .NET Core. You generate a COM server and a side-by-side server manifest for Registry-Free COM."
ms.date: "07/12/2019"
helpviewer_keywords:
  - "exposing .NET Core components to COM"
  - "interoperation with unmanaged code, exposing .NET Core components"
  - "COM interop, exposing COM components"
ms.assetid: 21271167-fe7f-46ba-a81f-a6812ea649d4
author: "jkoritzinsky"
ms.author: "jekoritz"
---

# Exposing .NET Core components to COM

In .NET Core, the process for exposing your .NET objects to COM has been significantly streamlined in comparison to .NET Framework. The following process will walk you through how to expose a class to COM. This tutorial shows you how to:

- Expose a class to COM from .NET Core.
- Generate a COM server as part of building your .NET Core library.
- Automatically generate a side-by-side server manifest for Registry-Free COM.

## Prerequisites

- Install [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download) or a newer version.

## Create the library

The first step is to create the library.

1. Create a new folder, and in that folder run the following command:

    ```dotnetcli
    dotnet new classlib
    ```

2. Open `Class1.cs`.
3. Add `using System.Runtime.InteropServices;` to the top of the file.
4. Create an interface named `IServer`. For example:

   ```csharp
   using System;
   using System.Runtime.InteropServices;

   [ComVisible(true)]
   [Guid(ContractGuids.ServerInterface)]
   [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
   public interface IServer
   {
       /// <summary>
       /// Compute the value of the constant Pi.
       /// </summary>
       double ComputePi();
   }
   ```

5. Add the `[Guid("<IID>")]` attribute to the interface, with the interface GUID for the COM interface you're implementing. For example, `[Guid("fe103d6e-e71b-414c-80bf-982f18f6c1c7")]`. Note that this GUID needs to be unique since it is the only identifier of this interface for COM. In Visual Studio, you can generate a GUID by going to Tools > Create GUID to open the Create GUID tool.
6. Add the `[InterfaceType]` attribute to the interface and specify what base COM interfaces your interface should implement.
7. Create a class named `Server` that implements `IServer`.
8. Add the `[Guid("<CLSID>")]` attribute to the class, with the class identifier GUID for the COM class you're implementing. For example, `[Guid("9f35b6f5-2c05-4e7f-93aa-ee087f6e7ab6")]`. As with the interface GUID, this GUID must be unique since it is the only identifier of this interface to COM.
9. Add the `[ComVisible(true)]` attribute to both the interface and the class.

> [!IMPORTANT]
> Unlike in .NET Framework, .NET Core requires you to specify the CLSID of any class you want to be activatable via COM.

## Generate the COM host

1. Open the `.csproj` project file and add `<EnableComHosting>true</EnableComHosting>` inside a `<PropertyGroup></PropertyGroup>` tag.
2. Build the project.

The resulting output will have a `ProjectName.dll`, `ProjectName.deps.json`, `ProjectName.runtimeconfig.json` and `ProjectName.comhost.dll` file.

## Register the COM host for COM

Open an elevated command prompt and run `regsvr32 ProjectName.comhost.dll`. That will register all of your exposed .NET objects with COM.

## Enabling RegFree COM

1. Open the `.csproj` project file and add `<EnableRegFreeCom>true</EnableRegFreeCom>` inside a `<PropertyGroup></PropertyGroup>` tag.
2. Build the project.

The resulting output will now also have a `ProjectName.X.manifest` file. This file is the side-by-side manifest for use with Registry-Free COM.

## Embedding type libraries in the COM host

Unlike in .NET Framework, there is no support in .NET Core or .NET 5+ for generating a [COM Type Library (TLB)](/windows/win32/midl/com-dcom-and-type-libraries#type-library) from a .NET assembly. The guidance is to either manually write an IDL file or a C/C++ header for the native declarations of the COM interfaces. If you decide to write an IDL file, you can compile it with the Visual C++ SDK's MIDL compiler to produce a TLB.

In .NET 6 and later versions, the .NET SDK supports embedding already-compiled TLBs into the COM host as part of your project build.

To embed a type library into your application, follow these steps:

1. Open the `.csproj` project file and add `<ComHostTypeLibrary Include="path/to/typelib.tlb" Id="<id>" />` inside an `<ItemGroup></ItemGroup>` tag.
2. Replace `<id>` with a positive integer value. The value must be unique among the TLBs you specify to be embedded in the COM host.
   - The `Id` attribute is optional if you only add one `ComHostTypeLibrary` to your project.

For example, the following code block adds the `Server.tlb` type library at index `1` to the COM host:

```xml
<ItemGroup>
    <ComHostTypeLibrary Include="Server.tlb" Id="1" />
</ItemGroup>
```

## Sample

There is a fully functional [COM server sample](https://github.com/dotnet/samples/tree/main/core/extensions/COMServerDemo) in the dotnet/samples repository on GitHub.

## Additional notes

> [!IMPORTANT]
> In .NET Framework, an "Any CPU" assembly can be consumed by both 32-bit and 64-bit clients. By default, in .NET Core, .NET 5, and later versions, "Any CPU" assemblies are accompanied by a 64-bit *\*.comhost.dll*. Because of this, they can only be consumed by 64-bit clients. That is the default because that is what the SDK represents. This behavior is identical to how the "self-contained" feature is published: by default it uses what the SDK provides. The `NETCoreSdkRuntimeIdentifier` MSBuild property determines the bitness of *\*.comhost.dll*. The managed part is actually bitness agnostic as expected, but the accompanying native asset defaults to the targeted SDK.

During activation, the assembly containing the COM component is loaded in a separate <xref:System.Runtime.Loader.AssemblyLoadContext> based on the assembly path. If there is one assembly providing multiple COM servers, the `AssemblyLoadContext` is reused such that all of the servers from that assembly reside in the same load context. If there are multiple assemblies providing COM servers, a new `AssemblyLoadContext` is created for each assembly, and each server resides in the load context that corresponds to its assembly.

[Self-contained deployments](../deploying/index.md#publish-self-contained) of COM components are not supported. Only [framework-dependent deployments](../deploying/index.md#publish-framework-dependent) of COM components are supported.

Additionally, loading both .NET Framework and .NET Core into the same process does have diagnostic limitations. The primary limitation is the debugging of managed components as it is not possible to debug both .NET Framework and .NET Core at the same time. In addition, the two runtime instances don't share managed assemblies. This means that it isn't possible to share actual .NET types across the two runtimes and instead all interactions must be restricted to the exposed COM interface contracts.
