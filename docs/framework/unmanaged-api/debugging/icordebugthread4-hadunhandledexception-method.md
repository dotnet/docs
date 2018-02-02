---
title: "ICorDebugThread4::HadUnhandledException Method"
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
  - "ICorDebugThread4.HadUnhandledException Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread4::HadUnhandledException"
helpviewer_keywords: 
  - "ICorDebugThread4::HadUnhandledException method [.NET Framework debugging]"
  - "HadUnhandledException method [.NET Framework debugging]"
ms.assetid: 05558daa-39e2-4c38-aeaf-e2aec4a09468
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread4::HadUnhandledException Method
Indicates whether the thread has ever had an unhandled exception.  
  
## Syntax  
  
```  
HRESULT GetBlockingObjects (  
    [out] ICorDebugBlockingObjectEnum **ppBlockingObjectEnum  
    );  
```  
  
#### Parameters  
 `ppBlockingObjectEnum`  
 [out] A pointer to the address of an ordered enumeration of [CorDebugBlockingObject](../../../../docs/framework/unmanaged-api/debugging/cordebugblockingobject-structure.md) structures.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The thread has had an unhandled exception since its creation.|  
|S_FALSE|The thread has never had an unhandled exception.|  
  
## Remarks  
 This method indicates whether the thread has ever had an unhandled exception. By the time the unhandled exception callback is triggered or native JIT-attach is initiated, this method is guaranteed to return S_OK. There is no guarantee that the [ICorDebugThread.GetCurrentException](../../../../docs/framework/unmanaged-api/debugging/icordebugthread-getcurrentexception-method.md) method will return the unhandled exception; however, it will if the process has not yet been continued after getting the unhandled exception callback or upon native JIT-attach. Furthermore, it is possible (although unlikely) to have more than one thread with an unhandled exception at the time native JIT-attach is triggered. In such a case there is no way to determine which exception triggered the JIT-attach.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugThread4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugthread4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
