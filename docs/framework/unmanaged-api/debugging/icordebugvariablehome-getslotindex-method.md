---
title: "ICorDebugVariableHome::GetSlotIndex Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
api_name: 
  - "ICorDebugVariableHome.GetSlotIndex"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetSlotIndex"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetSlotIndex method [.NET Framework debugging]"
  - "GetSlotIndex method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: 966da50d-5665-4fff-bf7b-1c72bbadd9a4
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugVariableHome::GetSlotIndex Method
Gets the managed slot-index of a local variable.  
  
## Syntax  
  
```  
HRESULT GetSlotIndex(  
    [out] ULONG32 *pSlotIndex  
);  
```  
  
#### Parameters  
 `pSlotIndex`  
 [out] A pointer to the slot-index of a local variable.  
  
## Return Value  
 The method returns the following values.  
  
|Value|Description|  
|-----------|-----------------|  
|`S_OK`|The method call returned a slot-index value in `pSlotIndex`.|  
|`E_FAIL`|The current [ICorDebugVariableHome](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md) instance represents a function argument.|  
  
## Remarks  
 The slot-index can be used to retrieve the metadata for this local variable.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)
