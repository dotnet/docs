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
  - "EnumerateExceptionCallStack method, ICorDebugExceptionObjectValue interface [.NET debugging]"
  - "ICorDebugExceptionObjectValue::EnumerateExceptionCallStack method [.NET debugging]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugExceptionObjectValue Interface](icordebugexceptionobjectvalue-interface.md)
