---
description: "Learn more about: ICLRDebuggingLibraryProvider3 Interface"
title: "ICLRDebuggingLibraryProvider3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebuggingLibraryProvider3"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebuggingLibraryProvider3"
helpviewer_keywords:
  - "ICLRDebuggingLibraryProvider3 interface [.NET Core debugging]"
ms.assetid: 67739617-6add-41a9-9de5-a3200c3109ce
topic_type:
  - "apiref"
---
# ICLRDebuggingLibraryProvider3 interface

Includes callback methods that allow common language runtime version-specific debugging libraries to be located and loaded on demand for .NET Core regular and single-file applications. This interface is required by the [RegisterForRuntimeStartup3](../../../core/unmanaged-api/debugging/registerforruntimestartup3-function.md) and [CreateDebuggingInterfaceFromVersion3](../../../core/unmanaged-api/debugging/createdebugginginterfacefromversion3-function.md) methods. It is supported by the `ICLRDebugging::OpenVirtualProcess` method acquired with dbgshim's [CLRCreateInstance](../../../core/unmanaged-api/debugging/clrcreateinstance-function.md) API.

## Methods

|Method|Description|
|------------|-----------------|
|[ProvideWindowsLibrary](iclrdebugginglibraryprovider3-providewindowslibrary-method.md)|Allows the debugger to provide a path to a version-specific Windows debugging library.|
|[ProvideUnixLibrary](iclrdebugginglibraryprovider3-provideunixlibrary-method.md)|Allows the debugger to provide a path to a version-specific Linux or macOS debugging library.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** Available since .NET 6.0

## See also

- [ICLRDebuggingLibraryProvider2 interface](iclrdebugginglibraryprovider2-interface.md)
- [ICLRDebuggingLibraryProvider interface](../../../framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-interface.md)
