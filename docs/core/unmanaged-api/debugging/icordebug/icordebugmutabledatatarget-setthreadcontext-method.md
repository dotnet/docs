---
description: "Learn more about: ICorDebugMutableDataTarget::SetThreadContext Method"
title: "ICorDebugMutableDataTarget::SetThreadContext Method"
ms.date: "03/30/2017"
---
# ICorDebugMutableDataTarget::SetThreadContext Method

Sets the context (register values) for a thread.

## Syntax

```cpp
HRESULT SetThreadContext(
   [in] DWORD dwThreadID,
   [in] ULONG32 contextSize,   [in, size_is(contextSize)] const BYTE * pContext);
```

## Parameters

 `dwThreadID`
 [in] The operating system-defined thread identifier.

 `contextSize`
 [in] The size of the `pContext` buffer to be written.

 `pContext`
 [in] A pointer to the bytes to be written.

## Remarks

 The `SetThreadContext` method updates the current context for the thread specified by the operating system-defined `dwThreadID` argument. The format of the context record is determined by the platform indicated by the [ICorDebugDataTarget::GetPlatform](icordebugdatatarget-getplatform-method.md) method. On Windows, this is a [CONTEXT](/windows/win32/api/winnt/ns-winnt-arm64_nt_context) structure.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMutableDataTarget Interface](icordebugmutabledatatarget-interface.md)
