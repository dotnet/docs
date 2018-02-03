---
title: "ICorDebugBreakpoint::IsActive Method"
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
  - "ICorDebugBreakpoint.IsActive"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBreakpoint::IsActive"
helpviewer_keywords: 
  - "ICorDebugBreakpoint::IsActive method [.NET Framework debugging]"
  - "IsActive method, ICorDebugBreakpoint interface [.NET Framework debugging]"
ms.assetid: 06e583d6-d88a-4ff5-bb95-5c48618a461c
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugBreakpoint::IsActive Method
Gets a value that indicates whether this `ICorDebugBreakpoint` is active.  
  
## Syntax  
  
```  
HRESULT IsActive (  
    [out] BOOL *pbActive  
);  
```  
  
#### Parameters  
 `pbActive`  
 [out] `true` if this breakpoint is active; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
