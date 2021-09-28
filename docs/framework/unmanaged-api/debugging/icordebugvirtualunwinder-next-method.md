---
description: "Learn more about: ICorDebugVirtualUnwinder::Next Method"
title: "ICorDebugVirtualUnwinder::Next Method"
ms.date: "03/30/2017"
ms.assetid: 790e0426-e5cd-49fd-a792-f8c8635d72fe
---
# ICorDebugVirtualUnwinder::Next Method

Advances to the caller's context.  
  
## Syntax  
  
```cpp  
HRESULT Next();  
```  
  
## Parameters  

 None.  
  
## Return Value  

 `S_OK` if the unwind occurred successfully, or `CORDBG_S_AT_END_OF_STACK` if the unwind cannot be completed because there are no more frames.  
  
 If a failing HRESULT is returned, ICorDebug APIs will return `CORDBG_E_DATA_TARGET_ERROR`.  
  
## Remarks  

 The stack walker should ensure that it makes forward progress, so that eventually a call to `Next` will return a failing HRESULT or `CORDBG_S_AT_END_OF_STACK`. Returning `S_OK` indefinitely may cause an infinite loop.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
