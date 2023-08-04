---
title: Native AOT deployment overview
description: Learn what native AOT deployments are and why you should consider using it as part of the publishing your app with .NET 7 and later.
author: lakshanf
ms.author: lakshanf
ms.date: 06/12/2023
---

# Native AOT deployment

Publishing your app as *native AOT* produces an app that's [self-contained](../index.md#publish-self-contained) and that has been ahead-of-time (AOT) compiled to native code. Native AOT apps have faster startup time and smaller memory footprints. These apps can run on machines that don't have the .NET runtime installed.

The benefit of native AOT is most significant for workloads with a high number of deployed instances, such as cloud infrastructure and hyper-scale services. Native AOT deployment is currently in [preview for ASP.NET Core 8.0](/aspnet/core/fundamentals/native-aot/?view=aspnetcore-8.0&preserve-view=true).

The native AOT deployment model uses an ahead-of-time compiler to compile IL to native code at the time of publish. Native AOT apps don't use a just-in-time (JIT) compiler when the application runs. Native AOT apps can run in restricted environments where a JIT isn't allowed. Native AOT applications target a specific runtime environment, such as Linux x64 or Windows x64, just like publishing a [self-contained app](../index.md#publish-self-contained).

## Limitations in the .NET native AOT deployment model

### [.NET 7](#tab/net7)

> [!WARNING]
>
> - Native AOT is targeted towards console-type apps.
> - Only a limited number of libraries are fully compatible with native AOT.
>

### [.NET 8+](#tab/net8plus)

AOT support in .NET 8 is more comprehensive than in .NET 7. However, there are still some limitations. For more information, see [Limitations of Native AOT deployment](#limitations-of-native-aot-deployment).

---

## Prerequisites

The following prerequisites need to be installed before publishing .NET projects with native AOT.

On Windows, install [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), including the **Desktop development with C++** workload with all default components.

On Linux, install the compiler toolchain and developer packages for libraries that the .NET runtime depends on.

- Ubuntu (18.04+)

  ```sh
  sudo apt-get install clang zlib1g-dev
  ```

- Alpine (3.15+)

  ```sh
  sudo apk add clang build-base zlib-dev
  ```

On macOS, install the latest [Command Line Tools for XCode](https://developer.apple.com/download/). Supported on .NET 8 and later versions.

## Publish native AOT using the CLI

1. Add `<PublishAot>true</PublishAot>` to your project file.

    This property enables native AOT compilation during publish. It also enables dynamic code-usage analysis during build and editing. It's preferable to put this setting in the project file rather than passing it on the command line, since it controls behaviors outside publish.

    ```xml
    <PropertyGroup>
        <PublishAot>true</PublishAot>
    </PropertyGroup>
    ```

1. Publish the app for a specific runtime identifier using `dotnet publish -r <RID>`.

    The following example publishes the app for Windows as a native AOT application on a machine with the required prerequisites installed.

    `dotnet publish -r win-x64 -c Release`

    The following example publishes the app for Linux as a native AOT application. A native AOT binary produced on Linux machine is only going to work on same or newer Linux version. For example, native AOT binary produced on Ubuntu 20.04 is going to run on Ubuntu 20.04 and later, but it isn't going to run on Ubuntu 18.04.

    `dotnet publish -r linux-arm64 -c Release`

The app is available in the publish directory and contains all the code needed to run in it, including a stripped-down version of the coreclr runtime.

Check out the [native AOT samples](https://github.com/dotnet/samples/tree/main/core/nativeaot) available in the dotnet/samples repository on GitHub. The samples include [Linux](https://github.com/dotnet/samples/blob/main/core/nativeaot/HelloWorld/Dockerfile) and [Windows](https://github.com/dotnet/samples/blob/main/core/nativeaot/HelloWorld/Dockerfile.windowsservercore-x64) Dockerfiles that demonstrate how to automate installation of prerequisites and publish .NET projects with native AOT using containers.

## AOT-compatibility analyzers

### [.NET 7](#tab/net7)

AOT-compatibility analyzers are available only in .NET 8 and later versions.

### [.NET 8+](#tab/net8plus)

The `IsAotCompatible` property is used to indicate whether a library is compatible with native AOT. Consider when a library sets the `IsAotCompatible` property to `true`, for example:

```xml
<PropertyGroup>
    <IsAotCompatible>true</IsAotCompatible>
</PropertyGroup>
```

The preceding configuration assigns a default of `true` to the following properties:

- `IsTrimmable`
- `EnableTrimAnalyzer`
- `EnableSingleFileAnalyzer`
- `EnableAotAnalyzer`

These analyzers help to ensure that a library is compatible with native AOT.

---

## Native debug information

### [.NET 7](#tab/net7)

Native AOT publishing follows platform conventions for native toolchains. The default behavior of native toolchains on Windows is to produce debug information in a separate *.pdb* file. The default behavior of native toolchains on Linux is to include the debug information in the native binary, which makes the native binary larger.

Set the `StripSymbols` property to `true` to produce the debug information in a separate *.dbg* file and exclude it from the native binary on Linux. (This property has no effect on Windows.)

```xml
<PropertyGroup>
    <StripSymbols>true</StripSymbols>
</PropertyGroup>
```

### [.NET 8+](#tab/net8plus)

By default, native AOT publishing produces debug information in a separate file:

- Linux: *.dbg*
- Windows: *.pdb*
- macOS: *.dwarf*

The debug file is necessary for running the app under the debugger or inspecting crash dumps. On Unix-like platforms, set the `StripSymbols` property to `false` to include the debug information in the native binary. Including debug information makes the native binary larger.

```xml
<PropertyGroup>
    <StripSymbols>false</StripSymbols>
</PropertyGroup>
```

---

## Limitations of native AOT deployment

Native AOT apps have the following limitations:

- No dynamic loading, for example, `Assembly.LoadFile`.
- No run-time code generation, for example, `System.Reflection.Emit`.
- No C++/CLI.
- Windows: No built-in COM.
- Requires trimming, which has [limitations](../trimming/incompatibilities.md).
- Implies compilation into a single file, which has known [incompatibilities](../single-file/overview.md#api-incompatibility).
- Apps include required runtime libraries (just like [self-contained apps](../index.md#publish-self-contained), increasing their size as compared to framework-dependent apps).
- <xref:System.Linq.Expressions> always use their interpreted form, which is slower than run-time generated compiled code.
- Not all the runtime libraries are fully annotated to be native AOT compatible. That is, some warnings in the runtime libraries aren't actionable by end developers.

The publish process analyzes the entire project and its dependencies for possible limitations. Warnings are issued for each limitation the published app may encounter at run time.

### OS specific limitations

### [.NET 7](#tab/net7)

- Should be targeted for console type apps. ASP.NET Core is ***not*** supported.
- Limited diagnostic support for debugging and profiling.

### [.NET 8+](#tab/net8plus)

Support for some ASP.NET Core features. For more information, see [ASP.NET Core support for native AOT](/aspnet/core/fundamentals/native-aot/?view=aspnetcore-8.0&preserve-view=true).

---

## Build native libraries

Publishing .NET class libraries as native AOT allows creating libraries that can be consumed from non-.NET programming languages. The produced native library is self-contained and doesn't require a .NET runtime to be installed.

Publishing a class library as native AOT creates a native library that exposes methods of the class library annotated with <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> with a non-null `EntryPoint` field. For more information, see the [native library sample](https://github.com/dotnet/samples/tree/main/core/nativeaot/NativeLibrary) available in the dotnet/samples repository on GitHub.

## Platform/architecture restrictions

The following table shows supported compilation targets.

### [.NET 7](#tab/net7)

| Platform | Supported architecture |
|----------|------------------------|
| Windows  | x64, Arm64             |
| Linux    | x64, Arm64             |

### [.NET 8+](#tab/net8plus)

| Platform | Supported architecture |  Notes               |
|----------|------------------------|----------------------|
| Windows  | x64, Arm64             |                      |
| Linux    | x64, Arm64             |                      |
| macOS   | x64, Arm64 |                                        |
| iOS     | Arm64 | Experimental support                   |
| iOSSimulator     | x64, Arm64 | Experimental support                   |
| tvOS     | Arm64 | Experimental support                   |
| tvOSSimulator     | x64, Arm64 | Experimental support                   |
| MacCatalyst     | x64, Arm64 | Experimental support                   |
| Android | x64, Arm64 | Experimental, no built-in Java interop |

---
