---
title: "Exposing .NET Core components to COM"
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
  [!code-csharp[The IServer interface](~/samples/core/extensions/COMServerDemo/COMContract/IServer.cs)]
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

## Sample

There is a fully functional [COM server sample](https://github.com/dotnet/samples/tree/master/core/extensions/COMServerDemo) in the dotnet/samples repository on GitHub.

## Additional notes

Unlike in .NET Framework, there is no support in .NET Core for generating a COM Type Library (TLB) from a .NET Core assembly. You will either have to manually write an IDL file or a C++ header for the native declarations of your interfaces.

Additionally, loading both .NET Framework and .NET Core into the same process is unsupported, and as a result loading a .NET Core COM server into a .NET Framework COM client process or vice versa is not supported.
