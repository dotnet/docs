---
description: "Learn more about: ICorDebugBreakpoint::Activate Method"
title: "ICorDebugBreakpoint::Activate Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugBreakpoint.Activate"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBreakpoint::Activate"
helpviewer_keywords: 
  - "ICorDebugBreakpoint::Activate method [.NET Framework debugging]"
  - "Activate method [.NET Framework debugging]"
ms.assetid: e30c29f7-3f19-4081-b572-a731aa14cd44
topic_type: 
  - "apiref"
---
# ICorDebugBreakpoint::Activate Method

Sets the active state of this `ICorDebugBreakpoint`.  
  
## Syntax  
  
```cpp  
HRESULT Activate (  
    [in] BOOL bActive  
);  
```  
  
## Parameters  

 `bActive`  
 [in] Set this value to `true` to specify the state as active; otherwise, set this value to `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
