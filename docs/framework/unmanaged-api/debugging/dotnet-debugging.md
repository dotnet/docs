---
description: "Learn more about: .NET Core Debugging"
title: ".NET Core Debugging"
ms.date: "03/21/2022"
helpviewer_keywords: 
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
ms.assetid: 5e903e04-17d0-4014-ac9a-a43330ec8b1c
---
# .NET Core Debugging

The topics in this section describe the environment and interfaces that the common language runtime (CLR) provides to support debugging .NET applications that are running on the Windows, Linux or macOS operating systems.
  
## In This Section  

 [CreateProcessForLaunch Function](createprocessforlaunch-function.md)  
 A subset of the Windows CreateProcess that can be supported cross-platform.

 [ResumeProcess Function](resumeprocess-function.md)  
 Resumes the process using the resume handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

 [CloseResumeHandle Function](closeresumehandle-function.md)  
 Closes the handle returned by the [CreateProcessForLaunch function](createprocessforlaunch-function.md).

 [RegisterForRuntimeStartup Function](registerforruntimestartup-function.md)  
 Executes the callback when the .NET Core runtime starts in the specified process.

 [RegisterForRuntimeStartupEx Function](registerforruntimestartupex-function.md)  
 Executes the callback when the .NET Core runtime starts in the specified process.

 [RegisterForRuntimeStartup3 Function](registerforruntimestartup3-function.md)  
 Executes the callback when the .NET Core runtime starts in the specified process.

 [UnregisterForRuntimeStartup Function](unregisterforruntimestartup-function.md)  
 Stops/cancels runtime startup notification.

 [EnumerateCLRs Function](enumerateclrs-function.md)  
 Provides a mechanism for enumerating the CLRs in a process.  
  
 [CloseCLREnumeration Function](closeclrenumeration-function.md)  
 Closes any valid CLR continue-startup events located in an array of handles returned by the [EnumerateCLRs Function](enumerateclrs-function.md), and frees the memory for the handle and string path arrays.  
  
 [CreateVersionStringFromModule Function](createversionstringfrommodule-function.md)  
 Creates a version string from a CLR path in a target process.  
  
 [CreateDebuggingInterfaceFromVersion Function](createdebugginginterfacefromversion-function.md)  
 Accepts a CLR version string returned from [CreateVersionStringFromModule Function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.  

 [CreateDebuggingInterfaceFromVersionEx Function](createdebugginginterfacefromversionex-function.md)  
 Accepts a CLR version string returned from [CreateVersionStringFromModule Function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.  

 [CreateDebuggingInterfaceFromVersion2 Function](createdebugginginterfacefromversion2-function.md)  
 Accepts a CLR version string returned from [CreateVersionStringFromModule Function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.  

 [CreateDebuggingInterfaceFromVersion3 Function](createdebugginginterfacefromversion3-function.md)  
 Accepts a CLR version string returned from [CreateVersionStringFromModule Function](createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.  
  
 [GetStartupNotificationEvent Function](getstartupnotificationevent-function.md)  
 Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.  
  
 [CLRCreateInstance Function](clrcreateinstance-function.md)  
 Provides the [ICLRDebugging](iclrdebugging-interface.md) interface.

## See also

- [Debugging Coclasses](debugging-coclasses.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging Global Static Functions](debugging-global-static-functions.md)
- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging Structures](debugging-structures.md)
