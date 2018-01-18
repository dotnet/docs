---
title: "ICorDebugVariableHome::GetArgumentIndex Method"
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
  - "ICorDebugVariableHome.GetArgumentIndex"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetArgumentIndex"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetArgumentiIndex method [.NET Framework debugging]"
  - "GetArgumentIndex method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: e86fcc72-388d-4009-ab21-8f9c3323e9a3
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugVariableHome::GetArgumentIndex Method
Gets the index of a function argument.  
  
## Syntax  
  
```  
HRESULT GetArgumentIndex(  
    [out] ULONG32* pArgumentIndex  
);  
```  
  
#### Parameters  
 `pArgumentIndex`  
 [out] A pointer to the argument index.  
  
## Return Value  
 The method returns the following values.  
  
|Value|Description|  
|-----------|-----------------|  
|`S_OK`|The method call returned a valid argument index.|  
|`E_FAIL`|The current [ICorDebugVariableHome](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md) instance represents a local variable.|  
  
## Remarks  
 The argument index can be used to retrieve metadata for this argument.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)
