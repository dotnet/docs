---
description: "Learn more about: ICorDebugEval2::RudeAbort Method"
title: "ICorDebugEval2::RudeAbort Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEval2.RudeAbort"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::RudeAbort"
helpviewer_keywords: 
  - "ICorDebugEval2::RudeAbort method [.NET Framework debugging]"
  - "RudeAbort method, ICorDebugEval2 interface [.NET Framework debugging]"
ms.assetid: 02468edf-d32b-4cb3-aaa8-3dd2abfc8b25
topic_type: 
  - "apiref"
---
# ICorDebugEval2::RudeAbort Method

Aborts the computation that this `ICorDebugEval2` is currently performing.  
  
## Syntax  
  
```cpp  
HRESULT RudeAbort ();  
```  
  
## Remarks  

 `RudeAbort` does not release any locks that the evaluator holds, so it leaves the debugging session in an unsafe state. Call this method with extreme caution.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
