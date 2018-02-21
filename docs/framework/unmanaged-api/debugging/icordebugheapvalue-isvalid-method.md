---
title: "ICorDebugHeapValue::IsValid Method"
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
  - "ICorDebugHeapValue.IsValid"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapValue::IsValid"
helpviewer_keywords: 
  - "IsValid method [.NET Framework debugging]"
  - "ICorDebugHeapValue::IsValid method [.NET Framework debugging]"
ms.assetid: 68e20e62-203d-46d8-bb91-8d3c61cfacc3
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugHeapValue::IsValid Method
Gets a value that indicates whether the object represented by this ICorDebugHeapValue is valid.  
  
 This method has been deprecated in the .NET Framework version 2.0.  
  
## Syntax  
  
```  
HRESULT IsValid (  
    [out] BOOL    *pbValid  
);  
```  
  
#### Parameters  
 `pbValid`  
 [out] A pointer to a Boolean value that indicates whether this value on the heap is valid.  
  
## Remarks  
 The value is invalid if it has been reclaimed by the garbage collector.  
  
 This method has been deprecated. In the .NET Framework 2.0, all values are valid until [ICorDebugController::Continue](../../../../docs/framework/unmanaged-api/debugging/icordebugcontroller-continue-method.md) is called, at which time the values are invalidated.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
