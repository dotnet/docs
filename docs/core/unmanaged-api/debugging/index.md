---
description: "Learn more about unmanaged APIs for debugging .NET"
title: .NET debugging (unmanaged API reference)
ms.date: 09/19/2023
---
# .NET debugging (unmanaged API reference)

The articles in this section describe the unmanaged APIs that the common language runtime (CLR) provides to support debugging .NET applications that are running on Windows, Linux, or macOS operating systems.

These articles describe APIs that were introduced in .NET Core 2.0 and later versions. For .NET Framework-era unmanaged APIs, most of which can also be used to debug .NET (Core) apps, see [.NET Framework debugging](../../../framework/unmanaged-api/debugging/index.md).

## Functions

[CloseCLREnumeration function](closeclrenumeration-function.md)\
Closes any valid CLR continue-startup events located in an array of handles returned by the [EnumerateCLRs function](enumerateclrs-function.md), and frees the memory for the handle and string path arrays.

[CloseResumeHandle function](closeresumehandle-function.md)\
Closes the handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

[CLRCreateInstance function](clrcreateinstance-function.md)\
Provides the [ICLRDebugging](../../../framework/unmanaged-api/debugging/iclrdebugging-interface.md) interface.

[CreateDebuggingInterfaceFromVersion function](createdebugginginterfacefromversion-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersionEx function](createdebugginginterfacefromversionex-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersion2 function](createdebugginginterfacefromversion2-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersion3 function](createdebugginginterfacefromversion3-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateProcessForLaunch function](createprocessforlaunch-function.md)\
A subset of the Windows CreateProcess that can be supported cross-platform.

[CreateVersionStringFromModule function](createversionstringfrommodule-function.md)\
Creates a version string from a CLR path in a target process.

[EnumerateCLRs function](enumerateclrs-function.md)\
Provides a mechanism for enumerating the CLRs in a process.

[GetStartupNotificationEvent function](getstartupnotificationevent-function.md)\
Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.

[RegisterForRuntimeStartup function](registerforruntimestartup-function.md)\
Executes the callback when the .NET runtime starts in the specified process.

[RegisterForRuntimeStartupEx function](registerforruntimestartupex-function.md)\
Executes the callback when the .NET runtime starts in the specified process.

[RegisterForRuntimeStartup3 function](registerforruntimestartup3-function.md)\
Executes the callback when the .NET runtime starts in the specified process.

[ResumeProcess function](resumeprocess-function.md)\
Resumes the process using the resume handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

[UnregisterForRuntimeStartup function](unregisterforruntimestartup-function.md)\
Stops/cancels runtime startup notification.

## Function pointers

[PSTARTUP_CALLBACK function pointer](pstartup_callback-function-pointer.md)\
Points to a function that's called when the .NET runtime has started for the [RegisterForRuntimeStartup](registerforruntimestartup-function.md) API.

## Enumerations

[LIBRARY_PROVIDER_INDEX_TYPE enumeration](libraryproviderindextype-enumeration.md)\
The type of index information passed to the library provider is either the identity of the requested module or of the runtime (coreclr) module.

## Interfaces

[ICLRDebuggingLibraryProvider2 interface](iclrdebugginglibraryprovider2-interface.md)\
Includes the [ProvideLibrary2](iclrdebugginglibraryprovider2-providelibrary2-method.md) method, which allows the debugger to provide a path to a version-specific debugging library.

[ICLRDebuggingLibraryProvider3 interface](iclrdebugginglibraryprovider3-interface.md)\
Includes callback methods that allow common language runtime version-specific debugging libraries to be located and loaded on demand for .NET regular and single-file applications.
