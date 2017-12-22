---
title: "ICorDebugThreadEnum::Next Method"
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
  - "ICorDebugThreadEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThreadEnum::Next"
helpviewer_keywords: 
  - "ICorDebugThreadEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugThreadEnum interface [.NET Framework debugging]"
ms.assetid: f967c93d-9a7f-4aaf-99a1-a1317899ff3f
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThreadEnum::Next Method
Gets the number of specified ICorDebugThread instances from the enumeration, starting at the current position.  
  
## Syntax  
  
```  
HRESULT Next (  
    [in] ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugThread *threads[],  
    [out] ULONG *pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of `ICorDebugThread` instances to be retrieved.  
  
 `threads`  
 [out] An array of pointers, each of which points to an `ICorDebugThread` object that represents a thread.  
  
 `pceltFetched`  
 [out] Pointer to the number of `ICorDebugThread` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
