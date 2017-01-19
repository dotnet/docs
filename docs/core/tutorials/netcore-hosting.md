---
title: Hosting .NET Core
description: Hosting the .NET Core runtime from native code 
keywords: .NET, .NET Core, Hosting
author: mikerou
---

# Hosting .NET Core

Like all managed code, .NET Core applications are executed by a host. The host is responsible for starting the runtime (including components like the JIT and garbage collector), creating AppDomains, and invoking managed entry points.

In most cases, .NET Core developers don't need to worry about hosting because .NET Core build processes provide a default host to run .NET Core applications. In some specialized circumstances, though, it can be useful to explicitly host the .NET Core runtime, either as a means of invoking managed code in a native process or in order to gain more control over how the runtime, itself, works.

This article gives an overview of the steps necessary to start the .NET Core runtime from native code, create an initial AppDomain, and execute managed code in it.

## Prerequisites

Because hosts are, themselves, native applications, this tutorial will cover constructing a C++ application to host .NET Core. You will need a C++ development environment (such as that provided by [Visual Studio 2015](https://www.microsoft.com/en-us/download/details.aspx?id=48146)).

You will also want a simple .NET Core application to test the host with, so you should install the [.NET Core SDK and CLI](https://www.microsoft.com/net/core) and build a small .NET Core test app (such as a 'Hello World' app).

This tutorial and its [associated sample](https://github.com/dotnet/docs/tree/master/samples/core/hosting) build a Windows host, but please see the notes at the end of this article about hosting on Unix.

## Creating the host

A sample host demonstrating the steps outlined in this article is available in our [.NET Core samples](https://github.com/dotnet/docs/tree/master/samples/core/hosting). Comments in the sample's host.cpp file clearly associate the numbered steps from this tutorial with where they are performed in the sample.

Please bear in mind that the sample host is meant to be used for learning purposes so it is light on error checking and bears a design that emphasizes readability over efficiency. More real-world host samples are available in the [dotnet/coreclr](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts) repository. The [CoreRun host](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts/corerun), in particular, is a good general-purpose host to study after reading through the simpler sample.

### A note about mscoree.h
The primary .NET Core hosting interface (`ICLRRuntimeHost2`) is defined in [MSCOREE.IDL](https://github.com/dotnet/coreclr/blob/master/src/inc/MSCOREE.IDL). A header version of this file (mscoree.h - which your host will need to reference) is produced via MIDL when the [.NET Core runtime](https://github.com/dotnet/coreclr/) is built. If you do not want to build the .NET Core runtime, mscoree.h is also available as a [pre-built header](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc) in the dotnet/coreclr repository. 

### Step 1 - Identify the managed entry point
After referencing necessary headers ([mscoree.h](https://github.com/dotnet/coreclr/tree/master/src/pal/prebuilt/inc/mscoree.h) and stdio.h, for example), one of the first things a .NET Core host must do is locate the managed entry point it will be using.

In our sample host, this is done very simply - we just take the first argument to our host as the path to a managed binary whose main method will be executed.

```C++
// The managed application to run should be the first command line parameter.
// Subsequent command line parameters will be passed to the managed app later in this host.
wchar_t targetApp[MAX_PATH];
GetFullPathNameW(argv[1], MAX_PATH, targetApp, NULL);
```

### Step 2 - Find and load CoreCLR.dll
The .NET Core runtime APIs are in CoreCLR.dll (on Windows). To get our hosting interface (`ICLRRuntimeHost2`), it's necessary to find and load CoreCLR.dll. It is up to the host to define a convention for how it will locate CoreCLR.dll. Some hosts expect the file to be present in a well-known machine-wide location (such as %programfiles%\dotnet\shared\Microsoft.NETCore.App\1.1.0). Others expect that CoreCLR.dll will be loaded from a location next to either the host itself or the app to be hosted. Still others might consult an environment variable to find the library.

On Linux or Mac, the core runtime library is libcoreclr.so or libcoreclr.dylib, respectively.

Our sample host probes a few common locations for CoreCLR.dll. Once found, it must be loaded via `LoadLibrary` (or `dlopen` on Linux/Mac).

```C++
HMODULE coreClrModule = LoadLibraryExW(coreDllPath, NULL, 0);
```

### Step 3 - Get an ICLRRuntimeHost2 Instance
The `ICLRRuntimeHost2` hosting interface is retrieved by calling `GetProcAddress` (or `dlsym` on Linux/Mac) on `GetCLRRuntimeHost`, and then invoking that function. 

```C++
ICLRRuntimeHost2* runtimeHost;

FnGetCLRRuntimeHost pfnGetCLRRuntimeHost =
	(FnGetCLRRuntimeHost)::GetProcAddress(coreCLRModule, "GetCLRRuntimeHost");

// Get the hosting interface
HRESULT hr = pfnGetCLRRuntimeHost(IID_ICLRRuntimeHost2, (IUnknown**)&runtimeHost);
```

### Step 4 - Setting startup flags and starting the runtime
With an `ICLRRuntimeHost2` in-hand, we can now specify runtime-wide startup flags and start the runtime. Startup flags will determine which GC to use (concurrent or server), whether we will use a single AppDomain or multiple AppDomains, and what loader optimization policy to use (for domain-neutral loading of assemblies).

```C++
hr = runtimeHost->SetStartupFlags(
	// These startup flags control runtime-wide behaviors.
	// A complete list of STARTUP_FLAGS can be found in mscoree.h,
	// but some of the more common ones are listed below.
	static_cast<STARTUP_FLAGS>(
		// STARTUP_FLAGS::STARTUP_SERVER_GC |								// Use server GC
		// STARTUP_FLAGS::STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN |		// Maximize domain-neutral loading
		// STARTUP_FLAGS::STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN_HOST |	// Domain-neutral loading for strongly-named assemblies
		STARTUP_FLAGS::STARTUP_CONCURRENT_GC |						// Use concurrent GC
		STARTUP_FLAGS::STARTUP_SINGLE_APPDOMAIN |					// All code executes in the default AppDomain 
																	// (required to use the runtimeHost->ExecuteAssembly helper function)
		STARTUP_FLAGS::STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN	// Prevents domain-neutral loading
	)
);
```

The runtime is started with a call to the `Start` function.

```C++
hr = runtimeHost->Start();
```

### Step 5 - Preparing AppDomain settings
Once the runtime is started, we will want to setup an AppDomain. There are a number of options that must be specified when creating a .NET AppDomain, however, so it's necessary to prepare those first.

AppDomain flags specify AppDomain behaviors related to security and interop. Older Silverlight hosts used these settings to sandbox user code, but most modern .NET Core hosts run user code as full trust and enable interop.

```C++
int appDomainFlags =
	// APPDOMAIN_FORCE_TRIVIAL_WAIT_OPERATIONS |		// Do not pump messages during wait
	// APPDOMAIN_SECURITY_SANDBOXED |					// Causes assemblies not from the TPA list to be loaded as partially trusted
	APPDOMAIN_ENABLE_PLATFORM_SPECIFIC_APPS |			// Enable platform-specific assemblies to run
	APPDOMAIN_ENABLE_PINVOKE_AND_CLASSIC_COMINTEROP |	// Allow PInvoking from non-TPA assemblies
	APPDOMAIN_DISABLE_TRANSPARENCY_ENFORCEMENT;			// Entirely disables transparency checks 
```

After deciding which AppDomain flags to use, AppDomain properties must be defined. The properties are key/value pairs of strings. Many of the properties relate to how the AppDomain will load assemblies.

Common AppDomain properties include:

* `TRUSTED_PLATFORM_ASSEMBLIES` This is a list of assembly paths (delimited by ';' on Windows and ':' on Unix) which the AppDomain should prioritize loading and give full trust to (even in partially-trusted domains). This list is meant to contain 'Framework' assemblies and other trusted modules, similar to the GAC in .NET Framework scenarios. Some hosts will put any library next to coreclr.dll on this list, others have hard-coded manifests listing trusted assemblies for their purposes.
* `APP_PATHS` This is a list of paths to probe in for an assembly if it can't be found in the trusted platform assemblies (TPA) list. These paths are meant to be the locations where users' assemblies can be found. In a sandboxed AppDomain, assemblies loaded from these paths will only be granted partial trust. Common APP_PATH paths include the path the target app was loaded from or other locations where user assets are known to live.
*  `APP_NI_PATHS` This list is very similar to APP_PATHS except that it's meant to be paths that will be probed for native images.
*  `NATIVE_DLL_SEARCH_DIRECTORIES` This property is a list of paths the loader should probe in when looking for native DLLs called via p/invoke.
*  `PLATFORM_RESOURCE_ROOTS` This list includes paths to probe in for resource satellite assemblies (in culture-specific sub-directories).
*  `AppDomainCompatSwitch` This string specifies which compatibility quirks should be used for assemblies without an explicit Target Framework Moniker. Typically, this should be set to `"UseLatestBehaviorWhenTFMNotSpecified"` but some hosts may prefer to get older Silverlight or Windows Phone compatibility quirks, instead.

In our [simple sample host](https://github.com/dotnet/docs/tree/master/samples/core/hosting), these properties are setup as follows:

```C++
// TRUSTED_PLATFORM_ASSEMBLIES
int tpaSize = 100 * MAX_PATH; // Starting size for our TPA (Trusted Platform Assemblies) list
wchar_t* trustedPlatformAssemblies = new wchar_t[tpaSize];
trustedPlatformAssemblies[0] = L'\0';

// Extensions to probe for when finding TPA list files
wchar_t *tpaExtensions[] = {
	L"*.dll",
	L"*.exe",
	L"*.winmd"
};

// Probe next to CoreCLR.dll for any files matching the extensions from tpaExtensions and
// add them to the TPA list. In a real host, this would likely be extracted into a separate function
// and perhaps also run on other directories of interest.
for (int i = 0; i < _countof(tpaExtensions); i++)
{
	// Construct the file name search pattern
	wchar_t searchPath[MAX_PATH];
	wcscpy_s(searchPath, MAX_PATH, coreRoot);
	wcscat_s(searchPath, MAX_PATH, L"\\");
	wcscat_s(searchPath, MAX_PATH, tpaExtensions[i]);

	// Find files matching the search pattern
	WIN32_FIND_DATAW findData;
	HANDLE fileHandle = FindFirstFileW(searchPath, &findData);

	if (fileHandle != INVALID_HANDLE_VALUE)
	{
		do
		{
			// Construct the full path of the trusted assembly
			wchar_t pathToAdd[MAX_PATH];
			wcscpy_s(pathToAdd, MAX_PATH, coreRoot);
			wcscat_s(pathToAdd, MAX_PATH, L"\\");
			wcscat_s(pathToAdd, MAX_PATH, findData.cFileName);

			// Check to see if TPA list needs expanded
			if (wcslen(pathToAdd) + (3) + wcslen(trustedPlatformAssemblies) >= tpaSize)
			{
				// Expand, if needed
				tpaSize *= 2;
				wchar_t* newTPAList = new wchar_t[tpaSize];
				wcscpy_s(newTPAList, tpaSize, trustedPlatformAssemblies);
				trustedPlatformAssemblies = newTPAList;
			}

			// Add the assembly to the list and delimited with a semi-colon
			wcscat_s(trustedPlatformAssemblies, tpaSize, pathToAdd);
			wcscat_s(trustedPlatformAssemblies, tpaSize, L";");

			// Note that the CLR does not guarantee which assembly will be loaded if an assembly
			// is in the TPA list multiple times (perhaps from different paths or perhaps with different NI/NI.dll
			// extensions. Therefore, a real host should probably add items to the list in priority order and only
			// add a file if it's not already present on the list.
			//
			// For this simple sample, though, and because we're only loading TPA assemblies from a single path,
			// we can ignore that complication.
		}
		while (FindNextFileW(fileHandle, &findData));
		FindClose(fileHandle);
	}
}


// APP_PATHS
wchar_t appPaths[MAX_PATH * 50];

// Just use the targetApp provided by the user and remove the file name
wcscpy_s(appPaths, targetAppPath);


// APP_NI_PATHS
// For this sample, we probe next to the app and in a hypothetical directory of the same name with 'NI' suffixed to the end.
wchar_t appNiPaths[MAX_PATH * 50];
wcscpy_s(appNiPaths, targetAppPath);
wcscat_s(appNiPaths, MAX_PATH * 50, L";");
wcscat_s(appNiPaths, MAX_PATH * 50, targetAppPath);
wcscat_s(appNiPaths, MAX_PATH * 50, L"NI");


// NATIVE_DLL_SEARCH_DIRECTORIES
wchar_t nativeDllSearchDirectories[MAX_PATH * 50];
wcscpy_s(nativeDllSearchDirectories, appPaths);
wcscat_s(nativeDllSearchDirectories, MAX_PATH * 50, L";");
wcscat_s(nativeDllSearchDirectories, MAX_PATH * 50, coreRoot);


// PLATFORM_RESOURCE_ROOTS
wchar_t platformResourceRoots[MAX_PATH * 50];
wcscpy_s(platformResourceRoots, appPaths);


// AppDomainCompatSwitch
wchar_t* appDomainCompatSwitch = L"UseLatestBehaviorWhenTFMNotSpecified";
``` 

### Step 6 - Create the AppDomain
Once all AppDomain flags and properties are prepared, `ICLRRuntimeHost2::CreateAppDomainWithManager` can be used to setup the AppDomain. This function optionally takes a fully-qualified assembly name and type name to use as the domain's AppDomain manager. An AppDomain manager can allow a host to control some aspects of AppDomain behavior and may provide entry points for launching managed code if the host doesn't intend to invoke user code directly.   

```C++
DWORD domainId;

// Setup key/value pairs for AppDomain  properties
const wchar_t* propertyKeys[] = {
	L"TRUSTED_PLATFORM_ASSEMBLIES",
	L"APP_PATHS",
	L"APP_NI_PATHS",
	L"NATIVE_DLL_SEARCH_DIRECTORIES",
	L"PLATFORM_RESOURCE_ROOTS",
	L"AppDomainCompatSwitch"
};

// Property values which were constructed in step 5
const wchar_t* propertyValues[] = {
	trustedPlatformAssemblies,
	appPaths,
	appNiPaths,
	nativeDllSearchDirectories,
	platformResourceRoots,
	appDomainCompatSwitch
};

// Create the AppDomain
hr = runtimeHost->CreateAppDomainWithManager(
	L"Sample Host AppDomain",		// Friendly AD name
	appDomainFlags,
	NULL,							// Optional AppDomain manager assembly name
	NULL,							// Optional AppDomain manager type (including namespace)
	sizeof(propertyKeys)/sizeof(wchar_t*),
	propertyKeys,
	propertyValues,
	&domainId);
```

### Step 7 - Run managed code!
With an AppDomain up and running, the host can now start executing managed code. The easiest way to do this is to use `ICLRRuntimeHost2::ExecuteAssembly` to invoke a managed assembly's entry point method. Note that this function only works in single-domain scenarios.

```C++
DWORD exitCode = -1;
hr = runtimeHost->ExecuteAssembly(domainId, targetApp, argc - 1, (LPCWSTR*)(argc > 1 ? &argv[1] : NULL), &exitCode);
```

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

```C+++
runtimeHost->UnloadAppDomain(domainId, true /* Wait until unload complete */);
runtimeHost->Stop();
runtimeHost->Release();
``` 

## About Hosting .NET Core on Unix
.NET Core is a cross-platform product, running on Windows, Linux, and Mac operating systems. As native applications, though, hosts for different platforms will have some differences between them. The process described above of using `ICLRRuntimeHost2` to start the runtime, create an AppDomain, and execute managed code, should work on any supported operating system. However, the interfaces defined in mscoree.h can be cumbersome to work with on Unix platforms since mscoree makes many Win32 assumptions.

To make hosting on Unix platforms easier, a set of more platform-neutral hosting API wrappers are available in [coreclrhost.h](https://github.com/dotnet/coreclr/blob/master/src/coreclr/hosts/inc/coreclrhost.h).

An example of using coreclrhost.h (instead of mscoree.h directly) can be seen in the [UnixCoreRun host](https://github.com/dotnet/coreclr/tree/master/src/coreclr/hosts). The steps to use the APIs from coreclrhost.h to host the runtime are similar to the steps when using mscoree.h:

1. Identify the managed code to execute (from command line parameters, for example). 
2. Load the CoreCLR library.
	1. `dlopen("./libcoreclr.so", RTLD_NOW | RTLD_LOCAL);` 
3. Get function pointers to CoreCLR's `coreclr_initialize`, `coreclr_create_delegate`, `coreclr_execute_assembly`, and `coreclr_shutdown` functions using `dlsym`
	1. `coreclr_initialize_ptr coreclr_initialize = (coreclr_initialize_ptr)dlsym(coreclrLib, "coreclr_initialize");`
4. Setup AppDomain properties (such as the TPA list). This is the same as step 5 from the mscoree workflow, above.
5. Use `coreclr_initialize` to start the runtime and create an AppDomain. This will also create a `hostHandle` pointer which will be used in future hosting calls.
	1. Note that this function fills the roles of both steps 4 and 6 from the previous workflow. 
6. Use either `coreclr_execute_assembly` or `coreclr_create_delegate` to execute managed code. These functions are analogous to mscoree's `ExecuteAssembly` and `CreateDelegate` functions from step 7 of the previous workflow.
7. Use `coreclr_shutdown` to unload the AppDomain and shut down the runtime. 

## Conclusion
Once your host is built, it can be tested by running it from the command line and passing any arguments (like the managed app to run) the host expects. When specifying the .NET Core app for the host to run, be sure to use the .dll that is produced by `dotnet build`. Executables produced by `dotnet build` are actually the default .NET Core host (so that the app can be launched directly from the command line in mainline scenarios); user's code is compiled into a dll of the same name. 

If things don't work initially, double-check that coreclr.dll is available in the location expected by the host, that all necessary Framework libraries are in the TPA list, and that CoreCLR's bitness (32- or 64-bit) matches how the host was built.

Hosting the .NET Core runtime is an advanced scenario that many developers won't require, but for those who need to launch managed code from a native process, or who need more control over the .NET Core runtime's behavior, it can be very useful. Because .NET Core is able to run side-by-side with itself, it's even possible to create hosts which initialize and start multiple versions of the .NET Core runtime and execute apps on all of them in the same process. 