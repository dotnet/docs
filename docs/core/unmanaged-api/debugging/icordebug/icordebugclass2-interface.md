---
description: "Learn more about: ICorDebugClass2 Interface"
title: "ICorDebugClass2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugClass2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugClass2"
helpviewer_keywords:
  - "ICorDebugClass2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugClass2 Interface

Represents a generic class or a class with a method parameter of type <xref:System.Type>. This interface extends [ICorDebugClass](icordebugclass-interface.md).

## Methods

|Method|Description|
|------------|-----------------|
|[GetParameterizedType Method](icordebugclass2-getparameterizedtype-method.md)|Gets the type declaration for this class.|
|[SetJMCStatus Method](icordebugclass2-setjmcstatus-method.md)|For each method of this class, sets a value that indicates whether the method is user-defined code.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugClass Interface](icordebugclass-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
