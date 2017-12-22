---
title: "ICorDebugGenericValue::SetValue Method"
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
  - "ICorDebugGenericValue.SetValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugGenericValue::SetValue"
helpviewer_keywords: 
  - "ICorDebugGenericValue::SetValue method [.NET Framework debugging]"
  - "SetValue method, ICorDebugGenericValue interface [.NET Framework debugging]"
ms.assetid: ed4c6458-0435-44fc-8e78-8ba00be362f2
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugGenericValue::SetValue Method
Copies a new value from the specified buffer.  
  
## Syntax  
  
```  
HRESULT SetValue (  
    [in] void      *pFrom  
);  
```  
  
#### Parameters  
 `pFrom`  
 [in] A pointer to the buffer from which to copy the value.  
  
## Remarks  
 For reference types, the value is the reference, not the content.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
