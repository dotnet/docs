---
description: "Learn more about: ICorRuntimeHost::MapFile Method"
title: "ICorRuntimeHost::MapFile Method"
ms.date: "03/30/2017"
api_name:
  - "ICorRuntimeHost.MapFile"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorRuntimeHost::MapFile"
helpviewer_keywords:
  - "ICorRuntimeHost::MapFile method [.NET Framework hosting]"
  - "MapFile method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorRuntimeHost::MapFile Method

Maps the specified file into memory. This method is obsolete.

## Syntax

```cpp
HRESULT MapFile(
    [in]  HANDLE    hFile,
    [out] HMODULE*  hMapAddress
);
```

## Parameters

 `hFile`
 [in] The handle of the file to be mapped.

 `hMapAddress`
 [out] The starting memory address at which to begin mapping the file.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET Framework Version:** 1.0, 1.1

## See also

- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
