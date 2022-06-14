---
title: Native AOT deployment overview
description: Learn what native AOT deployments are and why you should consider using it as part of the publishing your app with .NET 7 and later.
author: lakshanf
ms.author: lakshanf
ms.date: 06/09/2022
---
# Native AOT Deployment

Publishing your app as *native AOT* produces an app that is [*self-contained*](index.md#publish-self-contained) and that has been ahead-of-time (AOT) compiled to native code. Native AOT apps start up very quickly and use less memory. Users of the application can run it on a machine that doesn't have the .NET runtime installed.

The native AOT deployment model uses an IL to native compiler. Native AOT apps don't use a Just-In-Time (JIT) compiler when the application runs. Native AOT apps can run in restricted environments where a JIT is not allowed. Native AOT applications target a specific runtime environment, such as Linux x64 or Windows x64, just like publishing a [self-contained app](index.md#publish-self-contained).

There are some limitations in the .NET native AOT deployment model, with the main one being that run-time code generation is not possible. For more information, see [Impact of using the Native AOT deployment](#impact-of-using-the-native-aot-deployment). The support in the .NET 7 release is targeted towards console-type applications.

> [!WARNING]
> Native AOT is supported in .NET 7 but only a limited number of libraries are fully compatible with native AOT in .NET 7.

## Publish Native AOT - CLI

Publish a native AOT application using the [dotnet publish](../tools/dotnet-publish.md) command.

01. Add `<PublishAot>true</PublishAot>` to your project file.

    This will produce a native AOT app and shows PublishAot compatibility warnings during build.

    ```xml
    <PropertyGroup>
        <PublishAot>true</PublishAot>
    </PropertyGroup>
    ```

02. Ensure pre-requisites that are needed for publishing a native AOT application are in the machine.

    For Windows pre-requisites, install [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), including Desktop development with C++ workload.

    For Linux pre-requisites, install clang and developer packages for libraries that .NET runtime depends on.

    *Ubuntu (18.04+)*

    ```sh
    sudo apt-get install clang zlib1g-dev
    ```

    *Alpine (3.15+)*

    ```sh
    sudo apk add clang gcc lld musl-dev build-base zlib-dev
    ```

03. Publish the app for a specific runtime identifier using `dotnet publish -r <RID>`.

    The following example publishes the app for Windows as a native AOT application on a machine with the required pre-requisites installed.

    `dotnet publish -r win-x64 -c Release`

    The following example publishes the app for Linux as a native AOT application. A native AOT binary produced on Linux machine is only going to work on same or newer Linux version. For example, native AOT binary produced on Ubuntu 20.04 is going to run on Ubuntu 20.04 and later, but it is not going to run on Ubuntu 18.04.

    `dotnet publish -r linux-arm64 -c Release`

The app will be available in the publish directory and will contain all the code needed to run in it, including the coreclr runtime.

## Impact of using the Native AOT deployment

Native AOT applications are [self-contained](index.md#publish-self-contained) and don't use any shared libraries, as is the case with the default [framework-dependent deployment model](index.md#publish-framework-dependent). Consider the native AOT deployment model when the benefits to deployment and the ability to optimize a single app outweigh the benefits of sharing for certain types of workloads. The gain is most significant for workloads with a high number of deployed instances: cloud infrastructure, hyper-scale services, popular apps, or games.

Native AOT applications comes with a few fundamental limitations and compatibility issues. The key limitations include:

- No dynamic loading (for example, `Assembly.LoadFile`)
- No runtime code generation (for example, `System.Reflection.Emit`)
- No C++/CLI
- No built-in COM (only applies to Windows)
- Requires trimming, which has [limitations](trimming/incompatibilities.md)

The first release of native AOT in .NET 7 has additional limitations. These include:

- Should be targeted for console type applications.
- Not all the runtime libraries are fully annotated to be native AOT compatible (that is, some warnings in the runtime libraries are not actionable by end developers).
- Limited diagnostic support (debugging and profiling).

## Platform/architecture restrictions

The following table shows supported compilation targets when targeting .NET 7.

| Platform | Supported architecture |
| ------------ | --------------------------- |
| Windows  | x64, Arm64 |
| Linux    | x64, Arm64 |
