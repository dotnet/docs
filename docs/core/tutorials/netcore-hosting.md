---
title: Write a custom .NET runtime host
description: Learn to host the .NET runtime from native code to support advanced scenarios that require controlling how the .NET  runtime works.
author: mjrousos
ms.topic: how-to
ms.date: 12/21/2018
---
# Write a custom .NET host to control the .NET runtime from your native code

Like all managed code, .NET applications are executed by a host. The host is responsible for starting the runtime (including components like the JIT and garbage collector) and invoking managed entry points.

Hosting the .NET runtime is an advanced scenario and, in most cases, .NET developers don't need to worry about hosting because .NET build processes provide a default host to run .NET applications. In some specialized circumstances, though, it can be useful to explicitly host the .NET runtime, either as a means of invoking managed code in a native process or in order to gain more control over how the runtime works.

This article gives an overview of the steps necessary to start the .NET runtime from native code and execute managed code in it.

## Prerequisites

Because hosts are native applications, this tutorial covers constructing a C++ application to host .NET. You will need a C++ development environment (such as that provided by [Visual Studio](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs)).

You will also need to build a .NET component to test the host with, so you should install the [.NET SDK](https://dotnet.microsoft.com/download).

## Hosting APIs

Hosting the .NET runtime in .NET Core 3.0 and above is done with the `nethost` and `hostfxr` libraries' APIs. These entry points handle the complexity of finding and setting up the runtime for initialization and allow both launching a managed application and calling into a static managed method.

Prior to .NET Core 3.0, the only option for hosting the runtime was through the [`coreclrhost.h`](https://github.com/dotnet/runtime/blob/main/src/coreclr/hosts/inc/coreclrhost.h) API. This hosting API is obsolete now and should not be used for hosting .NET Core 3.0 and higher runtimes.

## Create a host using `nethost.h` and `hostfxr.h`

A [sample host](https://github.com/dotnet/samples/tree/main/core/hosting) demonstrating the steps outlined in the tutorial below is available in the dotnet/samples GitHub repository. Comments in the sample clearly associate the numbered steps from this tutorial with where they're performed in the sample. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#view-and-download-samples).

Keep in mind that the sample host is meant to be used for learning purposes, so it is light on error checking and designed to emphasize readability over efficiency.

The following steps detail how to use the `nethost` and `hostfxr` libraries to start the .NET runtime in a native application and call into a managed static method. The [sample](https://github.com/dotnet/samples/tree/main/core/hosting/src) uses the `nethost` header and library installed with the .NET SDK and copies of the [`coreclr_delegates.h`](https://github.com/dotnet/runtime/blob/main/src/native/corehost/coreclr_delegates.h) and [`hostfxr.h`](https://github.com/dotnet/runtime/blob/main/src/native/corehost/hostfxr.h) files from the [dotnet/runtime](https://github.com/dotnet/runtime) repository.

### Step 1 - Load `hostfxr` and get exported hosting functions

The `nethost` library provides the `get_hostfxr_path` function for locating the `hostfxr` library. The `hostfxr` library exposes functions for hosting the .NET runtime. The full list of functions can be found in [`hostfxr.h`](https://github.com/dotnet/runtime/blob/main/src/native/corehost/hostfxr.h) and the [native hosting design document](https://github.com/dotnet/runtime/blob/main/docs/design/features/native-hosting.md). The sample and this tutorial use the following:

* `hostfxr_initialize_for_runtime_config`: Initializes a host context and prepares for initialization of the .NET runtime using the specified runtime configuration.
* `hostfxr_get_runtime_delegate`: Gets a delegate for runtime functionality.
* `hostfxr_close`: Closes a host context.

The `hostfxr` library is found using `get_hostfxr_path` API from `nethost` library. It is then loaded and its exports are retrieved.

[!code-cpp[HostFxrHost#LoadHostFxr](~/samples/snippets/core/tutorials/netcore-hosting/csharp/HostWithHostFxr/src/NativeHost/nativehost.cpp#LoadHostFxr)]

### Step 2 - Initialize and start the .NET runtime

The `hostfxr_initialize_for_runtime_config` and `hostfxr_get_runtime_delegate` functions initialize and start the .NET runtime using the runtime configuration for the managed component that will be loaded. The `hostfxr_get_runtime_delegate` function is used to get a runtime delegate that allows loading a managed assembly and getting a function pointer to a static method in that assembly.

[!code-cpp[HostFxrHost#Initialize](~/samples/snippets/core/tutorials/netcore-hosting/csharp/HostWithHostFxr/src/NativeHost/nativehost.cpp#Initialize)]

### Step 3 - Load managed assembly and get function pointer to a managed method

The runtime delegate is called to load the managed assembly and get a function pointer to a managed method. The delegate requires the assembly path, type name, and method name as inputs and returns a function pointer that can be used to invoke the managed method.

[!code-cpp[HostFxrHost#LoadAndGet](~/samples/snippets/core/tutorials/netcore-hosting/csharp/HostWithHostFxr/src/NativeHost/nativehost.cpp#LoadAndGet)]

By passing `nullptr` as the delegate type name when calling the runtime delegate, the sample uses a default signature for the managed method:

```csharp
public delegate int ComponentEntryPoint(IntPtr args, int sizeBytes);
```

A different signature can be used by specifying the delegate type name when calling the runtime delegate.

### Step 4 - Run managed code!

The native host can now call the managed method and pass it the desired parameters.

[!code-cpp[HostFxrHost#CallManaged](~/samples/snippets/core/tutorials/netcore-hosting/csharp/HostWithHostFxr/src/NativeHost/nativehost.cpp#CallManaged)]
