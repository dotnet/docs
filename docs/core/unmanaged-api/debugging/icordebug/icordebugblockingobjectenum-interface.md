---
description: "Learn more about: ICorDebugBlockingObjectEnum Interface"
title: "ICorDebugBlockingObjectEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugBlockingObjectEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugBlockingObjectEnum"
helpviewer_keywords:
  - "ICorDebugBlockingObjectEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugBlockingObjectEnum Interface

Provides an enumerator for a list of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures. This interface is a subclass of the ICorDebugEnum interface.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugblockingobjectenum-next-method.md)|Enumerates through a list of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures.|

## Remarks

 Each `CorDebugBlockingObject` structure represents an object that is blocking a thread.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
