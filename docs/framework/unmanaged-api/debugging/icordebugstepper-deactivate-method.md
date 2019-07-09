---
title: "ICorDebugStepper::Deactivate Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugStepper.Deactivate"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStepper::Deactivate"
helpviewer_keywords: 
  - "Deactivate method [.NET Framework debugging]"
  - "ICorDebugStepper::Deactivate method [.NET Framework debugging]"
ms.assetid: 855f4199-b62d-40ce-998e-1eb4a1772142
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugStepper::Deactivate Method
Causes this ICorDebugStepper to cancel the last step command that it received.  
  
## Syntax  
  
```cpp  
HRESULT Deactivate ();  
```  
  
## Remarks  
 A new stepping command may be issued after the most recently received step command has been canceled.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
