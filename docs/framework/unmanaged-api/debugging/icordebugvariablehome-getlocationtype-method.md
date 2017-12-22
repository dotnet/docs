---
title: "ICorDebugVariableHome::GetLocationType Method"
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
  - "ICorDebugVariableHome.GetLocationType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetLocationType"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetLocationType method [.NET Framework debugging]"
  - "GetLocationType method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: 88027c55-8ec6-4f1e-a55b-7eefdbbc3515
topic_type: 
  - "apiref"
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugVariableHome::GetLocationType Method
Gets the type of the variable's native location.  
  
## Syntax  
  
```  
HRESULT GetLocationType(  
    [out] VariableLocationType *pLocationType  
);  
```  
  
#### Parameters  
 `pLocationType`  
 [out] A pointer to the type of the variable's native location.  See the [VariableLocationType](../../../../docs/framework/unmanaged-api/debugging/variablelocationtype-enumeration.md) enumeration for more information.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)  
 [VariableLocationType Enumeration](../../../../docs/framework/unmanaged-api/debugging/variablelocationtype-enumeration.md)
