---
description: "Learn more about: CallFunctionShim Function"
title: "CallFunctionShim Function"
ms.date: "03/30/2017"
api_name:
  - "CallFunctionShim"
api_location:
  - "mscoree.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "CallFunctionShim"
helpviewer_keywords:
  - "CallfunctionShim function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# CallFunctionShim Function

Makes a call to the function that has the specified name and parameters in the specified library.

 This function has been deprecated in the .NET Framework 4.

## Syntax

```cpp
HRESULT CallFunctionShim (
    [in] LPCWSTR     szDllName,
    [in] LPCSTR      szFunctionName,
    [in] LPVOID      lpvArgument1,
    [in] LPVOID      lpvArgument2,
    [in] LPCWSTR     szVersion,
    [in] LPVOID      pvReserved
);
```

## Parameters

 `szDllName`
 [in] The name of the library containing the function.

 `szFunctionName`
 [in] The name of the function.

 `lpvArgument1`
 [in] The first argument to pass to the function.

 `lpvArgument2`
 [in] The second argument to pass to the function.

 `szVersion`
 [in] The version of the library that contains the function.

 `pvReserved`
 [in] Reserved for future use. Pass zero in this parameter.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
