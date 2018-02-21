---
title: "ICorDebugGenericValue::GetValue Method"
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
  - "ICorDebugGenericValue.GetValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugGenericValue::GetValue"
helpviewer_keywords: 
  - "ICorDebugGenericValue::GetValue method [.NET Framework debugging]"
  - "GetValue method, ICorDebugGenericValue interface [.NET Framework debugging]"
ms.assetid: 4e95d7cb-144d-4ccf-8a69-d605f4744be2
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugGenericValue::GetValue Method
Copies the value of this generic into the specified buffer.  
  
## Syntax  
  
```  
HRESULT GetValue (  
    [out] void     *pTo  
);  
```  
  
#### Parameters  
 `pTo`  
 [out] A pointer to the value that is represented by this ICorDebugGenericValue object. The value may be a simple type or a reference type (that is, a pointer).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
