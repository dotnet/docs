---
description: "Learn more about: ICorDebugMDA Interface"
title: "ICorDebugMDA Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMDA"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMDA"
helpviewer_keywords:
  - "ICorDebugMDA interface [.NET Framework debugging]"
ms.assetid: 8ecbb854-295c-4dd4-b9fc-01ebeac46e06
topic_type:
  - "apiref"
---
# ICorDebugMDA Interface

Represents a managed debugging assistant (MDA) message.

## Methods

|Method|Description|
|------------|-----------------|
|[GetDescription Method](icordebugmda-getdescription-method.md)|Gets a string containing a description of this MDA.|
|[GetFlags Method](icordebugmda-getflags-method.md)|Gets the flags associated with this MDA.|
|[GetName Method](icordebugmda-getname-method.md)|Gets a string containing the name of this MDA.|
|[GetOSThreadId Method](icordebugmda-getosthreadid-method.md)|Gets the operating system thread identifier upon which this MDA is executing.|
|[GetXML Method](icordebugmda-getxml-method.md)|Gets the full XML stream associated with this MDA.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Diagnosing Errors with Managed Debugging Assistants](../../debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
