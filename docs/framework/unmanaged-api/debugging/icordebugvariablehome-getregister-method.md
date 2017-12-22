---
title: "ICorDebugVariableHome::GetRegister Method"
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
  - "ICorDebugVariableHome.GetRegister"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetRegister"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetRegister method [.NET Framework debugging]"
  - "GetRegister method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: a5eecd7b-b04c-4266-bff2-7c8771d519a8
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugVariableHome::GetRegister Method
Gets the register that contains a variable with a location type of `VLT_REGISTER`, and the base register for a variable with a location type of `VLT_REGISTER_RELATIVE`.  
  
## Syntax  
  
```  
HRESULT GetRegister(  
    [out] CorDebugRegister *pRegister  
);  
```  
  
#### Parameters  
 `pRegister`  
 [out] A CorDebugRegister enumeration value  that indicates the register for a variable with a location type of `VLT_REGISTER`, and the base register for a variable with a location type of `VLT_REGISTER_RELATIVE`.  
  
## Return Value  
 The method returns the following values:  
  
|Value|Description|  
|-----------|-----------------|  
|`S_OK`|The variable is in the register indicated by the `pRegister` argument.|  
|`E_FAIL`|The variable is not in a register or a register-relative location.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [VariableLocationType Enumeration](../../../../docs/framework/unmanaged-api/debugging/variablelocationtype-enumeration.md)  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)
