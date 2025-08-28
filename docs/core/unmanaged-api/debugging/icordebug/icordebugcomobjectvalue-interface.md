---
description: "Learn more about: ICorDebugComObjectValue Interface"
title: "ICorDebugComObjectValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugComObjectValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugComObjectValue"
helpviewer_keywords:
  - "ICorDebugComObjectValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugComObjectValue Interface

Provides methods to retrieve information associated with a runtime callable wrapper (RCW).

## Methods

|Method|Description|
|------------|-----------------|
|[GetCachedInterfacePointers Method](icordebugcomobjectvalue-getcachedinterfacepointers-method.md)|Gets the raw interface pointers cached on the current RCW.|
|[GetCachedInterfaceTypes Method](icordebugcomobjectvalue-getcachedinterfacetypes-method.md)|Provides an enumerator for the interface types that the current object has been cased to or used as.|

## Remarks

 To check whether an instance of an "ICorDebugValue" interface represents an RCW, a debugger calls `QueryInterface` on "ICorDebugValue" with `IID_ICorDebugComObjectValue`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
