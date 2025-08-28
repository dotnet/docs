---
description: "Learn more about: ICorDebugReferenceValue Interface"
title: "ICorDebugReferenceValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugReferenceValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugReferenceValue"
helpviewer_keywords:
  - "ICorDebugReferenceValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugReferenceValue Interface

Provides methods that manage a value that is a reference to an object. (That is, this interface provides methods that manage a pointer.) This interface implements "ICorDebugValue".

## Methods

|Method|Description|
|------------|-----------------|
|[Dereference Method](icordebugreferencevalue-dereference-method.md)|Gets the object that is referenced.|
|[DereferenceStrong Method](icordebugreferencevalue-dereferencestrong-method.md)|Not implemented. Do not call this method.|
|[GetValue Method](icordebugreferencevalue-getvalue-method.md)|Gets the current memory address of the referenced object.|
|[IsNull Method](icordebugreferencevalue-isnull-method.md)|Gets a value that indicates whether this `ICorDebugReferenceValue` is a null value, in which case the `ICorDebugReferenceValue` does not point to an object.|
|[SetValue Method](icordebugreferencevalue-setvalue-method.md)|Sets the current memory address. That is, this method sets this `ICorDebugReferenceValue` to point to an object.|

## Remarks

 The common language runtime (CLR) may do a garbage collection on objects when the debugged process is continued. The garbage collection may move objects around in memory. An `ICorDebugReferenceValue` will either cooperate with the garbage collection so that its information is updated after the garbage collection, or it will be invalidated implicitly before the garbage collection.

 The `ICorDebugReferenceValue` object may be implicitly invalidated after the debugged process has been continued. The derived "ICorDebugHandleValue" is not invalidated until it is explicitly released or exposed.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Debugging Interfaces](debugging-interfaces.md)
