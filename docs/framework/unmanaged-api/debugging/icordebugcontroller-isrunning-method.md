---
title: "ICorDebugController::IsRunning Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugController.IsRunning"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::IsRunning"
helpviewer_keywords: 
  - "IsRunning method [.NET Framework debugging]"
  - "ICorDebugController::IsRunning method [.NET Framework debugging]"
ms.assetid: b33ff059-40c4-4dfe-9cb2-21bfed2de0b0
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugController::IsRunning Method
Gets a value that indicates whether the threads in the process are currently running freely.  
  
## Syntax  
  
```  
HRESULT IsRunning (  
    [out] BOOL *pbRunning  
);  
```  
  
## Parameters  
 `pbRunning`  
 [out] A pointer to a value that is `true` if the threads in the process are running freely; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
