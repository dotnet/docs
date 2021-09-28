---
description: "Learn more about: ICorDebugCode4::EnumerateVariableHomes Method"
title: "ICorDebugCode4::EnumerateVariableHomes Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode4.EnumerateVariableHomes"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode4::EnumerateVariableHomes"
helpviewer_keywords: 
  - "EnumerateVariableHomes method [.NET Framework debugging]"
  - "ICorDebugCode4::EnumerateVariableHomes method [.NET Framework debugging]"
ms.assetid: 802c01ff-8b80-4733-b6dd-03ab6ff7fa11
topic_type: 
  - "apiref"
---
# ICorDebugCode4::EnumerateVariableHomes Method

Gets an enumerator to the local variables and arguments in a function.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateVariableHomes(  
    [out] ICorDebugVariableHomeEnum **ppEnum  
);  
```  
  
## Parameters  

 `ppEnum`  
 A pointer to the address of an [ICorDebugVariableHomeEnum](icordebugvariablehomeenum-interface.md) interface object that is an enumerator for the local variables and arguments in a function.  
  
## Remarks  

 The [ICorDebugVariableHomeEnum](icordebugvariablehomeenum-interface.md) interface object is a standard enumerator derived from the "ICorDebugEnum" interface that allows you to enumerate [ICorDebugVariableHome](icordebugvariablehome-interface.md) objects. The collection may include multiple [ICorDebugVariableHome](icordebugvariablehome-interface.md) objects for the same slot or      argument index if they have different homes at different points in the      function.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugCode4 Interface](icordebugcode4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
