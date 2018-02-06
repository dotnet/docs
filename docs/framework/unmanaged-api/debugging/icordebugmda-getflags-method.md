---
title: "ICorDebugMDA::GetFlags Method"
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
  - "ICorDebugMDA.GetFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugMDA::GetFlags"
helpviewer_keywords: 
  - "ICorDebugMDA::GetFlags method [.NET Framework debugging]"
  - "GetFlags method [.NET Framework debugging]"
ms.assetid: 87ce7c5b-fd82-453e-bf55-c8a32150b183
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugMDA::GetFlags Method
Gets the flags associated with the managed debugging assistant (MDA) represented by [ICorDebugMDA](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md).  
  
## Syntax  
  
```  
HRESULT GetFlags (  
    [in] CorDebugMDAFlags *pFlags  
);  
```  
  
#### Parameters  
 `pFlags`  
 [in] A bitwise combination of the [CorDebugMDAFlags](../../../../docs/framework/unmanaged-api/debugging/cordebugmdaflags-enumeration.md) enumeration values that specify the settings of the flags for this MDA.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugMDA Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md)  
 [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
