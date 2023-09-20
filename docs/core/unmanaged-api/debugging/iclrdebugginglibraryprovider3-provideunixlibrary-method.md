---
description: "Learn more about: ICLRDebuggingLibraryProvider3::ProvideUnixLibrary Method"
title: "ICLRDebuggingLibraryProvider3::ProvideUnixLibrary Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebuggingLibraryProvider3.ProvideUnixLibrary Method"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebuggingLibraryProvider3::ProvideUnixLibrary"
helpviewer_keywords:
  - "ProvideUnixLibrary method [.NET Core debugging]"
  - "ICLRDebuggingLibraryProvider3::ProvideUnixLibrary method [.NET Core debugging]"
ms.assetid: 86f06245-9517-49be-8d8c-ca5deaf34c02
topic_type:
  - "apiref"
---
# ICLRDebuggingLibraryProvider3::ProvideUnixLibrary method

Allows the debugger to provide a path to a version-specific common language runtime (CLR) debugging library on macOS and Linux.

## Syntax

```cpp
HRESULT ProvideUnixLibrary (
     [in] const WCHAR* pwszFileName,
     [in] const WCHAR* pwszRuntimeModule,
     [in] LIBRARY_PROVIDER_INDEX_TYPE indexType,
     [in] BYTE* pbBuildId,
     [in] int iBuildIdSize,
     [out] LPWSTR* ppResolvedModulePath);
```

## Parameters

`pwszFilename` \
[in] The name of the module being requested.

`pwszRuntimeModule` \
[in] The runtime or single-file module path.

`indexType` \
[in] The type of index information (pBuildId) provided. See [LIBRARY_PROVIDER_INDEX_TYPE](libraryproviderindextype-enumeration.md) enum.

`pbBuildId` \
[in] The Linux or macOS module build id. Can be null if something went wrong retrieving the build id.

`iBuildIdSize` \
[in] The number of bytes in the pbBuildId array. Can be 0 if something went wrong retrieving the build id.

`ppResolvedModulePath` \
[out] This is a null terminated path to the module dll. On Unix it should be allocated with CoTaskMemAlloc. On Unix it should be allocated with malloc. Failure leaves it untouched. See security note below!

## Return value

This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.

| HRESULT | Description                        |
|---------|------------------------------------|
| `S_OK`  | The method completed successfully. |

## Remarks

`ProvideUnixLibrary` allows the debugger to provide modules that are needed for debugging specific CLR files such as mscordbi.dll and mscordacwks.dll.

The debugger may use any available means to locate or procure the debugging module.

> [!IMPORTANT]
> This feature allows the API caller to provide modules that contain executable, and possibly malicious, code. As a security precaution, the caller should not use `ProvideUnixLibrary` to distribute any code that it is not willing to execute itself.
>
> If a serious security issue is discovered in an already released library, such as mscordbi.dll or mscordacwks.dll, the shim can be patched to recognize the bad versions of the files. The shim can then issue requests for the patched versions of the files and reject the bad versions if they are provided in response to any request. This can occur only if the user has patched to a new version of the shim. Unpatched versions will remain vulnerable.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** dbgshim.h

**Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

**.NET Versions:** Available since .NET Core 2.1
