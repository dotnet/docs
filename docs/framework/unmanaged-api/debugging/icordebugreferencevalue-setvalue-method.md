---
title: "ICorDebugReferenceValue::SetValue Method"
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
  - "ICorDebugReferenceValue.SetValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugReferenceValue::SetValue"
helpviewer_keywords: 
  - "SetValue method, ICorDebugReferenceValue interface [.NET Framework debugging]"
  - "ICorDebugReferenceValue::SetValue method [.NET Framework debugging]"
ms.assetid: 3d3f6eec-d772-401f-a028-1a2ecdc31e95
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugReferenceValue::SetValue Method
Sets the specified memory address. That is, this method sets this ICorDebugReferenceValue to point to an object.  
  
## Syntax  
  
```  
HRESULT SetValue (  
    [in] CORDB_ADDRESS    value  
);  
```  
  
#### Parameters  
 `value`  
 [in] A `CORDB_ADDRESS` value that specifies the address of the object to which this `ICorDebugReferenceValue` points.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
