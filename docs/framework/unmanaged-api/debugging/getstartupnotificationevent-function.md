---
title: "GetStartupNotificationEvent Function"
ms.date: "03/30/2017"
api_name: 
  - "GetStartupNotificationEvent"
api_location: 
  - "dbgshim.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetStartupNotificationEvent"
helpviewer_keywords: 
  - "GetStartupNotificationEvent function"
  - "debugging API [Silverlight]"
  - "Silverlight, debugging"
ms.assetid: c94b1b61-045a-4695-bacd-0f18c5acc246
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# GetStartupNotificationEvent Function
Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process.  
  
## Syntax  
  
```  
HRESULT GetStartupNotificationEvent  
    (  
    [in]  DWORD     debuggeePID,  
    [out]  HANDLE*  phStartupEvent  
    );  
```  
  
## Parameters  
 `debuggeePID`  
 [in] Process identifier of the target process from which to receive CLR startup notifications.  
  
 `phStartupEvent`  
 [out] A pointer to a handle that will be signaled by a CLR on startup.  
  
## Return Value  
 S_OK  
 Successfully obtained the handle to the startup notification event.  
  
 E_INVALIDARG  
 `phStartupEvent` is null or `debuggeePID` does not refer to a process that is currently running.  
  
 E_FAIL (or other E_ return codes)  
 Unable to obtain the handle to the startup notification event.  
  
## Remarks  
 On the Windows operating system, `debuggeePID` maps to an OS process identifier.  
  
 The event is signaled before any managed code is executed by the CLR that signaled the event.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll  
  
 **.NET Framework Versions:** 3.5 SP1
