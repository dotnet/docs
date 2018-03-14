---
title: "ICorDebugStepper2::SetJMC Method"
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
  - "ICorDebugStepper2.SetJMC"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper2::SetJMC"
helpviewer_keywords: 
  - "ICorDebugStepper2::SetJMC method [.NET Framework debugging]"
  - "SetJMC method [.NET Framework debugging]"
ms.assetid: f5cdc135-6db4-4b32-9dd1-260ec58b774f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStepper2::SetJMC Method
Sets a value that specifies whether this ICorDebugStepper steps only through code that is authored by an application's developer. This process is also known as just my code (JMC) debugging.  
  
## Syntax  
  
```  
HRESULT SetJMC (  
    [in] BOOL    fIsJMCStepper  
);  
```  
  
#### Parameters  
 `fIsJMCStepper`  
 [in] Set to `true` to step only through code that is authored by an application's developer; otherwise, set to `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
