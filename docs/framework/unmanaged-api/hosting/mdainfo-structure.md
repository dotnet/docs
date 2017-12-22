---
title: "MDAInfo Structure"
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
  - "MDAInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "MDAInfo"
helpviewer_keywords: 
  - "MDAInfo structure [.NET Framework hosting]"
ms.assetid: fb8c14f7-d461-43d1-8b47-adb6723b9b93
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MDAInfo Structure
Provides details about the `Event_MDAFired` event, which triggers the creation of a managed debugging assistant (MDA).  
  
## Syntax  
  
```  
typedef struct _MDAInfo {  
    LPCWSTR  lpMDACaption;  
    LPCWSTR  lpMDAMessage  
} MDAInfo;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`lpMDACaption`|The title of the current MDA. The title describes the kind of failure that triggered the `Event_MDAFired` event.|  
|`lpMDAMessage`|The output message provided by the current MDA.|  
  
## Remarks  
 Managed debugging assistants (MDAs) are debugging aids that work in conjunction with the common language runtime (CLR) to perform tasks such as identifying invalid conditions in the runtime execution engine or dumping additional information about the state of the engine. MDAs generate XML messages about events that are otherwise difficult to trap. They are especially useful for debugging transitions between managed and unmanaged code.  
  
 The runtime takes the following steps when an event that triggers the creation of an MDA is fired:  
  
-   If the host has not registered an [IActionOnCLREvent](../../../../docs/framework/unmanaged-api/hosting/iactiononclrevent-interface.md) instance by calling [ICLROnEventManager::RegisterActionOnEvent](../../../../docs/framework/unmanaged-api/hosting/iclroneventmanager-registeractiononevent-method.md) to be notified of an `Event_MDAFired` event, the runtime proceeds with its default, non-hosted behavior.  
  
-   If the host has registered a handler for this event, the runtime checks to see whether a debugger is attached to the process. If it is, the runtime breaks into the debugger. When the debugger continues, it calls into the host. If no debugger is attached, the runtime calls `IActionOnCLREvent::OnEvent` and passes a pointer to an `MDAInfo` instance as the `data` parameter.  
  
 The host can choose to activate MDAs and to be notified when an MDA is activated. This gives the host an opportunity to override default behavior and to abort the managed thread that raised the event, to prevent it from corrupting the process state. For more information about using MDAs, see [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Structures](../../../../docs/framework/unmanaged-api/hosting/hosting-structures.md)  
 [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
