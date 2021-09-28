---
description: "Learn more about: ICorDebugProcess6::ProcessStateChanged Method"
title: "ICorDebugProcess6::ProcessStateChanged Method"
ms.date: "03/30/2017"
ms.assetid: fb6d30d9-54f3-462b-8ebf-ce0440791ad5
---
# ICorDebugProcess6::ProcessStateChanged Method

Notifies [ICorDebug](icordebug-interface.md) that the process is running.  
  
## Syntax  
  
```cpp  
HRESULT ProcessStateChanged(   [in] CorDebugStateChange change);  
```  
  
## Parameters  

 `change`  
 [in] A member of the [ProcessStateChanged](icordebugprocess6-processstatechanged-method.md) enumeration  
  
## Remarks  

 The debugger calls this method to notify [ICorDebug](icordebug-interface.md) that the process is running.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugProcess6 Interface](icordebugprocess6-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
