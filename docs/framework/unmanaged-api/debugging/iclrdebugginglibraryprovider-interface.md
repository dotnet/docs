---
description: "Learn more about: ICLRDebuggingLibraryProvider Interface"
title: "ICLRDebuggingLibraryProvider Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebuggingLibraryProvider"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebuggingLibraryProvider"
helpviewer_keywords:
  - "ICLRDebuggingLibraryProvider interface [.NET Framework debugging]"
ms.assetid: 67739617-6add-41a9-9de5-a3200c3109ce
topic_type:
  - "apiref"
---
# ICLRDebuggingLibraryProvider Interface

Includes the [ProvideLibrary Method](iclrdebugginglibraryprovider-providelibrary-method.md) method, which gets a library provider callback interface that allows common language runtime version-specific debugging libraries to be located and loaded on demand.

## Methods

|Method|Description|
|------------|-----------------|
|[ProvideLibrary Method](iclrdebugginglibraryprovider-providelibrary-method.md)|Allows the debugger to provide a handle to a module which can be used to load a debug library.|

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICLRDebuggingLibraryProvider2 Interface](../../../core/unmanaged-api/debugging/iclrdebugginglibraryprovider2-interface.md)
- [ICLRDebuggingLibraryProvider3 Interface](../../../core/unmanaged-api/debugging/iclrdebugginglibraryprovider3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
