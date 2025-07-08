---
title: "CorGCReferenceType Enumeration"
description: "Learn more about: CorGCReferenceType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorGCReferenceType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorGCReferenceType"
helpviewer_keywords:
  - "CorGCReferenceType"
topic_type:
  - "apiref"
---
# CorGCReferenceType Enumeration

Identifies the source of an object to be garbage-collected.

## Syntax

```cpp
typedef enum {
    CorHandleStrong = 1,
    CorHandleStrongPinning = 2,
    CorHandleWeakShort = 4,
    CorHandleWeakRefCount = 8,
    CorHandleStrongRefCount = 32,
    CorHandleStrongDependent = 64,
    CorHandleStrongAsyncPinned = 128,
    CorHandleStrongSizedByref = 256,
    CorHandleWeakWinRT = 512,

    CorReferenceStack = 0x80000001,
    CorReferenceFinalizer = 80000002,  // Note the constant is decimal, not hexadecimal

    CorHandleStrongOnly = 0x1E3,
    CorHandleWeakOnly = 0xC,
    CorHandleAll = 0x7FFFFFFF
} CorGCReferenceType;
```

## Members

|Member name|Description|
|-----------------|-----------------|
|`CorHandleStrong`|A handle to a strong reference from the object handle table.|
|`CorHandleStrongPinning`|A handle to a pinned strong reference from the object handle table.|
|`CorHandleWeakShort`|A handle to a weak reference from the object handle table.|
|`CorHandleWeakRefCount`|A handle to a weak reference-counted object from the object handle table.|
|`CorHandleStrongRefCount`|A handle to a reference-counted object from the object handle table.|
|`CorHandleStrongDependent`|A handle to a dependent object from the object handle table.|
|`CorHandleStrongAsyncPinned`|An asynchronous pinned object from the object handle table.|
|`CorHandleStrongSizedByref`|A strong handle that keeps an approximate size of the collective closure of all objects and object roots at garbage collection time.|
|`CorHandleWeakWinRT`|A weak handle to a RCW (Runtime Callable Wrapper). An RCW is a managed object that proxies calls to an underlying COM object.|
|`CorReferenceStack`|A reference from the managed stack.|
|`CorReferenceFinalizer`|A reference from the finalizer queue.|
|CorHandleStrongOnly|Return only strong references from the handle table. This value is used by the [ICorDebugProcess5::EnumerateHandles](icordebugprocess5-enumeratehandles-method.md) method only.|
|`CorHandleWeakOnly`|Return only weak references from the handle table. This value is used by the [ICorDebugProcess5::EnumerateHandles](icordebugprocess5-enumeratehandles-method.md) method only.|
|`CorHandleAll`|Return all references from the handle table. This value is used by the [ICorDebugProcess5::EnumerateHandles](icordebugprocess5-enumeratehandles-method.md) method only.|

## Remarks

 The `CorGCReferenceType` enumeration is used as follows:

- As the value of the `type` field of the [COR_GC_REFERENCE](cor-gc-reference-structure.md) structure, it indicates the source of a reference or handle.

- As the `types` argument to the [ICorDebugProcess5::EnumerateHandles](icordebugprocess5-enumeratehandles-method.md) method, it specifies the types of handles to include in the enumeration.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]

## See also

- [Debugging Enumerations](debugging-enumerations.md)
