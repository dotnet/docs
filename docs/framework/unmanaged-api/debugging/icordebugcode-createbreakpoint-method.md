---
description: "Learn more about: ICorDebugCode::CreateBreakpoint Method"
title: "ICorDebugCode::CreateBreakpoint Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode.CreateBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::CreateBreakpoint"
helpviewer_keywords: 
  - "ICorDebugCode::CreateBreakpoint method [.NET Framework debugging]"
  - "CreateBreakpoint method, ICorDebugCode interface [.NET Framework debugging]"
ms.assetid: 46842618-0fe4-480b-871c-82fba82d23d9
topic_type: 
  - "apiref"
---
# ICorDebugCode::CreateBreakpoint Method

Creates a breakpoint in this code segment at the specified offset.  
  
## Syntax  
  
```cpp  
HRESULT CreateBreakpoint (  
    [in] ULONG32     offset,  
    [out] ICorDebugFunctionBreakpoint **ppBreakpoint  
);  
```  
  
## Parameters  

 `offset`  
 [in] The offset at which to create the breakpoint.  
  
 `ppBreakpoint`  
 [out] A pointer to the address of an "ICorDebugFunctionBreakpoint" object that represents the breakpoint.  
  
## Remarks  

 Before the breakpoint is active, it must be added to the process object.  
  
 If this code is Microsoft intermediate language (MSIL) code, and there is a just-in-time (JIT)-compiled, native version of the code, the breakpoint will be applied in the JIT-compiled code as well. (The same is true if the code is JIT-compiled later.)  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
