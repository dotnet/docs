---
description: "Learn more about: ICorDebugProcess5::EnumerateGCReferences Method"
title: "ICorDebugProcess5::EnumerateGCReferences Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5.EnumerateGCReferences"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::EnumerateGCReferences"
helpviewer_keywords:
  - "EnumerateGCReferences method, ICorDebugProcess5 interface [.NET debugging]"
  - "ICorDebugProcess5::EnumerateGCReferences method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::EnumerateGCReferences Method

Gets an enumerator for all objects that are to be garbage-collected in a process.

## Syntax

```cpp
HRESULT EnumerateGCReferences(
    [in] Bool enumerateWeakReferences,
    [out] ICorDebugGCReferenceEnum **ppEnum
);
```

## Parameters

 `enumerateWeakReferences`
 [in] A Boolean value that indicates whether weak references are also to be enumerated. If `enumerateWeakReferences` is `true`, the `ppEnum` enumerator includes both strong references and weak references. If `enumerateWeakReferences` is `false`, the enumerator includes only strong references.

 `ppEnum`
 [out] A pointer to the address of an [ICorDebugGCReferenceEnum](icordebuggcreferenceenum-interface.md) that is an enumerator for the objects to be garbage-collected.

## Remarks

 This method provides a way to determine the full rooting chain for any managed object in a process and can be used to determine why an object is still alive.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
