---
title: "ICorDebugAppDomain::Attach Method"
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
  - "ICorDebugAppDomain.Attach"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::Attach"
helpviewer_keywords: 
  - "ICorDebugAppDomain::Attach method [.NET Framework debugging]"
  - "Attach method [.NET Framework debugging]"
ms.assetid: 0358b84a-4236-4c34-945b-4babff7df570
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAppDomain::Attach Method
Attaches the debugger to the application domain.  
  
## Syntax  
  
```  
HRESULT Attach ();  
```  
  
## Remarks  
 The debugger must be attached to the application domain to receive events and to enable debugging of the application domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
