---
description: "Learn more about: ICorDebugStackWalk::SetContext Method"
title: "ICorDebugStackWalk::SetContext Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugStackWalk.SetContext Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugStackWalk::SetContext"
helpviewer_keywords:
  - "SetContext method [.NET debugging]"
  - "ICorDebugStackWalk::SetContext method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugStackWalk::SetContext Method

Sets the [ICorDebugStackWalk](icordebugstackwalk-interface.md) object’s current context to a valid context for the thread.

## Syntax

```cpp
HRESULT SetContext([in] CorDebugSetContextFlag flag,
                   [in] ULONG32 contextSize,
                   [in, size_is(contextSize)] BYTE context[]);
```

## Parameters

 `flag`
 [in] A [CorDebugSetContextFlag](cordebugsetcontextflag-enumeration.md) flag that indicates whether the context is from the active frame on the stack, or a context obtained by unwinding the stack.

 `contextSize`
 [in] The allocated size of the `CONTEXT` buffer.

 `context`
 [in] The `CONTEXT` buffer.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The `ICorDebugStackWalk` object's context was successfully set.|
|E_FAIL|The `ICorDebugStackWalk` object's context was not set.|
|E_INVALIDARG|The context is null.|
|HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)|The context buffer is too small.|

## Exceptions

## Remarks

 This method does not alter the current context of the thread.

 Setting the current context to an invalid context may cause unpredictable results from the stack walker.

 You can retrieve an exact bitwise copy of this context by immediately calling the [ICorDebugStackWalk::GetContext](icordebugstackwalk-getcontext-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
