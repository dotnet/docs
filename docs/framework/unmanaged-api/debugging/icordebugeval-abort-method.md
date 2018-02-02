---
title: "ICorDebugEval::Abort Method"
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
  - "ICorDebugEval.Abort"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::Abort"
helpviewer_keywords: 
  - "Abort method, ICorDebugEval interface [.NET Framework debugging]"
  - "ICorDebugEval::Abort method [.NET Framework debugging]"
ms.assetid: 7070b6d0-f2e0-44ff-b124-0944cd807e69
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::Abort Method
Aborts the computation this ICorDebugEval object is currently performing.  
  
## Syntax  
  
```  
HRESULT Abort ();  
```  
  
## Remarks  
 If the evaluation is nested and it is not the most recent one, the `Abort` method may fail.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
