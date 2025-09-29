---
description: "Learn more about: ICorDebugChainEnum Interface"
title: "ICorDebugChainEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChainEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChainEnum"
helpviewer_keywords:
  - "ICorDebugChainEnum interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChainEnum Interface

Implements ICorDebugEnum methods, and enumerates ICorDebugChain arrays.

## Methods

|Method|Description|
|------------|-----------------|
|[Next Method](icordebugchainenum-next-method.md)|Gets the specified number of `ICorDebugChain` instances from the enumeration, starting at the current position.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
