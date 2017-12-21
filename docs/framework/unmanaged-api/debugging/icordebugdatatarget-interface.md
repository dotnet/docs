---
title: "ICorDebugDataTarget Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugDataTarget"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugDataTarget"
helpviewer_keywords: 
  - "ICorDebugDataTarget interface [.NET Framework debugging]"
ms.assetid: df5f05be-bed7-4f3c-bc89-dbb435d79a0b
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugDataTarget Interface
Provides a callback interface that provides access to a particular target process.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetPlatform Method](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-getplatform-method.md)|Provides information about the platform, including processor architecture and operating system, on which the target process is running.|  
|[ReadVirtual Method](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-readvirtual-method.md)|Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.|  
|[GetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-getthreadcontext-method.md)|Requests the current thread context for the specified thread.|  
  
## Remarks  
 `ICorDebugDataTarget` and its methods have the following characteristics:  
  
-   The debugging services call methods on this interface to access memory and other data in the target process.  
  
-   The debugger client must implement this interface as appropriate for the particular target (for example, a live process or a memory dump).  
  
-   The `ICorDebugDataTarget` methods can be invoked only from within methods implemented in other `ICorDebug*` interfaces. This ensures that the debugger client has control over which thread it is invoked on, and when.  
  
-   The `ICorDebugDataTarget` implementation must always return up-to-date information about the target.  
  
 The target process should be stopped and not changed in any way while `ICorDebug*` interfaces (and therefore `ICorDebugDataTarget` methods) are being called. If the target is a live process and its state changes, the [ICLRDebugging::OpenVirtualProcess](../../../../docs/framework/unmanaged-api/debugging/iclrdebugging-openvirtualprocess-method.md) method has to be called again to provide a replacement ICorDebugProcess instance.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
