---
description: "Learn more about: ICorDebugProcess5 Interface"
title: "ICorDebugProcess5 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5"
helpviewer_keywords:
  - "ICorDebugProcess5 interface [.NET Framework debugging]"
ms.assetid: 30a39d79-1f10-4328-9c5d-094ed824e2ba
topic_type:
  - "apiref"
---
# ICorDebugProcess5 Interface

Extends the ICorDebugProcess interface to support access to the managed heap, to provide information about garbage collection of managed objects, and to determine whether a debugger loads images from the application local native image cache.

## Methods

|Method|Description|
|------------|-----------------|
|[EnableNGenPolicy Method](icordebugprocess5-enablengenpolicy-method.md)|Sets a value that determines how an application loads native images while running under a managed debugger.|
|[EnumerateGCReferences Method](icordebugprocess5-enumerategcreferences-method.md)|Gets an enumerator for all objects that are to be garbage-collected in a process.|
|[EnumerateHandles Method](icordebugprocess5-enumeratehandles-method.md)|Gets an enumerator for object handles in a process.|
|[EnumerateHeap Method](icordebugprocess5-enumerateheap-method.md)|Gets an enumerator for objects on the managed heap.|
|[EnumerateHeapRegions Method](icordebugprocess5-enumerateheapregions-method.md)|Gets an enumerator for regions of the managed heap.|
|[GetArrayLayout Method](icordebugprocess5-getarraylayout-method.md)|Gets information about the layout of an array in memory.|
|[GetGCHeapInformation Method](icordebugprocess5-getgcheapinformation-method.md)|Gets a pointer to a [COR_HEAPINFO](cor-heapinfo-structure.md) structure that contains information about objects that are to be garbage-collected on the managed heap.|
|[GetObject Method](icordebugprocess5-getobject-method.md)|Gets a pointer to an object on the managed heap.|
|[GetTypeFields Method](icordebugprocess5-gettypefields-method.md)|Gets a pointer to an array that contains field information for a type based on its type identifier.|
|[GetTypeForTypeID Method](icordebugprocess5-gettypefortypeid-method.md)|Gets a type object that provides information about an object based on its type identifiers.|
|[GetTypeID Method](icordebugprocess5-gettypeid-method.md)|Gets the type identifier for the object at a specified address.|
|[GetTypeLayout Method](icordebugprocess5-gettypelayout-method.md)|Gets information about the layout of an object in memory based on its type identifier.|

## Remarks

 This interface logically extends the ICorDebugProcess, ICorDebugProcess2, and [ICorDebugProcess3](icordebugprocess3-interface.md) interfaces.

> [!NOTE]
> This interface does not support being called remotely, either from another machine or from another process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
