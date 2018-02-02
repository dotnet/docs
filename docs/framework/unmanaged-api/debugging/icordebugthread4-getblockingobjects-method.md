---
title: "ICorDebugThread4::GetBlockingObjects Method"
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
  - "ICorDebugThread4.GetBlockingObjects Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread4::GetBlockingObjects"
helpviewer_keywords: 
  - "GetBlockingObjects method [.NET Framework debugging]"
  - "ICorDebugThread4::GetBlockingObjects method [.NET Framework debugging]"
ms.assetid: a7e6c54e-7be9-4e52-bbb4-95f52458e8e4
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread4::GetBlockingObjects Method
Provides an ordered enumeration of [CorDebugBlockingObject](../../../../docs/framework/unmanaged-api/debugging/cordebugblockingobject-structure.md) structures that provide thread blocking information.  
  
## Syntax  
  
```  
HRESULT GetBlockingObjects (  
    [out] ICorDebugBlockingObjectEnum **ppBlockingObjectEnum  
```  
  
#### Parameters  
 `ppBlockingObjectEnum`  
 [out] A pointer to an ordered enumeration of [CorDebugBlockingObject](../../../../docs/framework/unmanaged-api/debugging/cordebugblockingobject-structure.md) structures.  
  
## Remarks  
 The first element in the returned enumeration corresponds to the first structure that is blocking the thread. The second element corresponds to a blocking item that is encountered while running an asynchronous procedure call (APC) when blocked on the first, and so on.  
  
 The enumeration is valid only for the duration of the current synchronized state.  
  
 This method must be called while the debuggee is in a synchronized state.  
  
 If `ppBlockingObjectEnum` is not a valid pointer, the result is undefined.  
  
 If a thread is blocked and the error cannot be determined, the method returns an HRESULT that indicates failure; otherwise, it returns S_OK.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugThread4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugthread4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
