---
description: "Learn more about: ICorDebugAppDomain4::GetObjectForCCW Method"
title: "ICorDebugAppDomain4::GetObjectForCCW Method"
ms.date: "03/30/2017"
ms.assetid: 2cacdb85-e7b8-42e7-b310-c3e8c22e5d33
---
# ICorDebugAppDomain4::GetObjectForCCW Method

Gets a managed object from a COM callable wrapper (CCW) pointer.  
  
## Syntax  
  
```cpp  
HRESULT GetObjectForCCW(  
   [in]CORDB_ADDRESS ccwPointer,
   [out]ICorDebugValue **ppManagedObject  
);  
```  
  
## Parameters  

 `ccwPointer`  
 [in] A COM callable wrapper (CCW) pointer.  
  
 `ppManagedObject`  
 [out] A pointer to the address of an "ICorDebugValue" object that represents the managed object that corresponds to the given CCW pointer.  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See also

- [ICorDebugAppDomain4 Interface](icordebugappdomain4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
