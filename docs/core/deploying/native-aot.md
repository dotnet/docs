---
title: NativeAOT deployment overview
description: Learn what NativeAOT deployments are and why you should consider using it as part of the publishing your app with .NET 7 and later.
author: lakshanf
ms.author: lakshanf
ms.date: 06/09/2022
---
# NativeAOT Deployment

The .NET NativeAOT deployment model uses an optimized ahead-of-time (AOT) compiler that generates an application that contains native executable code. NativeAOT apps don't use the just-in-time (JIT) compiler when the application runs. Native AOT provides performance benefits (for example, startup time and working set improvements) and the ability to run .NET applications in restricted environments where a JIT is not allowed. NativeAOT applications are [self-contained applications](index.md#publish-self-contained) that target a specific runtime environment (RID), such as Linux x64 or Windows x64.

There are some limitations in the .NET NativeAOT deployment model, with the main one being that no run-time code generation is possible. For more information, see [Impact of using the NativeAOT deployment](#impact-of-using-the-nativeaot-deployment). The support in the .NET 7 release is targeted towards console-type applications.

> [!WARNING]
> NativeAOT deployment is an experimental feature in .NET 7.

## Publish NativeAOT - CLI

Publish a NativeAOT application using the [dotnet publish](../tools/dotnet-publish.md) command.

01. Add `<PublishAot>true</PublishAot>` to your project file.

    This will produce a NativeAOT app and shows PublishAot compatibility warnings during build.

    ```xml
    <PropertyGroup>
        <PublishAot>true</PublishAot>
    </PropertyGroup>
    ```

01. Publish the app as for a specific runtime identifier using `dotnet publish -r <RID>`

    The following example publishes the app for Windows as a NativeAOT application.

    `dotnet publish -r win-x64 -c Release`

    The following example publishes the app for Linux as a NativeAOT application.

    `dotnet publish -r linux-arm64 -c Release`

The app will be available in the publish directory and will contain all the code needed to run in it, including the coreclr runtime.

NativeAOT libraries that can be consumed by other programming languages can be published using the `NativeLib=Static` property for static libraries that can be linked at compile time. Shared libraries that are required at runtime can be created at publish time by using the `NativeLib=Shared` property.

## Impact of using the NativeAOT deployment

NativeAOT applications are [self-contained](index.md#publish-self-contained) and don't use any shared libraries, as is the case with the default [framework-dependent deployment model](index.md#publish-framework-dependent). Consider the NativeAOT deployment model when the benefits to deployment and the ability to optimize a single app outweigh the benefits of sharing for certain types of workloads. The gain is most significant for workloads with a high number of deployed instances: cloud infrastructure, hyper-scale services, popular apps, or games.

NativeAOT applications comes with a few fundamental limitations and compatibility issues. The key limitations include:

- No dynamic loading (for example, `Assembly.LoadFile`)
- No runtime code generation (for example, `System.Reflection.Emit`)
- No C++/CLI
- No built-in COM
- Requires trimming, which has [limitations](trimming/incompatibilities.md)

The first release of NativeAOT in .NET 7 is experimental and has additional limitations. These include:

- Should be targeted for console type applications.
- Not all the runtime libraries are fully annotated to be NativeAOT compatible (that is, some warnings in the runtime libraries are not actionable by end developers).
- Limited diagnostic support (debugging and profiling).

## Platform/architecture restrictions

The following table shows supported compilation targets when targeting .NET 7.

| Platform | Supported architecture |
| ------------ | --------------------------- |
| Windows  | X64, ARM64 |
| Linux    | X64, ARM64 |
