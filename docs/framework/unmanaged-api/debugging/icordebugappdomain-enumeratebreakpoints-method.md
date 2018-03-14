---
title: "ICorDebugAppDomain::EnumerateBreakpoints Method"
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
  - "ICorDebugAppDomain.EnumerateBreakpoints"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::EnumerateBreakpoints"
helpviewer_keywords: 
  - "ICorDebugAppDomain::EnumerateBreakpoints method [.NET Framework debugging]"
  - "EnumerateBreakpoints method [.NET Framework debugging]"
ms.assetid: 206069c5-25cb-4794-9d69-67c5aa7ed0af
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAppDomain::EnumerateBreakpoints Method
Gets an enumerator for all active breakpoints in the application domain.  
  
## Syntax  
  
```  
HRESULT EnumerateBreakpoints (  
    [out] ICorDebugBreakpointEnum   **ppBreakpoints  
);  
```  
  
#### Parameters  
 `ppBreakpoints`  
 [out] A pointer to the address of an ICorDebugBreakpointEnum object that is the enumerator for all active breakpoints in the application domain.  
  
## Remarks  
 The enumerator includes all types of breakpoints, including function breakpoints and data breakpoints.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
