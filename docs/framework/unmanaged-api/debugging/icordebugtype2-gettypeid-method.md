---
title: "ICorDebugType2::GetTypeID Method"
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
  - "ICorDebugType2.GetTypeID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugType::GetTypeID"
helpviewer_keywords: 
  - "GetTypeID method, ICorDebugType2 interface [.NET Framework debugging]"
  - "ICorDebugType2.GetTypeID method [.NET Framework debugging]"
ms.assetid: 0b933686-226e-4373-92b7-fac579ee7b1a
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugType2::GetTypeID Method
Gets a [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) for this type.  
  
## Syntax  
  
```  
HRESULT GetTypeID(  
    ([out] COR_TYPEID *id  
);  
```  
  
#### Parameters  
 `id`  
 [out] A pointer to the [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) for this ICorDebugType.  
  
## Return Value  
 The return value is `S_OK` on success, or a failure `HRESULT` code on failure. The `HRESULT` codes include the following:  
  
|Return code|Description|  
|-----------------|-----------------|  
|`S_OK`|Method succeeded. The method has retrieved a valid [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md).|  
|`CORDBG_E_CLASS_NOT_LOADED`|The type has not been loaded.|  
|`CORDBG_E_UNSUPPORTED`|The type is not supported.|  
  
## Remarks  
 This method provides a mapping from the ICorDebugType, which represents a type that may or may not have been loaded into the runtime, to a [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md), which serves as an opaque handle that identifies a type loaded into the runtime.  
  
 When the type that the ICorDebugType represents has not yet been loaded, this method returns `CORDBG_E_CLASS_NOT_LOADED`.  If the type is not supported, it returns `CORDBG_E_UNSUPPORTED`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [ICorDebugType2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugtype2-interface.md)
