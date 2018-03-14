---
title: "ICorDebugHeapValue3::GetMonitorEventWaitList Method"
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
  - "ICorDebugHeapValue3.GetMonitorEventWaitList"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapValue3::GetMonitorEventWaitList"
helpviewer_keywords: 
  - "ICorDebugHeapValue3::GetMonitorEventWaitList method [.NET Framework debugging]"
  - "GetMonitorEventWaitList method [.NET Framework debugging]"
ms.assetid: 035a9035-ac66-4953-b48a-99652b42b7fe
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugHeapValue3::GetMonitorEventWaitList Method
Provides an ordered list of threads that are queued on the event that is associated with a monitor lock.  
  
## Syntax  
  
```  
HRESULT GetMonitorEventWaitList (  
    [out] ICorDebugThreadEnum **ppThreadEnum  
);  
```  
  
#### Parameters  
 `ppThreadEnum`  
 [out] The ICorDebugThreadEnum enumerator that provides the ordered list of threads.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The list is not empty.|  
|S_FALSE|The list is empty.|  
  
## Exceptions  
  
## Remarks  
 The first thread in the list is the first thread that is released by the next call to <xref:System.Threading.Monitor.Pulse%28System.Object%29?displayProperty=nameWithType>. The next thread in the list is released on the following call, and so on.  
  
 If the list is not empty, this method returns S_OK. If the list is empty, the method returns S_FALSE; in this case, the enumeration is still valid, although it is empty.  
  
 In either case, the enumeration interface is usable only for the duration of the current synchronized state. However, the thread's interfaces dispensed from it are valid until the thread exits.  
  
 If `ppThreadEnum` is not a valid pointer, the result is undefined.  
  
 If an error occurs such that it cannot be determined which, if any, threads are waiting for the monitor, the method returns an HRESULT that indicates failure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
