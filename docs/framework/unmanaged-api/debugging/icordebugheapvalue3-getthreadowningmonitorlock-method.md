---
title: "ICorDebugHeapValue3::GetThreadOwningMonitorLock Method"
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
  - "ICorDebugHeapValue3.GetThreadOwningMonitorLock"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapValue3::GetThreadOwningMonitorLock"
helpviewer_keywords: 
  - "GetThreadOwningMonitorLock method [.NET Framework debugging]"
  - "ICorDebugHeapValue3::GetThreadOwningMonitorLock method [.NET Framework debugging]"
ms.assetid: e06fc19d-2cf4-4cad-81a3-137a68af8969
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugHeapValue3::GetThreadOwningMonitorLock Method
Returns the managed thread that owns the monitor lock on this object.  
  
## Syntax  
  
```  
HRESULT GetThreadOwningMonitorLock (  
    [out] ICorDebugThread   **ppThread,  
    [out] DWORD              *pAcquisitionCount  
);  
```  
  
#### Parameters  
 `ppThread`  
 [out] The managed thread that owns the monitor lock on this object.  
  
 `pAcquisitionCount`  
 [out] The number of times this thread would have to release the lock before it returns to being unowned.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|S_FALSE|No managed thread owns the monitor lock on this object.|  
  
## Exceptions  
  
## Remarks  
 If a managed thread owns the monitor lock on this object:  
  
-   The method returns S_OK.  
  
-   The thread object is valid until the thread exits.  
  
 If no managed thread owns the monitor lock on this object, `ppThread` and `pAcquisitionCount` are unchanged, and the method returns S_FALSE.  
  
 If `ppThread` or `pAcquisitionCount` is not a valid pointer, the result is undefined.  
  
 If an error occurs such that it cannot be determined which, if any, thread owns the monitor lock on this object, the method returns an HRESULT that indicates failure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
