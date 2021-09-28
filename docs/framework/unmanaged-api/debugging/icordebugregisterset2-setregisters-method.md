---
description: "Learn more about: ICorDebugRegisterSet2::SetRegisters Method"
title: "ICorDebugRegisterSet2::SetRegisters Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugRegisterSet2.SetRegisters"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet2::SetRegisters"
helpviewer_keywords: 
  - "ICorDebugRegisterSet2::SetRegisters method [.NET Framework debugging]"
  - "SetRegisters method, ICorDebugRegisterSet2 interface [.NET Framework debugging]"
ms.assetid: fe0ac7e7-c9e1-4ec1-9f4e-1c56d63d73ac
topic_type: 
  - "apiref"
---
# ICorDebugRegisterSet2::SetRegisters Method

`SetRegisters` is not implemented in the .NET Framework version 2.0. Do not call this method.  
  
> [!NOTE]
> Use the higher-level operations such as [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md) or [ICorDebugNativeFrame::SetIP](icordebugnativeframe-setip-method.md).  
  
## Syntax  
  
```cpp  
HRESULT SetRegisters (  
    [in] ULONG32 maskCount,  
    [in, size_is(maskCount)] BYTE mask[],  
    [in] ULONG32 regCount,  
    [in, size_is(regCount)] CORDB_REGISTER regBuffer[]  
);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
