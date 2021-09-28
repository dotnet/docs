---
description: "Learn more about: ICorDebugExceptionObjectValue::EnumerateExceptionCallStack Method"
title: "ICorDebugExceptionObjectValue::EnumerateExceptionCallStack Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugExceptionObjectValue.EnumerateExceptionCallStack"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugExceptionObjectValue::EnumerateExceptionCallStack"
helpviewer_keywords: 
  - "EnumerateExceptionCallStack method, ICorDebugExceptionObjectValue interface [.NET Framework debugging]"
  - "ICorDebugExceptionObjectValue::EnumerateExceptionCallStack method [.NET Framework debugging]"
ms.assetid: 00c64533-15dd-47f4-bb97-fe80a1ebadef
topic_type: 
  - "apiref"
---
# ICorDebugExceptionObjectValue::EnumerateExceptionCallStack Method

Gets an enumerator to the call stack embedded in an exception object.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateExceptionCallStack(  
    [out] ICorDebugExceptionObjectCallStackEnum **ppCallStackEnum  
);  
```  
  
## Parameters  

 ppCallStackEnum  
 [out] A pointer to the address of an [ICorDebugExceptionObjectCallStackEnum](icordebugexceptionobjectcallstackenum-interface.md) interface object that is a stack trace enumerator for a managed exception object.  
  
## Remarks  

 If no call stack information is available, the method returns `S_OK`, and [ICorDebugExceptionObjectCallStackEnum](icordebugexceptionobjectcallstackenum-interface.md) is a valid enumerator with a length of 0. If the method is unable to retrieve stack trace information, the return value is `E_FAIL` and no enumerator is returned.  
  
 The [ICorDebugExceptionObjectCallStackEnum](icordebugexceptionobjectcallstackenum-interface.md) object is responsible for decoding the stack trace data from the `_stackTrace` field of the exception object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugExceptionObjectValue Interface](icordebugexceptionobjectvalue-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
