---
description: "Learn more about: ICorDebugExceptionObjectValue Interface"
title: "ICorDebugExceptionObjectValue Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugExceptionObjectValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugExceptionObjectValue"
helpviewer_keywords:
  - "ICorDebugExceptionObjectValue interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugExceptionObjectValue Interface

Extends the "ICorDebugObjectValue" interface to provide stack trace information from a managed exception object.

## Methods

|Method|Description|
|------------|-----------------|
|[EnumerateExceptionCallStack Method](icordebugexceptionobjectvalue-enumerateexceptioncallstack-method.md)|Gets an enumerator to the call stack embedded in an exception object.|

## Remarks

The call to `QueryInterface` will succeed for managed objects that derive from <xref:System.Exception?displayProperty=nameWithType>.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
