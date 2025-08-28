---
description: "Learn more about: ICorDebugVirtualUnwinder::Next Method"
title: "ICorDebugVirtualUnwinder::Next Method"
ms.date: "03/30/2017"
---
# ICorDebugVirtualUnwinder::Next Method

Advances to the caller's context.

## Syntax

```cpp
HRESULT Next();
```

## Parameters

 None.

## Return Value

 `S_OK` if the unwind occurred successfully, or `CORDBG_S_AT_END_OF_STACK` if the unwind cannot be completed because there are no more frames.

 If a failing HRESULT is returned, ICorDebug APIs will return `CORDBG_E_DATA_TARGET_ERROR`.

## Remarks

 The stack walker should ensure that it makes forward progress, so that eventually a call to `Next` will return a failing HRESULT or `CORDBG_S_AT_END_OF_STACK`. Returning `S_OK` indefinitely may cause an infinite loop.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)
