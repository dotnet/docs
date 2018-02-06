---
title: "Silverlight Debugging"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "debugging API [Silverlight]"
  - "Silverlight, debugging"
ms.assetid: 5e903e04-17d0-4014-ac9a-a43330ec8b1c
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Silverlight Debugging
The topics in this section describe the environment and interfaces that the common language runtime (CLR) provides to support debugging Silverlight-based applications that are running on the Windows operating system, or on the Macintosh platform.  
  
## In This Section  
 [EnumerateCLRs Function](../../../../docs/framework/unmanaged-api/debugging/enumerateclrs-function.md)  
 Provides a mechanism for enumerating the CLRs in a process.  
  
 [CloseCLREnumeration Function](../../../../docs/framework/unmanaged-api/debugging/closeclrenumeration-function.md)  
 Closes any valid CLR continue-startup events located in an array of handles returned by the [EnumerateCLRs Function](../../../../docs/framework/unmanaged-api/debugging/enumerateclrs-function.md), and frees the memory for the handle and string path arrays.  
  
 [CreateCoreClrDebugTarget Function](../../../../docs/framework/unmanaged-api/debugging/createcoreclrdebugtarget-function.md)  
 Creates a connection to a remote target for process and runtime enumeration.  
  
 [CreateCordbObject Function](../../../../docs/framework/unmanaged-api/debugging/createcordbobject-function.md)  
 Creates a debugger interface that provides functionality for instantiating a managed debugging session on a remote process.  
  
 [CreateVersionStringFromModule Function](../../../../docs/framework/unmanaged-api/debugging/createversionstringfrommodule-function.md)  
 Creates a version string from a CLR path in a target process.  
  
 [CreateDebuggingInterfaceFromVersion Function](../../../../docs/framework/unmanaged-api/debugging/createdebugginginterfacefromversion-function-for-silverlight.md)  
 Accepts a CLR version string returned from [CreateVersionStringFromModule Function](../../../../docs/framework/unmanaged-api/debugging/createversionstringfrommodule-function.md)function, and returns a corresponding debugger interface.  
  
 [CoreClrDebugProcInfo Structure](../../../../docs/framework/unmanaged-api/debugging/coreclrdebugprocinfo-structure.md)  
 Represents a process that is running on a remote machine.  
  
 [CoreClrDebugRuntimeInfo Structure](../../../../docs/framework/unmanaged-api/debugging/coreclrdebugruntimeinfo-structure.md)  
 Represents a CLR instance that is loaded in a process on a remote machine.  
  
 [GetStartupNotificationEvent Function](../../../../docs/framework/unmanaged-api/debugging/getstartupnotificationevent-function.md)  
 Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.  
  
 [ICoreClrDebugTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-interface.md)  
 Creates a connection to a remote target for process and runtime enumeration.  
  
 [InitDbgTransportManager Function](../../../../docs/framework/unmanaged-api/debugging/initdbgtransportmanager-function.md)  
 Initializes the transport manager to connect to a remote target for process and runtime enumeration.  
  
 [ShutdownDbgTransportManager Function](../../../../docs/framework/unmanaged-api/debugging/shutdowndbgtransportmanager-function.md)  
 Shuts down the transport manager for a connection to a remote target machine.  
  
## See Also  
 [Debugging Coclasses](../../../../docs/framework/unmanaged-api/debugging/debugging-coclasses.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
