---
description: "Learn more about: ICorDebugExceptionObjectCallStackEnum Interface"
title: "ICorDebugExceptionObjectCallStackEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugExceptionObjectCallStackEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugExceptionObjectCallStackEnum"
helpviewer_keywords:
  - "ICorDebugExceptionObjectCallStackEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugExceptionObjectCallStackEnum Interface

Provides an enumerator for call stack information that is embedded in an exception object. This interface is a subclass of the ICorDebugEnum interface.

## Methods

|Method|Description|
|------------|-----------------|
|[ICorDebugExceptionObjectCallStackEnum::Next](icordebugexceptionobjectcallstackenum-next-method.md)|Gets a specified number of [CorDebugExceptionObjectStackFrame](cordebugexceptionobjectstackframe-structure.md) objects that contain information about an exception object's call stack.|

## Remarks

 The `ICorDebugExceptionObjectCallStackEnum` interface implements the ICorDebugEnum interface.

 An `ICorDebugExceptionObjectCallStackEnum` instance is populated with [CorDebugExceptionObjectStackFrame](cordebugexceptionobjectstackframe-structure.md) objects by calling the [ICorDebugExceptionObjectValue::EnumerateExceptionCallStack](icordebugexceptionobjectvalue-enumerateexceptioncallstack-method.md) method. The call stack items in the collection can be enumerated by calling the [ICorDebugExceptionObjectCallStackEnum::Next](icordebugexceptionobjectcallstackenum-next-method.md) method

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
