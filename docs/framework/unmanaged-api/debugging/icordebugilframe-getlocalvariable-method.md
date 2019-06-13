---
title: "ICorDebugILFrame::GetLocalVariable Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugILFrame.GetLocalVariable"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::GetLocalVariable"
helpviewer_keywords: 
  - "ICorDebugILFrame::GetLocalVariable method [.NET Framework debugging]"
  - "GetLocalVariable method [.NET Framework debugging]"
ms.assetid: c8706356-d50b-4f87-a40c-39c3b7f4fd38
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugILFrame::GetLocalVariable Method
Gets the value of the specified local variable in this Microsoft intermediate language (MSIL) stack frame.  
  
## Syntax  
  
```  
HRESULT GetLocalVariable (  
    [in] DWORD                  dwIndex,  
    [out] ICorDebugValue        **ppValue  
);  
```  
  
## Parameters  
 `dwIndex`  
 [in] The index of the local variable in this MSIL stack frame.  
  
 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue object that represents the retrieved value.  
  
## Remarks  
 The `GetLocalVariable` method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
