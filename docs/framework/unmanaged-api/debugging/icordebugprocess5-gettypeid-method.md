---
title: "ICorDebugProcess5::GetTypeID Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorDebugProcess5.GetTypeID"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugProcess5::GetTypeID"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugProcess5::GetTypeID method [.NET Framework debugging]"
  - "GetTypeID method, ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: 47dbaea4-8857-462e-93ba-fff880fc9e50
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugProcess5::GetTypeID Method
Converts an object address to a [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) identifier.  
  
## Syntax  
  
```vb  
HRESULT GetTypeID(  
    [in] CORDB_ADDRESS obj,  
    [out] COR_TYPEID *pId  
);  
```  
  
#### Parameters  
 `obj`  
 [in] The object address.  
  
 `pId`  
 A pointer to the [COR_TYPEID](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md) value that identifies the object.  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorDebugProcess5 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess5-interface.md)   
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)