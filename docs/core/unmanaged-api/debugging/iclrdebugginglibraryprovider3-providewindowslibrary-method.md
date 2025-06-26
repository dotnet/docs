---
description: "Learn more about: ICLRDebuggingLibraryProvider3::ProvideWindowsLibrary Method"
title: "ICLRDebuggingLibraryProvider3::ProvideWindowsLibrary Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRDebuggingLibraryProvider3.ProvideWindowsLibrary Method"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type:
  - "COM"
f1_keywords:
  - "ICLRDebuggingLibraryProvider3::ProvideWindowsLibrary"
helpviewer_keywords:
  - "ProvideWindowsLibrary method [.NET Core debugging]"
  - "ICLRDebuggingLibraryProvider3::ProvideWindowsLibrary method [.NET Core debugging]"
topic_type:
  - "apiref"
---
# ICLRDebuggingLibraryProvider3::ProvideWindowsLibrary method

Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.

## Syntax

```cpp
HRESULT ProvideWindowsLibrary (
     [in] const WCHAR* pwszFileName,
     [in] const WCHAR* pwszRuntimeModule,
     [in] LIBRARY_PROVIDER_INDEX_TYPE indexType,
     [in] DWORD dwTimestamp,
     [in] DWORD dwSizeOfImage,
     [out] LPWSTR* ppResolvedModulePath);
```

## Parameters

`pwszFilename` \
[in] The name of the module being requested.

`pwszRuntimeModule` \
[in] The runtime or single-file module path.

`indexType` \
[in] The type of index information (dwTimestamp/dwSizeOfImage) provided. See [LIBRARY_PROVIDER_INDEX_TYPE](libraryproviderindextype-enumeration.md) enum.

`dwTimestamp` \
[in] The date time stamp stored in the COFF file header of PE files.

`dwSizeOfImage` \
[in] The `SizeOfImage` field stored in the COFF optional file header of PE files.

`ppResolvedModulePath` \
[out] This is a null terminated path to the module dll. On Windows it should be allocated with CoTaskMemAlloc. On Unix it should be allocated with malloc. Failure leaves it untouched. See security note below!

## Return value

This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.

| HRESULT | Description                        |
|---------|------------------------------------|
| `S_OK`  | The method completed successfully. |

## Remarks

`ProvideWindowsLibrary` allows the debugger to provide modules that are needed for debugging specific CLR files such as mscordbi.dll and mscordacwks.dll.

The debugger may use any available means to locate or procure the debugging module.

> [!IMPORTANT]
> This feature allows the API caller to provide modules that contain executable, and possibly malicious, code. As a security precaution, the caller should not use `ProvideWindowsLibrary` to distribute any code that it is not willing to execute itself.
>
> If a serious security issue is discovered in an already released library, such as mscordbi.dll or mscordacwks.dll, the shim can be patched to recognize the bad versions of the files. The shim can then issue requests for the patched versions of the files and reject the bad versions if they are provided in response to any request. This can occur only if the user has patched to a new version of the shim. Unpatched versions will remain vulnerable.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** dbgshim.h

**Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

**.NET Versions:** Available since .NET Core 2.1
