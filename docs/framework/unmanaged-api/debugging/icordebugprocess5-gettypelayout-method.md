---
title: "ICorDebugProcess5::GetTypeLayout Method"
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
  - "ICorDebugProcess5.GetTypeLayout"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetTypeLayout"
helpviewer_keywords: 
  - "ICorDebugProcess5::GetTypeLayout method [.NET Framework debugging]"
  - "GetTypeLayout method, ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: bd62f5d1-e874-41f1-81e5-a29a7572c15d
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess5::GetTypeLayout Method
Gets information about the layout of an object in memory based on its type identifier.  
  
## Syntax  
  
```  
HRESULT GetTypeLayout(    [in] COR_TYPEID id,     [out] COR_TYPE_LAYOUT *pLayout);  
```  
  
#### Parameters  
 `id`  
 [in] A [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) token that specifies the type whose layout is desired.  
  
 `pLayout`  
 [out] A pointer to a [COR_TYPE_LAYOUT](../../../../docs/framework/unmanaged-api/debugging/cor-type-layout-structure.md) structure that contains information about the layout of the object in memory.  
  
## Remarks  
 The `ICorDebugProcess5::GetTypeLayout` method provides information about an object based on its [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md), which is returned by a number of other [ICorDebugProcess5](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-interface.md) methods. The information is provided by a [COR_TYPE_LAYOUT](../../../../docs/framework/unmanaged-api/debugging/cor-type-layout-structure.md) structure that is populated by the method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [COR_TYPE_LAYOUT Structure](../../../../docs/framework/unmanaged-api/debugging/cor-type-layout-structure.md)  
 [ICorDebugProcess5 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
