---
description: "Learn more about: CLR_DEBUGGING_PROCESS_FLAGS Enumeration"
title: "CLR_DEBUGGING_PROCESS_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CLR_DEBUGGING_PROCESS_FLAGS"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CLR_DEBUGGING_PROCESS_FLAG"
helpviewer_keywords: 
  - "CLR_DEBUGGING_PROCESS_FLAGS enumeration [.NET Framework debugging]"
ms.assetid: 85b85fde-1f87-490b-ba8d-d604670959c3
topic_type: 
  - "apiref"
---
# CLR_DEBUGGING_PROCESS_FLAGS Enumeration

Provides values that are used by the [ICLRDebugging::OpenVirtualProcess](iclrdebugging-openvirtualprocess-method.md) method.  
  
## Syntax  
  
```cpp  
typedef enum CLR_DEBUGGING_PROCESS_FLAGS  
{  
   CLR_DEBUGGING_MANAGED_EVENT_PENDING = 1,  
   CLR_DEBUGGING_MANAGED_EVENT_DEBUGGER_LAUNCH = 2  
}  CLR_DEBUGGING_PROCESS_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CLR_DEBUGGING_MANAGED_EVENT_PENDING`|This runtime has a non-catch-up managed debugger event to send. See the Remarks section for the distinction between catch-up and non-catch-up events.|  
|`CLR_DEBUGGING_MANAGED_EVENT_DEBUGGER_LAUNCH`|The managed event that is pending is a <xref:System.Diagnostics.Debugger.Launch%2A?displayProperty=nameWithType> request.|  
  
## Remarks  

 Catch-up events include process, application domain, assembly, module, and thread creation notifications that bring the debugger up to the current state after it has attached to a process. Non-catch-up events, which are indicated by the `CLR_DEBUGGING_MANAGED_EVENT_PENDING` flag, include all other debugger events, such as exceptions and managed debugging assistant (MDA) notifications.  
  
 The `CLR_DEBUGGING_MANAGED_EVENT_DEBUGGER_LAUNCH` flag enables the runtime to differentiate between a terminating exception and a request to attach a managed debugger that can be canceled.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Metahost.idl, Metahost.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
