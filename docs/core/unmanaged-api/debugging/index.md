---
description: "Learn more about unmanaged APIs for debugging .NET"
title: .NET debugging (unmanaged API reference)
ms.date: 09/19/2023
---
# .NET debugging (unmanaged API reference)

The articles in this section describe the unmanaged APIs that the common language runtime (CLR) provides to support debugging .NET applications that are running on Windows, Linux, or macOS operating systems.

## In this section

[CreateProcessForLaunch function](createprocessforlaunch-function.md)\
A subset of the Windows CreateProcess that can be supported cross-platform.

[ResumeProcess function](resumeprocess-function.md)\
Resumes the process using the resume handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

[CloseResumeHandle function](closeresumehandle-function.md)\
Closes the handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

[RegisterForRuntimeStartup function](registerforruntimestartup-function.md)\
Executes the callback when the .NET Core runtime starts in the specified process.

[RegisterForRuntimeStartupEx function](registerforruntimestartupex-function.md)\
Executes the callback when the .NET Core runtime starts in the specified process.

[RegisterForRuntimeStartup3 function](registerforruntimestartup3-function.md)\
Executes the callback when the .NET Core runtime starts in the specified process.

[UnregisterForRuntimeStartup function](unregisterforruntimestartup-function.md)\
Stops/cancels runtime startup notification.

[EnumerateCLRs function](enumerateclrs-function.md)\
Provides a mechanism for enumerating the CLRs in a process.

[CloseCLREnumeration function](closeclrenumeration-function.md)\
Closes any valid CLR continue-startup events located in an array of handles returned by the [EnumerateCLRs function](enumerateclrs-function.md), and frees the memory for the handle and string path arrays.

[CreateVersionStringFromModule function](createversionstringfrommodule-function.md)\
Creates a version string from a CLR path in a target process.

[CreateDebuggingInterfaceFromVersion function](createdebugginginterfacefromversion-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersionEx function](createdebugginginterfacefromversionex-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersion2 function](createdebugginginterfacefromversion2-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.

[CreateDebuggingInterfaceFromVersion3 function](createdebugginginterfacefromversion3-function.md)\
Accepts a CLR version string returned from the [CreateVersionStringFromModule function](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.

[GetStartupNotificationEvent function](getstartupnotificationevent-function.md)\
Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.

[CLRCreateInstance function](clrcreateinstance-function.md)\
Provides the [ICLRDebugging](iclrdebugging-interface.md) interface.

## See also

- [.NET Framework debugging (unmanaged API reference)](../../../framework/unmanaged-api/debugging/index.md)
