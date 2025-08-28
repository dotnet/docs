---
description: "Learn more about: ICorDebugProcess8::EnableExceptionCallbacksOutsideOfMyCode Method"
title: "ICorDebugProcess8::EnableExceptionCallbacksOutsideOfMyCode Method"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
---
# ICorDebugProcess8::EnableExceptionCallbacksOutsideOfMyCode Method

[Supported in the .NET Framework 4.6 and later versions]

 Enables or disables certain types of [ICorDebugManagedCallback2](icordebugmanagedcallback2-interface.md) exception callbacks.

## Syntax

```cpp
HRESULT EnableExceptionCallbacksOutsideOfMyCode(
   [in] BOOL enableExceptionsOutsideOfJMC
);
```

## Parameters

 `enableExceptionsOutsideOfJMC`
 [in]

## Remarks

 If the value of `enableExceptionsOutsideOfJMC` is `false`:

- A DEBUG_EXCEPTION_FIRST_CHANCE exception will not result in a callback to the debugger.

- A DEBUG_EXCEPTION_CATCH_HANDLER_FOUND exception will not result in a callback to the debugger if the exception never escapes into user code (that is, the path from an exception origin to an exception handler has no methods marked as JustMyCode, or JMC).

 The default value of `enableExceptionsOutsideOfJMC` is `true`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugProcess8 Interface](icordebugprocess8-interface.md)
