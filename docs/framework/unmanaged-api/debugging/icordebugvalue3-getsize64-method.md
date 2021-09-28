---
description: "Learn more about: ICorDebugValue3::GetSize64 Method"
title: "ICorDebugValue3::GetSize64 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugValue3::GetSize64"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugValue3::GetSize64"
helpviewer_keywords: 
  - "GetSize64 method, ICorDebugValue3 interface [.NET Framework debugging]"
  - "ICorDebugValue3::GetSize64 method [.NET Framework debugging]"
ms.assetid: fee56a29-3154-4192-958d-71da2ced3740
topic_type: 
  - "apiref"
---
# ICorDebugValue3::GetSize64 Method

Gets the size, in bytes, of this [ICorDebugValue3](icordebugvalue3-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT GetSize64(  
    [out] ULONG64 *pSize  
);  
```  
  
## Parameters  

 pSize  
 [out] A pointer to the size, in bytes, of this object.  
  
## Remarks  

 If this value's type is a reference type, this method returns the size of the pointer rather than the size of the object.  
  
 The `ICorDebugValue3::GetSize` method differs from the [ICorDebugValue::GetSize](icordebugvalue-getsize-method.md) method in the type of its output parameter. In [ICorDebugValue::GetSize](icordebugvalue-getsize-method.md), the output parameter is a `ULONG32`; in `ICorDebugValue3::GetSize`, it is a `ULONG64`. This enables the [ICorDebugValue3](icordebugvalue3-interface.md) interface to report the size of arrays that exceed 2GB.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugValue3 Interface](icordebugvalue3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
