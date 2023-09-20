---
description: "Learn more about: GetStartupNotificationEvent Function"
title: "GetStartupNotificationEvent Function"
ms.date: "03/21/2022"
api_name: 
  - "GetStartupNotificationEvent"
api_location: 
  - "dbgshim.dll"
f1_keywords: 
  - "GetStartupNotificationEvent"
helpviewer_keywords: 
  - "GetStartupNotificationEvent function"
  - "debugging API [.NET Core]"
  - ".NET Core, debugging"
ms.assetid: c94b1b61-045a-4695-bacd-0f18c5acc246
topic_type: 
  - "apiref"
---
# GetStartupNotificationEvent Function

Creates or opens an event handle that will be signaled upon by any common language runtime (CLR) that is loading in the specified target process. This API is Windows only.
  
## Syntax  
  
```cpp  
HRESULT GetStartupNotificationEvent (  
    [in]  DWORD     debuggeePID,  
    [out]  HANDLE*  phStartupEvent  
);  
```  
  
## Parameters  

 `debuggeePID`\
 [in] Process identifier of the target process from which to receive CLR startup notifications.  
  
 `phStartupEvent`\
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

 **Platforms:** See [.NET Core supported operating systems](../../../core/install/windows.md?pivots=os-windows).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll  
  
 **.NET Versions:** [!INCLUDE[net_core_21](../../../../includes/net-core-21-md.md)]
