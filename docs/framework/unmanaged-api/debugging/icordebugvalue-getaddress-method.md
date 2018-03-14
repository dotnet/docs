---
title: "ICorDebugValue::GetAddress Method"
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
  - "ICorDebugValue.GetAddress"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue::GetAddress"
helpviewer_keywords: 
  - "ICorDebugValue::GetAddress method [.NET Framework debugging]"
  - "GetAddress method, ICorDebugValue interface [.NET Framework debugging]"
ms.assetid: a247c792-45e1-4538-9e1f-b46acca4a463
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugValue::GetAddress Method
Gets the address of this "ICorDebugValue" object, which is in the process of being debugged.  
  
## Syntax  
  
```  
HRESULT GetAddress (  
    [out] CORDB_ADDRESS   *pAddress  
);  
```  
  
#### Parameters  
 `pAddress`  
 [out] Pointer to a `CORDB_ADDRESS` object that specifies the address of this value object.  
  
## Remarks  
 If the value is unavailable, 0 (zero) is returned. This could happen if the value is at least partly in registers or stored in a garbage collector handle (`GCHandle`).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
