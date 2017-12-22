---
title: "ICorDebugStepperEnum::Next Method"
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
  - "ICorDebugStepperEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepperEnum::Next"
helpviewer_keywords: 
  - "Next method, ICorDebugStepperEnum interface [.NET Framework debugging]"
  - "ICorDebugStepperEnum::Next method [.NET Framework debugging]"
ms.assetid: d0ea0f30-e8d2-48b0-8477-e1a029ceb4dd
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStepperEnum::Next Method
Gets the specified number of ICorDebugStepper instances from the enumeration, starting at the current position.  
  
## Syntax  
  
```  
HRESULT Next(  
    [in] ULONG  celt,  
    [out, size_is(celt), length_is(*pceltFetched)]  
        ICorDebugStepper *steppers[],  
    [out] ULONG *pceltFetched  
);  
```  
  
#### Parameters  
 `celt`  
 [in] The number of `ICorDebugStepper` instances to be retrieved.  
  
 `steppers`  
 [out] An array of pointers, each of which points to an `ICorDebugStepper` object.  
  
 `pceltFetched`  
 [out] Pointer to the number of `ICorDebugStepper` instances actually returned. This value may be null if `celt` is one.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
