---
title: "ICorDebugVariableHome::GetOffset Method"
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
  - "ICorDebugVariableHome.GetOffset"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetOffset"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetOffset method [.NET Framework debugging]"
  - "GetOffset method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: f025c2e5-3f6c-4be8-9ffe-c8b214617dfe
topic_type: 
  - "apiref"
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugVariableHome::GetOffset Method
Gets the offset from the base register for a variable.  
  
## Syntax  
  
```  
HRESULT GetOffset(  
    [out] LONG *pOffset  
);  
```  
  
#### Parameters  
 `pOffset`  
 [out] The offset from the base register.  
  
## Return Value  
 The method returns the following values:  
  
|Value|Description|  
|-----------|-----------------|  
|`S_OK`|The variable is in a register-relative memory location.|  
|`E_FAIL`|The variable is not in a register-relative memory location.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)
