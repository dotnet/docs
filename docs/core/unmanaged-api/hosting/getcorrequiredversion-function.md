---
description: "Learn more about: GetCORRequiredVersion Function"
title: "GetCORRequiredVersion Function"
ms.date: "03/30/2017"
api_name:
  - "GetCORRequiredVersion"
api_location:
  - "mscoree.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "GetCORRequiredVersion"
helpviewer_keywords:
  - "GetCORRequiredVersion function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# GetCORRequiredVersion Function

Gets the required common language runtime (CLR) version number.

 This function has been deprecated in the .NET Framework 4.

## Syntax

```cpp
HRESULT GetCORRequiredVersion (
    [out] LPWSTR   pbuffer,
    [in]  DWORD    cchBuffer,
    [out] DWORD   *dwLength
);
```

## Parameters

 `pbuffer`
 [out] A buffer containing a string that specifies the version number.

 `cchBuffer`
 [in] The size, in bytes, of the buffer.

 `dwLength`
 [out] The number of bytes returned in the buffer.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
