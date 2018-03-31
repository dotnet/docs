---
title: Hosting .NET Core
description: Hosting the .NET Core runtime from native code
keywords: .NET, .NET Core, Hosting, Hosting .NET Core
author: mjrousos
ms.author: mikerou
ms.date: 2/3/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 13edec8b-614d-47ed-9e95-ed6d3b94ec0c
ms.workload: 
  - "dotnetcore"
---

# Hosting .NET Core

Like all managed code, .NET Core applications are executed by a host. The host is responsible for starting the runtime (including components like the JIT and garbage collector), creating AppDomains, and invoking managed entry points.

Hosting the .NET Core runtime is an advanced scenario and, in most cases, .NET Core developers don't need to worry about hosting because .NET Core build processes provide a default host to run .NET Core applications. In some specialized circumstances, though, it can be useful to explicitly host the .NET Core runtime, either as a means of invoking managed code in a native process or in order to gain more control over how the runtime works.

This article gives an overview of the steps necessary to start the .NET Core runtime from native code, create an initial application domain (<xref:System.AppDomain>), and execute managed code in it.

## Prerequisites

Because hosts are native applications, this tutorial will cover constructing a C++ application to host .NET Core. You will need a C++ development environment (such as that provided by [Visual Studio](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs)).

You will also want a simple .NET Core application to test the host with, so you should install the [.NET Core SDK](https://www.microsoft.com/net/core) and [build a small .NET Core test app](../../core/tutorials/with-visual-studio.md) (such as a 'Hello World' app). The 'Hello World' app created by the new .NET Core console project template is sufficient.

This tutorial and its associated sample build a Windows host; see the notes at the end of this article about hosting on Unix.

## Creating the host

A [sample host](https://github.com/dotnet/samples/tree/master/core/hosting) demonstrating the steps outlined in this article is available in the dotnet/samples GitHub repository. Comments in the sample's *host.cpp* file clearly associate the numbered steps from this tutorial with where they're performed in the sample. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

Keep in mind that the sample host is meant to be used for learning purposes, so it is light on error checking and is designed to emphasize readability over efficiency. More real-world host samples are available in the [dotnet/coreclr](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts) repository. The [CoreRun host](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts/corerun), in particular, is a good general-purpose host to study after reading through the simpler sample.

### A note about mscoree.h
The primary .NET Core hosting interface (`ICLRRuntimeHost2`) is defined in [MSCOREE.IDL](https://github.com/dotnet/coreclr/blob/master/src/inc/MSCOREE.IDL). A header version of this file (mscoree.h), which your host will need to reference, is produced via MIDL when the [.NET Core runtime](https://github.com/dotnet/coreclr/) is built. If you do not want to build the .NET Core runtime, mscoree.h is also available as a [pre-built header](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc) in the dotnet/coreclr repository. [Instructions on building the .NET Core runtime](https://github.com/dotnet/coreclr#building-the-repository) can be found in its GitHub repository. 

### Step 1 - Identify the managed entry point
After referencing necessary headers ([mscoree.h](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc/mscoree.h) and stdio.h, for example), one of the first things a .NET Core host must do is locate the managed entry point it will be using. In our sample host, this is done by just taking the first command line argument to our host as the path to a managed binary whose `main` method will be executed.

[!code-cpp[NetCoreHost#1](../../../samples/core/hosting/host.cpp#1)]

### Step 2 - Find and load CoreCLR.dll
The .NET Core runtime APIs are in *CoreCLR.dll* (on Windows). To get our hosting interface (`ICLRRuntimeHost2`), it's necessary to find and load *CoreCLR.dll*. It is up to the host to define a convention for how it will locate *CoreCLR.dll*. Some hosts expect the file to be present in a well-known machine-wide location (such as %programfiles%\dotnet\shared\Microsoft.NETCore.App\1.1.0). Others expect that *CoreCLR.dll* will be loaded from a location next to either the host itself or the app to be hosted. Still others might consult an environment variable to find the library.

On Linux or Mac, the core runtime library is *libcoreclr.so* or *libcoreclr.dylib*, respectively.

Our sample host probes a few common locations for *CoreCLR.dll*. Once found, it must be loaded via `LoadLibrary` (or `dlopen` on Linux/Mac).

[!code-cpp[NetCoreHost#2](../../../samples/core/hosting/host.cpp#2)]

### Step 3 - Get an ICLRRuntimeHost2 Instance
The `ICLRRuntimeHost2` hosting interface is retrieved by calling `GetProcAddress` (or `dlsym` on Linux/Mac) on `GetCLRRuntimeHost`, and then invoking that function. 

[!code-cpp[NetCoreHost#3](../../../samples/core/hosting/host.cpp#3)]

### Step 4 - Setting startup flags and starting the runtime
With an `ICLRRuntimeHost2` in-hand, we can now specify runtime-wide startup flags and start the runtime. Startup flags will determine which garbage collector (GC) to use (concurrent or server), whether we will use a single AppDomain or multiple AppDomains, and what loader optimization policy to use (for domain-neutral loading of assemblies).

[!code-cpp[NetCoreHost#4](../../../samples/core/hosting/host.cpp#4)]

The runtime is started with a call to the `Start` function.

```C++
hr = runtimeHost->Start();
```

### Step 5 - Preparing AppDomain settings
Once the runtime is started, we will want to set up an AppDomain. There are a number of options that must be specified when creating a .NET AppDomain, however, so it's necessary to prepare those first.

AppDomain flags specify AppDomain behaviors related to security and interop. Older Silverlight hosts used these settings to sandbox user code, but most modern .NET Core hosts run user code as full trust and enable interop.

[!code-cpp[NetCoreHost#5](../../../samples/core/hosting/host.cpp#5)]

After deciding which AppDomain flags to use, AppDomain properties must be defined. The properties are key/value pairs of strings. Many of the properties relate to how the AppDomain will load assemblies.

Common AppDomain properties include:

* `TRUSTED_PLATFORM_ASSEMBLIES` This is a list of assembly paths (delimited by ';' on Windows and ':' on Unix) which the AppDomain should prioritize loading and give full trust to (even in partially-trusted domains). This list is meant to contain 'Framework' assemblies and other trusted modules, similar to the GAC in .NET Framework scenarios. Some hosts will put any library next to *coreclr.dll* on this list, others have hard-coded manifests listing trusted assemblies for their purposes.
* `APP_PATHS` This is a list of paths to probe in for an assembly if it can't be found in the trusted platform assemblies (TPA) list. These paths are meant to be the locations where users' assemblies can be found. In a sandboxed AppDomain, assemblies loaded from these paths will only be granted partial trust. Common APP_PATH paths include the path the target app was loaded from or other locations where user assets are known to live.
*  `APP_NI_PATHS` This list is very similar to APP_PATHS except that it's meant to be paths that will be probed for native images.
*  `NATIVE_DLL_SEARCH_DIRECTORIES` This property is a list of paths the loader should probe when looking for native DLLs called via p/invoke.
*  `PLATFORM_RESOURCE_ROOTS` This list includes paths to probe in for resource satellite assemblies (in culture-specific sub-directories).
*  `AppDomainCompatSwitch` This string specifies which compatibility quirks should be used for assemblies without an explicit Target Framework Moniker (an assembly-level attribute indicating which Framework an assembly is meant to run against). Typically, this should be set to `"UseLatestBehaviorWhenTFMNotSpecified"` but some hosts may prefer to get older Silverlight or Windows Phone compatibility quirks, instead.

In our [simple sample host](https://github.com/dotnet/samples/tree/master/core/hosting), these properties are set up as follows:

[!code-cpp[NetCoreHost#6](../../../samples/core/hosting/host.cpp#6)]

### Step 6 - Create the AppDomain
Once all AppDomain flags and properties are prepared, `ICLRRuntimeHost2::CreateAppDomainWithManager` can be used to set up the AppDomain. This function optionally takes a fully qualified assembly name and type name to use as the domain's AppDomain manager. An AppDomain manager can allow a host to control some aspects of AppDomain behavior and may provide entry points for launching managed code if the host doesn't intend to invoke user code directly.   

[!code-cpp[NetCoreHost#7](../../../samples/core/hosting/host.cpp#7)]

### Step 7 - Run managed code!
With an AppDomain up and running, the host can now start executing managed code. The easiest way to do this is to use `ICLRRuntimeHost2::ExecuteAssembly` to invoke a managed assembly's entry point method. Note that this function only works in single-domain scenarios.

[!code-cpp[NetCoreHost#8](../../../samples/core/hosting/host.cpp#8)]

Another option, if `ExecuteAssembly` doesn't meet your host's needs, is to use `CreateDelegate` to create a function pointer to a static managed method. This requires the host to know the signature of the method it is calling into (in order to create the function pointer type) but allows hosts the flexibility to invoke code other than an assembly's entry point.

```C++
void *pfnDelegate = NULL;
hr = runtimeHost->CreateDelegate(
  domainId,
  L"HW, Version=1.0.0.0, Culture=neutral",	// Target managed assembly
  L"ConsoleApplication.Program",			// Target managed type
  L"Main",									// Target entry point (static method)
  (INT_PTR*)&pfnDelegate);

((MainMethodFp*)pfnDelegate)(NULL);
```

### Step 8 - Clean up
Finally, the host should clean up after itself by unloading AppDomains, stopping the runtime, and releasing the `ICLRRuntimeHost2` reference.

[!code-cpp[NetCoreHost#9](../../../samples/core/hosting/host.cpp#9)]

## About Hosting .NET Core on Unix
.NET Core is a cross-platform product, running on Windows, Linux, and Mac operating systems. As native applications, though, hosts for different platforms will have some differences between them. The process described above of using `ICLRRuntimeHost2` to start the runtime, create an AppDomain, and execute managed code, should work on any supported operating system. However, the interfaces defined in mscoree.h can be cumbersome to work with on Unix platforms since mscoree makes many Win32 assumptions.

To make hosting on Unix platforms easier, a set of more platform-neutral hosting API wrappers are available in [coreclrhost.h](https://github.com/dotnet/coreclr/blob/master/src/coreclr/hosts/inc/coreclrhost.h).

An example of using coreclrhost.h (instead of mscoree.h directly) can be seen in the [UnixCoreRun host](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts). The steps to use the APIs from coreclrhost.h to host the runtime are similar to the steps when using mscoree.h:

1. Identify the managed code to execute (from command line parameters, for example). 
2. Load the CoreCLR library.
	1. `dlopen("./libcoreclr.so", RTLD_NOW | RTLD_LOCAL);` 
3. Get function pointers to CoreCLR's `coreclr_initialize`, `coreclr_create_delegate`, `coreclr_execute_assembly`, and `coreclr_shutdown` functions using `dlsym`
	1. `coreclr_initialize_ptr coreclr_initialize = (coreclr_initialize_ptr)dlsym(coreclrLib, "coreclr_initialize");`
4. Set up AppDomain properties (such as the TPA list). This is the same as step 5 from the mscoree workflow, above.
5. Use `coreclr_initialize` to start the runtime and create an AppDomain. This will also create a `hostHandle` pointer that will be used in future hosting calls.
	1. Note that this function performs the roles of both steps 4 and 6 from the previous workflow. 
6. Use either `coreclr_execute_assembly` or `coreclr_create_delegate` to execute managed code. These functions are analogous to mscoree's `ExecuteAssembly` and `CreateDelegate` functions from step 7 of the previous workflow.
7. Use `coreclr_shutdown` to unload the AppDomain and shut down the runtime. 

## Conclusion
Once your host is built, it can be tested by running it from the command line and passing any arguments (like the managed app to run) the host expects. When specifying the .NET Core app for the host to run, be sure to use the .dll that is produced by `dotnet build`. Executables produced by `dotnet publish` for self-contained applications are actually the default .NET Core host (so that the app can be launched directly from the command line in mainline scenarios); user code is compiled into a dll of the same name. 

If things don't work initially, double-check that *coreclr.dll* is available in the location expected by the host, that all necessary Framework libraries are in the TPA list, and that CoreCLR's bitness (32- or 64-bit) matches how the host was built.

Hosting the .NET Core runtime is an advanced scenario that many developers won't require, but for those who need to launch managed code from a native process, or who need more control over the .NET Core runtime's behavior, it can be very useful. Because .NET Core is able to run side-by-side with itself, it's even possible to create hosts which initialize and start multiple versions of the .NET Core runtime and execute apps on all of them in the same process. 
