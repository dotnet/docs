---
description: "Learn more about: ICorDebugProcess6::DecodeEvent Method"
title: "ICorDebugProcess6::DecodeEvent Method"
ms.date: "03/30/2017"
---
# ICorDebugProcess6::DecodeEvent Method

Decodes managed debug events that have been encapsulated in the payload of specially crafted native exception debug events.

## Syntax

```cpp
HRESULT DecodeEvent(
        [in, length_is(countBytes), size_is(countBytes)]  const BYTE pRecord[],
        [in] DWORD countBytes,
        [in] CorDebugRecordFormat format,
        [in] DWORD dwFlags,
        [in] DWORD dwThreadId,
        [out] ICorDebugDebugEvent **ppEvent
);
```

## Parameters

 `pRecord`
 [in] A pointer to a byte array from a native exception debug event that includes information about a managed debug event.

 `countBytes`
 [in] The number of elements in the `pRecord` byte array.

 `format`
 [in] A [CorDebugRecordFormat](cordebugrecordformat-enumeration.md) enumeration member that specifies the format of the unmanaged debug event.

 `dwFlags`
 [in] A bit field that depends on the target architecture and that specifies additional information about the debug event. For Windows systems, it can be a member of the [CorDebugDecodeEventFlagsWindows](cordebugdecodeeventflagswindows-enumeration.md) enumeration.

 `dwThreadId`
 [in] The operating system identifier of the thread on which the exception was thrown.

 `ppEvent`
 [out] A pointer to the address of an [ICorDebugDebugEvent](icordebugdebugevent-interface.md) object that represents a decoded managed debug event.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugProcess6 Interface](icordebugprocess6-interface.md)
