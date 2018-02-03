---
title: "ICorDebugClass2::SetJMCStatus Method"
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
  - "ICorDebugClass2.SetJMCStatus"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass2::SetJMCStatus"
helpviewer_keywords: 
  - "ICorDebugClass2::SetJMCStatus method [.NET Framework debugging]"
  - "SetJMCStatus method, ICorDebugClass2 interface [.NET Framework debugging]"
ms.assetid: 077e6c7f-f857-480c-bebb-76ee1de4e8fc
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugClass2::SetJMCStatus Method
For each method of the class, sets a value that indicates whether the method is user-defined code.  
  
## Syntax  
  
```  
HRESULT SetJMCStatus (  
    [in] BOOL   bIsJustMyCode  
);  
```  
  
#### Parameters  
 `bIsJustMyCode`  
 [in] Set to `true` to indicate that the method is user-defined code; otherwise, set to `false`.  
  
## Remarks  
 A just-my-code (JMC) stepper will skip non-user-defined code. User-defined code must be a subset of debuggable code.  
  
 `SetJMCStatus` returns an HRESULT value of S_FALSE if it fails to set the value for any method, even if it successfully sets the value for all other methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
