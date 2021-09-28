---
description: "Learn more about: ICorDebugRegisterSet::SetRegisters Method"
title: "ICorDebugRegisterSet::SetRegisters Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugRegisterSet.SetRegisters"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet::SetRegisters"
helpviewer_keywords: 
  - "SetRegisters method, ICorDebugRegisterSet interface [.NET Framework debugging]"
  - "ICorDebugRegisterSet::SetRegisters method [.NET Framework debugging]"
ms.assetid: ac6244b9-54ba-475f-b72a-abed6afc46ec
topic_type: 
  - "apiref"
---
# ICorDebugRegisterSet::SetRegisters Method

`SetRegisters` is not implemented in the .NET Framework version 2.0. Do not call this method.  
  
> [!NOTE]
> Use the higher-level operations such as [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md) or [ICorDebugNativeFrame::SetIP](icordebugnativeframe-setip-method.md).  
  
## Syntax  
  
```cpp  
HRESULT SetRegisters (  
    [in] ULONG64   mask,  
    [in] ULONG32   regCount,  
    [in, size_is(regCount)] CORDB_REGISTER regBuffer[]  
);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
