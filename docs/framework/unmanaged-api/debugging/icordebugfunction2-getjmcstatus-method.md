---
title: "ICorDebugFunction2::GetJMCStatus Method"
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
  - "ICorDebugFunction2.GetJMCStatus"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction2::GetJMCStatus"
helpviewer_keywords: 
  - "ICorDebugFunction2::GetJMCStatus method [.NET Framework debugging]"
  - "GetJMCStatus method [.NET Framework debugging]"
ms.assetid: 840a71ed-bf5a-4f5e-8ed6-762222b34493
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction2::GetJMCStatus Method
Gets a value that indicates whether the function that is represented by this ICorDebugFunction2 object is marked as user code.  
  
## Syntax  
  
```  
HRESULT GetJMCStatus (  
    [out] BOOL   *pbIsJustMyCode  
);  
```  
  
#### Parameters  
 `pbIsJustMyCode`  
 [out] A pointer to a Boolean value that is `true`, if this function is marked as user code; otherwise, the value is `false`.  
  
## Remarks  
 If the function represented by this `ICorDebugFunction2` cannot be debugged, `pbIsJustMyCode` will always be `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
