---
title: "ICorDebugStepper::SetRangeIL Method"
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
  - "ICorDebugStepper.SetRangeIL"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::SetRangeIL"
helpviewer_keywords: 
  - "SetRangeIL method [.NET Framework debugging]"
  - "ICorDebugStepper::SetRangeIL method [.NET Framework debugging]"
ms.assetid: a20c95f0-6da7-4b41-b27f-584211cebb92
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStepper::SetRangeIL Method
Sets a value that specifies whether calls to [ICorDebugStepper::StepRange](../../../../docs/framework/unmanaged-api/debugging/icordebugstepper-steprange-method.md) pass argument values that are relative to the native code or relative to Microsoft intermediate language (MSIL) code of the method that is being stepped through.  
  
## Syntax  
  
```  
HRESULT SetRangeIL (  
    [in] BOOL    bIL  
);  
```  
  
#### Parameters  
 `bIL`  
 [in] Set to `true` to specify that the ranges are relative to the MSIL code. Set to `false` to specify that the ranges are relative to the native code. The default value is `true`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
