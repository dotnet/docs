---
title: "ICorDebugReferenceValue::Dereference Method"
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
  - "ICorDebugReferenceValue.Dereference"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugReferenceValue::Dereference"
helpviewer_keywords: 
  - "ICorDebugReferenceValue::Dereference method [.NET Framework debugging]"
  - "Dereference method [.NET Framework debugging]"
ms.assetid: 5ec8cf76-3deb-4ce6-9a49-77a4c35d80b9
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugReferenceValue::Dereference Method
Gets the object that is referenced.  
  
## Syntax  
  
```  
HRESULT Dereference (  
    [out] ICorDebugValue  **ppValue  
);  
```  
  
#### Parameters  
 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue that represents the object to which this ICorDebugReferenceValue object points.  
  
## Remarks  
 The `ICorDebugValue` object is valid only while its reference has not yet been disabled.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
