---
description: "Learn more about: ICorDebugExceptionDebugEvent::GetNativeIP Method"
title: "ICorDebugExceptionDebugEvent::GetNativeIP Method"
ms.date: "03/30/2017"
ms.assetid: 12e6a262-d9ac-49b8-9b80-1e653a2a3819
---
# ICorDebugExceptionDebugEvent::GetNativeIP Method

Gets the native instruction pointer for this exception debug event.

## Syntax

```cpp
HRESULT GetNativeIP(
   [out]CORDB_ADDRESS *pIP
);
```

## Parameters

 `pIP`
 [out] A pointer to the instruction pointer for this exception debug event. See the Remarks section for more information.

## Remarks

 The meaning of this instruction pointer depends on the event type, as shown in the following table.

|Event type|Meaning of `pStackPointer` value|
|----------------|--------------------------------------|
|[MANAGED_EXCEPTION_FIRST_CHANCE](cordebugrecordformat-enumeration.md)|The address of the faulting instruction.|
|[MANAGED_EXCEPTION_USER_FIRST_CHANCE](cordebugrecordformat-enumeration.md)|The code address in the frame indicated by the [GetStackPointer](icordebugexceptiondebugevent-getstackpointer-method.md) method where execution would resume if no exception had been raised. The exception may or may not cause different code, such as the catch block of a `try/catch/finally` clause, to be executed in this frame.|
|[MANAGED_EXCEPTION_CATCH_HANDLER_FOUND](cordebugrecordformat-enumeration.md)|The code address where `catch` handler execution will start in the frame indicated by the [GetStackPointer](icordebugexceptiondebugevent-getstackpointer-method.md) method.|
|[MANAGED_EXCEPTION_UNHANDLED](cordebugrecordformat-enumeration.md)|`pIP` is 0.|

 The event type is available from the [ICorDebugDebugEvent::GetEventKind](icordebugdebugevent-geteventkind-method.md) method.

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
