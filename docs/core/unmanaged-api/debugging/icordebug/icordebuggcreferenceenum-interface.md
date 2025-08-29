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
  - "ICorDebugGCReferenceEnum interface [.NET debugging]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
