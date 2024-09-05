---
description: "Learn more about: ICorDebugExceptionDebugEvent::GetStackPointer Method"
title: "ICorDebugExceptionDebugEvent::GetStackPointer Method"
ms.date: "03/30/2017"
ms.assetid: d8f66a1c-16be-4264-afc5-bc2dfbb4a682
---
# ICorDebugExceptionDebugEvent::GetStackPointer Method

Gets the stack pointer for this exception debug event.

## Syntax

```cpp
HRESULT GetStackPointer(
   [out]CORDB_ADDRESS *pStackPointer
);
```

## Parameters

 `pStackPointer`
 [out] A pointer to the address of the stack pointer for this exception debug event. See the Remarks section for more information.

## Remarks

 The meaning of this stack pointer depends on the event type, as shown in the following table.

|Event type|Meaning of `pStackPointer` value|
|----------------|--------------------------------------|
|[MANAGED_EXCEPTION_FIRST_CHANCE](cordebugrecordformat-enumeration.md)|The stack pointer for the frame that threw the exception.|
|[MANAGED_EXCEPTION_USER_FIRST_CHANCE](cordebugrecordformat-enumeration.md)|The stack pointer for the user-code frame closest to the point of the thrown exception.|
|[MANAGED_EXCEPTION_CATCH_HANDLER_FOUND](cordebugrecordformat-enumeration.md)|The stack pointer for the frame that contains the catch handler.|
|[MANAGED_EXCEPTION_UNHANDLED](cordebugrecordformat-enumeration.md)|`pStackPointer` is **null**.|

> [!NOTE]
> This method is available with .NET Native only.

 The event type is available from the [ICorDebugDebugEvent::GetEventKind](icordebugdebugevent-geteventkind-method.md) method.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [ICorDebugExceptionDebugEvent Interface](icordebugexceptiondebugevent-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
