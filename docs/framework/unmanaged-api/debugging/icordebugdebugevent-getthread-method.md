---
description: "Learn more about: ICorDebugDebugEvent::GetThread Method"
title: "ICorDebugDebugEvent::GetThread Method"
ms.date: "03/30/2017"
ms.assetid: 4f2e9a2c-8369-4a07-a881-ad5422626353
---
# ICorDebugDebugEvent::GetThread Method

Gets the thread on which the event occurred.  
  
## Syntax  
  
```cpp  
HRESULT GetThread(  
        [out]ICorDebugThread **ppThread  
);  
```  
  
## Parameters  

 ppThread  
 [out] A pointer to the address of an ICorDebugThread object that represents the thread on which the event occurred.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugDebugEvent Interface](icordebugdebugevent-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
