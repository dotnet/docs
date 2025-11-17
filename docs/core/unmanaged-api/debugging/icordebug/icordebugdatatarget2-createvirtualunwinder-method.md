---
description: "Learn more about: ICorDebugDataTarget2::CreateVirtualUnwinder Method"
title: "ICorDebugDataTarget2::CreateVirtualUnwinder Method"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget2::CreateVirtualUnwinder Method

Creates a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).

## Syntax

```cpp
HRESULT CreateVirtualUnwinder(
    [in] DWORD nativeThreadID,
    [in] ULONG32 contextFlags,
    [in] ULONG32 cbContext,
    [in, size_is(cbContext)] BYTE initialContext[],
    [out] ICorDebugVirtualUnwinder ** ppUnwinder);
};
```

## Parameters

nativeThreadID
 [in] The native thread ID of the thread whose stack is to be unwound.

contextFlags
 [in] Flags that specify which parts of the context are defined in `initialContext`.

cbContext
 [in] The size of `initialContext`.

initialContext
 [in] The data in the context.

ppUnwinder
 [out] A pointer to the address of an ICorDebugVirtualUnwinder interface object.

## Return Value

 `S_OK` if successful. Any other `HRESULT` indicates failure. Any failing `HRESULT` received by mscordbi is considered fatal and causes [ICorDebug](icordebug-interface.md) methods to return `CORDBG_E_DATA_TARGET_ERROR`.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugDataTarget2 Interface](icordebugdatatarget2-interface.md)
