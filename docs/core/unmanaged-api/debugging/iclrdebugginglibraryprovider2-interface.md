---
description: "Learn more about: ICLRDebuggingLibraryProvider2 Interface"
title: "ICLRDebuggingLibraryProvider2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebuggingLibraryProvider2"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebuggingLibraryProvider2"
helpviewer_keywords:
  - "ICLRDebuggingLibraryProvider2 interface [.NET Core debugging]"
topic_type:
  - "apiref"
---
# ICLRDebuggingLibraryProvider2 interface

Includes the [ProvideLibrary2](iclrdebugginglibraryprovider2-providelibrary2-method.md) method, which allows the debugger to provide a path to a version-specific debugging library.

## Methods

|Method|Description|
|------------|-----------------|
|[ProvideLibrary2](iclrdebugginglibraryprovider2-providelibrary2-method.md)|Allows the debugger to provide a path to a version-specific debugging library.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** Available since .NET Core 2.1

## See also

- [ICLRDebuggingLibraryProvider3 interface](iclrdebugginglibraryprovider3-interface.md)
- [ICLRDebuggingLibraryProvider interface](../../../framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-interface.md)
