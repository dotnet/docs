---
description: "Learn more about: ICorDebugGCReferenceEnum Interface"
title: "ICorDebugGCReferenceEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugGCReferenceEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugGCReferenceEnum"
helpviewer_keywords:
  - "ICorDebugGCReferenceEnum interface [.NET Framework debugging]"
ms.assetid: 5f3c91c9-c035-454f-96cc-011cab1ea06b
topic_type:
  - "apiref"
---
# ICorDebugGCReferenceEnum Interface

Provides an enumerator for objects that will be garbage-collected.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebuggcreferenceenum-next-method.md)|Gets the specified number of [COR_GC_REFERENCE](cor-gc-reference-structure.md) instances that contain information about objects that will be garbage-collected.|

## Remarks

 The `ICorDebugGCReferenceEnum` interface implements the "ICorDebugEnum" interface.

 An `ICorDebugGCReferenceEnum` instance is populated with [COR_GC_REFERENCE](cor-gc-reference-structure.md) instances by calling the [ICorDebugProcess5::EnumerateGCReferences](icordebugprocess5-enumerategcreferences-method.md) method. [COR_GC_REFERENCE](cor-gc-reference-structure.md) objects can be enumerated by calling the [ICorDebugGCReference::Next](icordebuggcreferenceenum-next-method.md) method.

 The [COR_GC_REFERENCE](cor-gc-reference-structure.md) objects in the collection populated by this method represent three kinds of objects:

- Objects from all managed stacks. This includes live references in managed code as well as objects created by the common language runtime.

- Objects from the handle table. This includes strong references (`HNDTYPE_STRONG` and `HNDTYPE_REFCOUNT`) and static variables in a module.

- Objects from the finalizer queue. The finalizer queue roots objects until the finalizer has run.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
