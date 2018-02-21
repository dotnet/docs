---
title: "ICorDebugFunction::GetClass Method"
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
  - "ICorDebugFunction.GetClass"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetClass"
helpviewer_keywords: 
  - "GetClass method, ICorDebugFunction interface [.NET Framework debugging]"
  - "ICorDebugFunction::GetClass method [.NET Framework debugging]"
ms.assetid: 27967230-144f-40d3-9e23-961d0241abd9
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction::GetClass Method
Gets an ICorDebugClass object that represents the class this function is a member of.  
  
## Syntax  
  
```  
HRESULT GetClass (  
    [out] ICorDebugClass **ppClass  
);  
```  
  
#### Parameters  
 `ppClass`  
 [out] A pointer to the address of the `ICorDebugClass` object that represents the class, or null, if this function is not a member of a class.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
