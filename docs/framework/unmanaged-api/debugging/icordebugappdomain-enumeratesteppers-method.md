---
title: "ICorDebugAppDomain::EnumerateSteppers Method"
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
  - "ICorDebugAppDomain.EnumerateSteppers"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::EnumerateSteppers"
helpviewer_keywords: 
  - "ICorDebugAppDomain::EnumerateSteppers method [.NET Framework debugging]"
  - "EnumerateSteppers method [.NET Framework debugging]"
ms.assetid: 3f3c4503-570e-44c1-ae6a-a3c6b840c732
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAppDomain::EnumerateSteppers Method
Gets an enumerator for all active steppers in the application domain.  
  
## Syntax  
  
```  
HRESULT EnumerateSteppers (  
    [out] ICorDebugStepperEnum   **ppSteppers  
);  
```  
  
#### Parameters  
 `ppSteppers`  
 [out] A pointer to the address of an ICorDebugStepperEnum object that is the enumerator for all active steppers in the application domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
