---
description: "Learn more about: ICorDebugProcess3 Interface"
title: "ICorDebugProcess3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess3"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess3"
helpviewer_keywords:
  - "ICorDebugProcess3 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess3 Interface

Controls custom debugger notifications.

## Methods

|Method|Description|
|------------|-----------------|
|[SetEnableCustomNotification Method](icordebugprocess3-setenablecustomnotification-method.md)|Enables and disables custom debugger notifications of the specified type.|

## Remarks

 This interface logically extends the ICorDebugProcess and ICorDebugProcess2 interfaces.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
