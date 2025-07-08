---
description: "Learn more about: ICorDebugProcess5::EnumerateHandles Method"
title: "ICorDebugProcess5::EnumerateHandles Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5.EnumerateHandles"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::EnumerateHandles"
helpviewer_keywords:
  - "EnumerateHandles method, ICorDebugProcess5 interface [.NET Framework debugging]"
  - "ICorDebugProcess5::EnumerateHandles method [.NET Framework debugging]"
ms.assetid: 7d7fa796-0dc6-4ee8-9d56-40166246d91d
topic_type:
  - "apiref"
---
# ICorDebugProcess5::EnumerateHandles Method

Gets an enumerator for object handles in a process.

## Syntax

```cpp
HRESULT EnumerateHandles(     [in] CorGCReferenceType types,
    [out] ICorDebugGCReferenceEnum **ppEnum);
```

## Parameters

 `types`
 [in] A bitwise combination of [CorGCReferenceType](corgcreferencetype-enumeration.md) values that specifies the type of handles to include in the collection.

 `ppENum`
 [out] A pointer to the address of an [ICorDebugGCReferenceEnum](icordebuggcreferenceenum-interface.md) that is an enumerator for the objects to be garbage-collected.

## Remarks

 `EnumerateHandles` is a helper function that supports inspection of the handle table. It is similar to the [ICorDebugProcess5::EnumerateGCReferences](icordebugprocess5-enumerategcreferences-method.md) method, except that rather than populating an [ICorDebugGCReferenceEnum](icordebuggcreferenceenum-interface.md) collection with all objects to be garbage-collected, it includes only objects that have handles from the handle table.

 The `types` parameter specifies the handle types to include in the collection. `types` can be any of the following three members of the [CorGCReferenceType](corgcreferencetype-enumeration.md) enumeration:

- `CorHandleStrongOnly` (handles to strong references only).

- `CorHandleWeakOnly` (handles to weak references only).

- `CorHandleAll` (all handles).

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]

## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
