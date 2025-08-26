---
description: "Learn more about: ICLRDebugging Interface"
title: "ICLRDebugging Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebugging"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebugging"
helpviewer_keywords:
  - "ICLRDebugging interface [.NET Framework debugging]"
ms.assetid: 429d8fce-b1b1-49d7-895c-28c1c1aa2dbd
topic_type:
  - "apiref"
---
# ICLRDebugging Interface

Provides methods that handle loading and unloading modules for debugging.

## Methods

| Method | Description |
|--------|-------------|
|[OpenVirtualProcess Method](iclrdebugging-openvirtualprocess-method.md)|Gets the "ICorDebugProcess" interface that corresponds to a common language runtime (CLR) module loaded in the process.|
|[CanUnloadNow Method](iclrdebugging-canunloadnow-method.md)|Determines whether a library that was provided by an [ICLRDebuggingLibraryProvider](iclrdebugginglibraryprovider-interface.md) interface is still in use or can be unloaded.|

## Remarks

 You can obtain an instance of the `ICLRDebugging` interface by using the [CLRCreateInstance](../hosting/clrcreateinstance-function.md) function.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
