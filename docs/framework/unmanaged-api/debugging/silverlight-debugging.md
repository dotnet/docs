---
description: "Learn more about: Silverlight Debugging"
title: "Silverlight Debugging"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "debugging API [Silverlight]"
  - "Silverlight, debugging"
ms.assetid: 5e903e04-17d0-4014-ac9a-a43330ec8b1c
---
# Silverlight Debugging

The topics in this section describe the environment and interfaces that the common language runtime (CLR) provides to support debugging Silverlight-based applications that are running on the Windows operating system, or on the Macintosh platform.  
  
## In This Section  

 [EnumerateCLRs Function](enumerateclrs-function-for-silverlight.md)  
 Provides a mechanism for enumerating the CLRs in a process.  
  
 [CloseCLREnumeration Function](closeclrenumeration-function-for-silverlight.md)  
 Closes any valid CLR continue-startup events located in an array of handles returned by the [EnumerateCLRs Function](enumerateclrs-function.md), and frees the memory for the handle and string path arrays.  
  
 [CreateCoreClrDebugTarget Function](createcoreclrdebugtarget-function.md)  
 Creates a connection to a remote target for process and runtime enumeration.  
  
 [CreateCordbObject Function](createcordbobject-function.md)  
 Creates a debugger interface that provides functionality for instantiating a managed debugging session on a remote process.  
  
 [CreateVersionStringFromModule Function](createversionstringfrommodule-function-for-silverlight.md)  
 Creates a version string from a CLR path in a target process.  
  
 [CreateDebuggingInterfaceFromVersion Function](createdebugginginterfacefromversion-function-for-silverlight.md)  
 Accepts a CLR version string returned from [CreateVersionStringFromModule](createversionstringfrommodule-function.md) function, and returns a corresponding debugger interface.  
  
 [CoreClrDebugProcInfo Structure](coreclrdebugprocinfo-structure.md)  
 Represents a process that is running on a remote machine.  
  
 [CoreClrDebugRuntimeInfo Structure](coreclrdebugruntimeinfo-structure.md)  
 Represents a CLR instance that is loaded in a process on a remote machine.  
  
 [GetStartupNotificationEvent Function](getstartupnotificationevent-function-for-silverlight.md)  
 Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.  
  
 [ICoreClrDebugTarget Interface](icoreclrdebugtarget-interface.md)  
 Creates a connection to a remote target for process and runtime enumeration.  
  
 [InitDbgTransportManager Function](initdbgtransportmanager-function.md)  
 Initializes the transport manager to connect to a remote target for process and runtime enumeration.  
  
 [ShutdownDbgTransportManager Function](shutdowndbgtransportmanager-function.md)  
 Shuts down the transport manager for a connection to a remote target machine.  
  
## See also

- [Debugging Coclasses](debugging-coclasses.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging Global Static Functions](debugging-global-static-functions.md)
- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging Structures](debugging-structures.md)
