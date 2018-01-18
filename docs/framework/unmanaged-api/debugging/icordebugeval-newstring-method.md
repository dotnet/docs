---
title: "ICorDebugEval::NewString Method"
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
  - "ICorDebugEval.NewString"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::NewString"
helpviewer_keywords: 
  - "NewString method [.NET Framework debugging]"
  - "ICorDebugEval::NewString method [.NET Framework debugging]"
ms.assetid: 29e7a14b-d50e-4852-bfda-011b76c0c9ee
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::NewString Method
Allocates a new string instance with the specified contents.  
  
## Syntax  
  
```  
HRESULT NewString (  
    [in] LPCWSTR   string  
);  
```  
  
#### Parameters  
 `string`  
 [in] Pointer to the contents for the string.  
  
## Remarks  
 The string is always created in the application domain in which the thread is currently executing.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
