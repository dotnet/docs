---
title: "ICorDebugController::IsRunning Method"
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
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugController::IsRunning Method
Gets a value that indicates whether the threads in the process are currently running freely.  
  
## Syntax  
  
```  
HRESULT IsRunning (  
    [out] BOOL *pbRunning  
);  
```  
  
#### Parameters  
 `pbRunning`  
 [out] A pointer to a value that is `true` if the threads in the process are running freely; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
