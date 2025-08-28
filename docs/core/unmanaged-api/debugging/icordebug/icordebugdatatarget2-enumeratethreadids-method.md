---
description: "Learn more about: ICorDebugDataTarget2::EnumerateThreadIDs Method"
title: "ICorDebugDataTarget2::EnumerateThreadIDs Method"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget2::EnumerateThreadIDs Method

Returns a list of active thread IDs.

## Syntax

```cpp
HRESULT EnumerateThreadIDs(
    [in] ULONG32 cThreadIds,
    [out] ULONG32 *pcThreadIds,
    [out, size_is(cThreadIds), length_is(*pcThreadIds)] ULONG32 pThreadIds[]
);
```

## Parameters

 cThreadIDs
 [in] The maximum number of threads whose IDs can be returned.

 pcThreadIds
 [out] A pointer to a `ULONG32` that indicates the actual number of thread IDs written to the `pThreadIds` array.

 pThreadIDs
 An array of thread identifiers.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).**Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugDataTarget2 Interface](icordebugdatatarget2-interface.md)
