---
title: "ICorDebugProcess::IsTransitionStub Method"
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
  - "ICorDebugProcess.IsTransitionStub"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::IsTransitionStub"
helpviewer_keywords: 
  - "ICorDebugProcess::IsTransitionStub method [.NET Framework debugging]"
  - "IsTransitionStub method [.NET Framework debugging]"
ms.assetid: f7653317-7e48-4163-be03-f50f1a4b0f70
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::IsTransitionStub Method
Gets a value that indicates whether an address is inside a stub that will cause a transition to managed code.  
  
## Syntax  
  
```  
HRESULT IsTransitionStub(  
    [in]  CORDB_ADDRESS address,  
    [out] BOOL *pbTransitionStub);  
```  
  
#### Parameters  
 `address`  
 [in] A `CORDB_ADDRESS` value that specifies the address in question.  
  
 `pbTransitionStub`  
 [out] A pointer to a Boolean value that is `true` if the specified address is inside a stub that will cause a transition to managed code; otherwise *`pbTransitionStub` is `false`.  
  
## Remarks  
 The `IsTransitionStub` method can be used by unmanaged stepping code to decide when to return stepping control to the managed stepper.  
  
 You can also identity transition stubs by looking at information in the portable executable (PE) file.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
