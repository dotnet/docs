---
title: "ICorDebug::GetProcess Method"
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
  - "ICorDebug.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug::GetProcess"
helpviewer_keywords: 
  - "GetProcess method, ICorDebug interface [.NET Framework debugging]"
  - "ICorDebug::GetProcess method [.NET Framework debugging]"
ms.assetid: 10a40ba0-1b65-4721-bd11-cf12d57b280d
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebug::GetProcess Method
Gets a pointer to the "ICorDebugProcess" instance for the specified process.  
  
## Syntax  
  
```  
HRESULT GetProcess (  
    [in] DWORD               dwProcessId,  
    [out] ICorDebugProcess   **ppProcess  
);  
```  
  
#### Parameters  
 `dwProcessId`  
 [in] The ID of the process.  
  
 `ppProcess`  
 [out] A pointer to the address of a `ICorDebugProcess` instance for the specified process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
