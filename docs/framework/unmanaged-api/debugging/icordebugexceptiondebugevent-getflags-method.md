---
description: "Learn more about: ICorDebugExceptionDebugEvent::GetFlags Method"
title: "ICorDebugExceptionDebugEvent::GetFlags Method"
ms.date: "03/30/2017"
ms.assetid: 73225303-8852-487e-9a0e-9f0cb95e99d9
---
# ICorDebugExceptionDebugEvent::GetFlags Method

Gets a flag that indicates whether the exception can be intercepted.  
  
## Syntax  
  
```cpp  
HRESULT GetFlags(  
   [out] CorDebugExceptionFlags *pdwFlags  
);  
```  
  
## Parameters  

 `pdwFlags`  
 [out] A pointer to a [CorDebugExceptionFlags](cordebugexceptionflags-enumeration.md) value that indicates whether the exception can be intercepted.  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugExceptionDebugEvent Interface](icordebugexceptiondebugevent-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
