---
title: Write a custom .NET Core runtime host
description: Learn to host the .NET Core runtime from native code to support advanced scenarios that require controlling how the .NET Core runtime works.
author: mjrousos
ms.date: 12/21/2018
---
# Write a custom .NET Core host to control the .NET runtime from your native code

Like all managed code, .NET Core applications are executed by a host. The host is responsible for starting the runtime (including components like the JIT and garbage collector) and invoking managed entry points.

Hosting the .NET Core runtime is an advanced scenario and, in most cases, .NET Core developers don't need to worry about hosting because .NET Core build processes provide a default host to run .NET Core applications. In some specialized circumstances, though, it can be useful to explicitly host the .NET Core runtime, either as a means of invoking managed code in a native process or in order to gain more control over how the runtime works.

This article gives an overview of the steps necessary to start the .NET Core runtime from native code and execute managed code in it.

## Prerequisites

Because hosts are native applications, this tutorial covers constructing a C++ application to host .NET Core. You will need a C++ development environment (such as that provided by [Visual Studio](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs)).

You will also want a simple .NET Core application to test the host with, so you should install the [.NET Core SDK](https://dotnet.microsoft.com/download) and [build a small .NET Core test app](with-visual-studio.md) (such as a 'Hello World' app). The 'Hello World' app created by the new .NET Core console project template is sufficient.

## Hosting APIs
There are three different APIs that can be used to host .NET Core. This article (and its associated [samples](https://github.com/dotnet/samples/tree/master/core/hosting)) covers all options.

* The preferred method of hosting the .NET Core runtime in .NET Core 3.0 and above is with the `nethost` and `hostfxr` libraries' APIs. These entry points handle the complexity of finding and setting up the runtime for initialization and allow both launching a managed application and calling into a static managed method.
* The preferred method of hosting the .NET Core runtime prior to .NET Core 3.0 is with the [CoreClrHost.h](https://github.com/dotnet/coreclr/blob/master/src/coreclr/hosts/inc/coreclrhost.h) API. This API exposes functions for easily starting and stopping the runtime and invoking managed code (either by launching a managed exe or by calling static managed methods).
* .NET Core can also be hosted with the `ICLRRuntimeHost4` interface in [mscoree.h](https://github.com/dotnet/coreclr/blob/master/src/pal/prebuilt/inc/mscoree.h). This API has been around longer than CoreClrHost.h, so you may have seen older hosts using it. It still works and allows a bit more control over the hosting process than CoreClrHost. For most scenarios, though, CoreClrHost.h is preferred now because of its simpler APIs.

## Sample Hosts
[Sample hosts](https://github.com/dotnet/samples/tree/master/core/hosting) demonstrating the steps outlined in the tutorials below are available in the dotnet/samples GitHub repository. Comments in the samples clearly associate the numbered steps from these tutorials with where they're performed in the sample. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

Keep in mind that the sample hosts are meant to be used for learning purposes, so they are light on error checking and are designed to emphasize readability over efficiency.

## Create a host using NetHost.h and HostFxr.h

The following steps detail how to use the `nethost` and `hostfxr` libraries to start the .NET Core runtime in a native application and call into a managed static method. The [sample](https://github.com/dotnet/samples/tree/master/core/hosting/HostWithHostFxr) uses the `nethost` header and library installed with the .NET SDK and copies of the [`coreclr_delegates.h`](https://github.com/dotnet/core-setup/blob/master/src/corehost/cli/coreclr_delegates.h) and [`hostfxr.h`](https://github.com/dotnet/core-setup/blob/master/src/corehost/cli/hostfxr.h) files from the [dotnet/core-setup](https://github.com/dotnet/core-setup) repository.

### Step 1 - Load HostFxr and get exported hosting functions

The `nethost` library provides the `get_hostfxr_path` function for locating the `hostfxr` library. The `hostfxr` library exposes functions for hosting the .NET Core runtime. The full list of functions can be found in [`hostfxr.h`](https://github.com/dotnet/core-setup/blob/master/src/corehost/cli/hostfxr.h) and the [native hosting design document](https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/native-hosting.md). The sample and this tutorial use the following:

* `hostfxr_initialize_for_runtime_config`: Initializes a host context and prepares for initialization of the .NET Core runtime using the specified runtime configuration.
* `hostfxr_get_runtime_delegate`: Gets a delegate for runtime functionality.
* `hostfxr_close`: Closes a host context.

The `hostfxr` library is found using `get_hostfxr_path`. It is then loaded and its exports are retrieved.

[!code-cpp[HostFxrHost#LoadHostFxr](~/samples/core/hosting/HostWithHostFxr/src/NativeHost/nativehost.cpp#LoadHostFxr)]

### Step 2 - Initialize and start the .NET Core runtime

The `hostfxr_initialize_for_runtime_config` and `hostfxr_get_runtime_delegate` functions initialize and start the .NET Core runtime using the runtime configuration for the managed component that will be loaded. The `hostfxr_get_runtime_delegate` function is used to get a runtime delegate that allows loading a managed assembly and getting a function pointer to a static method in that assembly.

[!code-cpp[HostFxrHost#Initialize](~/samples/core/hosting/HostWithHostFxr/src/NativeHost/nativehost.cpp#Initialize)]

### Step 3 - Load managed assembly and get function pointer to a managed method

The runtime delegate is called to load the managed assembly and get a function pointer to a managed method. The delegate requires the assembly path, type name, and method name as inputs and returns a function pointer that can be used to invoke the managed method.

[!code-cpp[HostFxrHost#LoadAndGet](~/samples/core/hosting/HostWithHostFxr/src/NativeHost/nativehost.cpp#LoadAndGet)]

By passing `nullptr` as the delegate type name when calling the runtime delegate, the sample uses a default signature for the managed method:

```csharp
public delegate int ComponentEntryPoint(IntPtr args, int sizeBytes);
```

A different signature can be used by specifying the delegate type name when calling the runtime delegate.

### Step 4 - Run managed code!

The native host can now call the managed method and pass it the desired parameters.

[!code-cpp[HostFxrHost#CallManaged](~/samples/core/hosting/HostWithHostFxr/src/NativeHost/nativehost.cpp#CallManaged)]

## Create a host using CoreClrHost.h

The following steps detail how to use the CoreClrHost.h API to start the .NET Core runtime in a native application and call into a managed static method. The code snippets in this document use some Windows-specific APIs, but the [full sample host](https://github.com/dotnet/samples/tree/master/core/hosting/HostWithCoreClrHost) shows both Windows and Linux code paths.

The [Unix CoreRun host](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts/unixcorerun) shows a more complex, real-world example of hosting using coreclrhost.h.

### Step 1 - Find and load CoreCLR

The .NET Core runtime APIs are in *coreclr.dll* (on Windows), in *libcoreclr.so* (on Linux), or in *libcoreclr.dylib* (on macOS). The first step to hosting .NET Core is to load the CoreCLR library. Some hosts probe different paths or use input parameters to find the library while others know to load it from a certain path (next to the host, for example, or from a machine-wide location).

Once found, the library is loaded with `LoadLibraryEx` (on Windows) or `dlopen` (on Linux/macOS).

[!code-cpp[CoreClrHost#1](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#1)]

### Step 2 - Get .NET Core hosting functions

CoreClrHost has several important methods useful for hosting .NET Core:

* `coreclr_initialize`: Starts the .NET Core runtime and sets up the default (and only) AppDomain.
* `coreclr_execute_assembly`: Executes a managed assembly.
* `coreclr_create_delegate`: Creates a function pointer to a managed method.
* `coreclr_shutdown`: Shuts down the .NET Core runtime.
* `coreclr_shutdown_2`: Like `coreclr_shutdown`, but also retrieves the managed code's exit code.

After loading the CoreCLR library, the next step is to get references to these functions using `GetProcAddress` (on Windows) or `dlsym` (on Linux/macOS).

[!code-cpp[CoreClrHost#2](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#2)]

### Step 3 - Prepare runtime properties

Before starting the runtime, it is necessary to prepare some properties to specify behavior (especially concerning the assembly loader).

Common properties include:

* `TRUSTED_PLATFORM_ASSEMBLIES`
   This is a list of assembly paths (delimited by ';' on Windows and ':' on Linux) which the runtime will be able to resolve by default. Some hosts have hard-coded manifests listing assemblies they can load. Others will put any library in certain locations (next to *coreclr.dll*, for example) on this list.
* `APP_PATHS`
   This is a list of paths to probe in for an assembly if it can't be found in the trusted platform assemblies (TPA) list. Because the host has more control over which assemblies are loaded using the TPA list, it is a best practice for hosts to determine which assemblies they expect to load and list them explicitly. If probing at runtime is needed, however, this property can enable that scenario.
* `APP_NI_PATHS`
   This list is similar to APP_PATHS except that it's meant to be paths that will be probed for native images.
* `NATIVE_DLL_SEARCH_DIRECTORIES`
   This property is a list of paths the loader should probe when looking for native libraries called via p/invoke.
* `PLATFORM_RESOURCE_ROOTS`
   This list includes paths to probe in for resource satellite assemblies (in culture-specific subdirectories).

In this sample host, the TPA list is constructed by simply listing all libraries in the current directory:

[!code-cpp[CoreClrHost#7](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#7)]

Because the sample is simple, it only needs the `TRUSTED_PLATFORM_ASSEMBLIES` property:

[!code-cpp[CoreClrHost#3](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#3)]

### Step 4 - Start the runtime

Unlike the mscoree.h hosting API (described below), CoreCLRHost.h APIs start the runtime and create the default AppDomain all with a single call. The `coreclr_initialize` function takes a base path, name, and the properties described earlier and returns back a handle to the host via the `hostHandle` parameter.

[!code-cpp[CoreClrHost#4](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#4)]

### Step 5 - Run managed code!

With the runtime started, the host can call managed code. This can be done in a couple of different ways. The sample code linked to this tutorial uses the `coreclr_create_delegate` function to create a delegate to a static managed method. This API takes the [assembly name](../../standard/assembly/names.md), namespace-qualified type name, and method name as inputs and returns a delegate that can be used to invoke the method.

[!code-cpp[CoreClrHost#5](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#5)]

In this sample, the host can now call `managedDelegate` to run the `ManagedWorker.DoWork` method.

Alternatively, the `coreclr_execute_assembly` function can be used to launch a managed executable. This API takes an assembly path and array of arguments as input parameters. It loads the assembly at that path and invokes its main method.

```C++
int hr = executeAssembly(
        hostHandle,
        domainId,
        argumentCount,
        arguments,
        "HelloWorld.exe",
        (unsigned int*)&exitCode);
```

### Step 6 - Shutdown and clean up

Finally, when the host is done running managed code, the .NET Core runtime is shut down with `coreclr_shutdown` or `coreclr_shutdown_2`.

[!code-cpp[CoreClrHost#6](~/samples/core/hosting/HostWithCoreClrHost/src/SampleHost.cpp#6)]

CoreCLR does not support reinitialization or unloading. Do not call `coreclr_initialize` again or unload the CoreCLR library.

## Create a host using Mscoree.h

As mentioned previously, CoreClrHost.h is now the preferred method of hosting the .NET Core runtime. The `ICLRRuntimeHost4` interface can still be used, though, if the CoreClrHost.h interfaces aren't sufficient (if non-standard startup flags are needed, for example, or if an AppDomainManager is needed on the default domain). These instructions will guide you through hosting .NET Core using mscoree.h.

The [CoreRun host](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts/corerun) shows a more complex, real-world example of hosting using mscoree.h.

### A note about mscoree.h
The `ICLRRuntimeHost4` .NET Core hosting interface is defined in [MSCOREE.IDL](https://github.com/dotnet/coreclr/blob/master/src/inc/MSCOREE.IDL). A header version of this file (mscoree.h), which your host will need to reference, is produced via MIDL when the [.NET Core runtime](https://github.com/dotnet/coreclr/) is built. If you do not want to build the .NET Core runtime, mscoree.h is also available as a [pre-built header](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc) in the dotnet/coreclr repository. [Instructions on building the .NET Core runtime](https://github.com/dotnet/coreclr#building-the-repository) can be found in its GitHub repository.

### Step 1 - Identify the managed entry point
After referencing necessary headers ([mscoree.h](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc/mscoree.h) and stdio.h, for example), one of the first things a .NET Core host must do is locate the managed entry point it will be using. In our sample host, this is done by just taking the first command-line argument to our host as the path to a managed binary whose `main` method will be executed.

[!code-cpp[NetCoreHost#1](~/samples/core/hosting/HostWithMscoree/host.cpp#1)]

### Step 2 - Find and load CoreCLR
The .NET Core runtime APIs are in *CoreCLR.dll* (on Windows). To get our hosting interface (`ICLRRuntimeHost4`), it's necessary to find and load *CoreCLR.dll*. It is up to the host to define a convention for how it will locate *CoreCLR.dll*. Some hosts expect the file to be present in a well-known machine-wide location (such as *%programfiles%\dotnet\shared\Microsoft.NETCore.App\2.1.6*). Others expect that *CoreCLR.dll* will be loaded from a location next to either the host itself or the app to be hosted. Still others might consult an environment variable to find the library.

On Linux or macOS, the core runtime library is *libcoreclr.so* or *libcoreclr.dylib*, respectively.

Our sample host probes a few common locations for *CoreCLR.dll*. Once found, it must be loaded via `LoadLibrary` (or `dlopen` on Linux/macOS).

[!code-cpp[NetCoreHost#2](~/samples/core/hosting/HostWithMscoree/host.cpp#2)]

### Step 3 - Get an ICLRRuntimeHost4 Instance
The `ICLRRuntimeHost4` hosting interface is retrieved by calling `GetProcAddress` (or `dlsym` on Linux/macOS) on `GetCLRRuntimeHost`, and then invoking that function.

[!code-cpp[NetCoreHost#3](~/samples/core/hosting/HostWithMscoree/host.cpp#3)]

### Step 4 - Set startup flags and start the runtime
With an `ICLRRuntimeHost4` in-hand, we can now specify runtime-wide startup flags and start the runtime. Startup flags determine which garbage collector (GC) to use (concurrent or server), whether we will use a single AppDomain or multiple AppDomains, and what loader optimization policy to use (for domain-neutral loading of assemblies).

[!code-cpp[NetCoreHost#4](~/samples/core/hosting/HostWithMscoree/host.cpp#4)]

The runtime is started with a call to the `Start` function.

```C++
hr = runtimeHost->Start();
```

### Step 5 - Preparing AppDomain settings
Once the runtime is started, we will want to set up an AppDomain. There are a number of options that must be specified when creating a .NET AppDomain, however, so it's necessary to prepare those first.

AppDomain flags specify AppDomain behaviors related to security and interop. Older Silverlight hosts used these settings to sandbox user code, but most modern .NET Core hosts run user code as full trust and enable interop.

[!code-cpp[NetCoreHost#5](~/samples/core/hosting/HostWithMscoree/host.cpp#5)]

After deciding which AppDomain flags to use, AppDomain properties must be defined. The properties are key/value pairs of strings. Many of the properties relate to how the AppDomain will load assemblies.

Common AppDomain properties include:

* `TRUSTED_PLATFORM_ASSEMBLIES`
   This is a list of assembly paths (delimited by `;` on Windows and `:` on Linux/macOS) which the AppDomain should prioritize loading and give full trust to (even in partially trusted domains). This list is meant to contain 'Framework' assemblies and other trusted modules, similar to the GAC in .NET Framework scenarios. Some hosts will put any library next to *coreclr.dll* on this list, others have hard-coded manifests listing trusted assemblies for their purposes.
* `APP_PATHS`
   This is a list of paths to probe in for an assembly if it can't be found in the trusted platform assemblies (TPA) list. Because the host has more control over which assemblies are loaded using the TPA list, it is a best practice for hosts to determine which assemblies they expect to load and list them explicitly. If probing at runtime is needed, however, this property can enable that scenario.
* `APP_NI_PATHS`
   This list is very similar to APP_PATHS except that it's meant to be paths that will be probed for native images.
* `NATIVE_DLL_SEARCH_DIRECTORIES`
   This property is a list of paths the loader should probe when looking for native DLLs called via p/invoke.
* `PLATFORM_RESOURCE_ROOTS`
   This list includes paths to probe in for resource satellite assemblies (in culture-specific subdirectories).

In our [simple sample host](https://github.com/dotnet/samples/tree/master/core/hosting/HostWithMscoree), these properties are set up as follows:

[!code-cpp[NetCoreHost#6](~/samples/core/hosting/HostWithMscoree/host.cpp#6)]

### Step 6 - Create the AppDomain
Once all AppDomain flags and properties are prepared, `ICLRRuntimeHost4::CreateAppDomainWithManager` can be used to set up the AppDomain. This function optionally takes a fully qualified assembly name and type name to use as the domain's AppDomain manager. An AppDomain manager can allow a host to control some aspects of AppDomain behavior and may provide entry points for launching managed code if the host doesn't intend to invoke user code directly.

[!code-cpp[NetCoreHost#7](~/samples/core/hosting/HostWithMscoree/host.cpp#7)]

### Step 7 - Run managed code!
With an AppDomain up and running, the host can now start executing managed code. The easiest way to do this is to use `ICLRRuntimeHost4::ExecuteAssembly` to invoke a managed assembly's entry point method. Note that this function only works in single-domain scenarios.

[!code-cpp[NetCoreHost#8](~/samples/core/hosting/HostWithMscoree/host.cpp#8)]

Another option, if `ExecuteAssembly` doesn't meet your host's needs, is to use `CreateDelegate` to create a function pointer to a static managed method. This requires the host to know the signature of the method it is calling into (in order to create the function pointer type) but allows hosts the flexibility to invoke code other than an assembly's entry point. The assembly name provided in the second parameter is the [full managed assembly name](../../standard/assembly/names.md) of the library to load.

```C++
void *pfnDelegate = NULL;
hr = runtimeHost->CreateDelegate(
    domainId,
    L"HW, Version=1.0.0.0, Culture=neutral", // Target managed assembly
    L"ConsoleApplication.Program",           // Target managed type
    L"Main",                                 // Target entry point (static method)
    (INT_PTR*)&pfnDelegate);

((MainMethodFp*)pfnDelegate)(NULL);
```

### Step 8 - Clean up
Finally, the host should clean up after itself by unloading AppDomains, stopping the runtime, and releasing the `ICLRRuntimeHost4` reference.

[!code-cpp[NetCoreHost#9](~/samples/core/hosting/HostWithMscoree/host.cpp#9)]

CoreCLR does not support unloading. Do not unload the CoreCLR library.

## Conclusion
Once your host is built, it can be tested by running it from the command line and passing any arguments the host expects (like the managed app to run for the mscoree example host). When specifying the .NET Core app for the host to run, be sure to use the .dll that is produced by `dotnet build`. Executables (.exe files) produced by `dotnet publish` for self-contained applications are actually the default .NET Core host (so that the app can be launched directly from the command line in mainline scenarios); user code is compiled into a dll of the same name.

If things don't work initially, double-check that *coreclr.dll* is available in the location expected by the host, that all necessary Framework libraries are in the TPA list, and that CoreCLR's bitness (32-bit or 64-bit) matches how the host was built.

Hosting the .NET Core runtime is an advanced scenario that many developers won't require, but for those who need to launch managed code from a native process, or who need more control over the .NET Core runtime's behavior, it can be very useful.
