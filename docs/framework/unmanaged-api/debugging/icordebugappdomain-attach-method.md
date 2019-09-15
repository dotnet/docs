---
title: "ICorDebugAppDomain::Attach Method"
ms.date: "03/30/2017"
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
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugAppDomain::Attach Method
Attaches the debugger to the application domain.  
  
## Syntax  
  
```cpp  
HRESULT Attach ();  
```  
  
## Remarks  
 The debugger must be attached to the application domain to receive events and to enable debugging of the application domain.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
