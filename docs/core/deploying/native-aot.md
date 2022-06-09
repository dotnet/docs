---
title: NativeAOT deployment overview
description: Learn what NativeAOT deployments are and why you should consider using it as part of the publishing your app with .NET 7 and later.
author: lakshanf
ms.author: lakshanf
ms.date: 06/09/2022
---
# NativeAOT Deployment

.NET NativeAOT deployment model uses an optimized ahead-of-time (AOT) compiler that generates an application that contains native executable code. NativeAOT applications do not use the just-in-time (JIT) compiler when the application runs. There are performance benefits (startup time, working set improvements etc.) and the ability to run .NET applications in restricted environment where a JIT is not allowed with using NativeAOT applications. NativeAOT applications have to be [self-contained applications](index.md#publish-self-contained) that targets a specific runtime environment (RID) such as Linux x64 or Windows x64.

There are some limitations in .NET NativeAOT deployment model, the main one being, that no runtime code generation is possible. See [Impact of using the NativeAOT deployment](#impact-of-using-the-nativeaot-deployment) for additional details. The support in .NET 7 release is targeted towards console type applications. 

> [!WARNING]
> NativeAOT deployment is an experimental feature in .NET 7.

There are two ways to publish your app as NativeAOT:

01. Specify the PublishAot flag directly to the dotnet publish command. See [dotnet publish](../tools/dotnet-publish.md) for details.

    ```dotnetcli
    dotnet publish -c Release -r win-x64 -p:PublishAot=true
    ```

02. Specify the property in the project.

    - Add the `<PublishAot>` setting to your project.

    ```xml
    <PropertyGroup>
      <PublishAot>true</PublishAot>
    </PropertyGroup>
    ```

    - Publish the application without any special parameters.

    ```dotnetcli
    dotnet publish -c Release -r win-x64
    ```

The app should be available in the publish directory and will contain all the code needed to run in it including the coreclr runtime.

## Impact of using the NativeAOT deployment

NativeAOT applications are [self-contained application](index.md#publish-self-contained) and do not use any shared libraries as is the case with default [framework-dependent deployment model](index.md#publish-framework-dependent). NativeAot deployment model should be considered when the benefits to deployment and the ability to optimize a single app outweigh the benefits of sharing for certain types of workloads. The gain is most significant for workloads with a high number of deployed instances: cloud infrastructure, hyper-scale services, popular apps or games.

NativeAOT applications comes with a few fundamental limitations and compatibility issues. The key limitations include:
 - No dynamic loading (e.g. Assembly.LoadFile)
 - No runtime code generation (e.g. System.Reflection.Emit)
 - No C++/CLI, no built-in COM and WinRT interop support
 - No unconstrained reflection

The first release of NativeAOT in .NET 7 is experimental and has additional limitations. These include:
 - Should be targeted for console type applications
 - Not all the runtime libraries are fully annotated to be NativeAOT compatible (i.e., some warnings in the runtime libraries are not actionable by end developers)
 - No full diagnostic support (debugging and profiling)

## Platform/architecture restrictions

Supported compilation targets are described in the table below when targeting .NET 7.

| Platform | Supported architecture |
| ------------ | --------------------------- |
| Windows  | X64, ARM64 |
| Linux    | X64, ARM64 |
