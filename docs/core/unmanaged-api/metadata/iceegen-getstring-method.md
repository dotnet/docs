---
description: "Learn more about: ICeeGen::GetString Method"
title: "ICeeGen::GetString Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.GetString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::GetString"
helpviewer_keywords:
  - "ICeeGen::GetString method [.NET Framework metadata]"
  - "GetString method, ICeeGen interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::GetString Method

Gets the string stored at the specified relative virtual address.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT GetString (
    [in]  ULONG      RVA,
    [out] LPWSTR     *lpString
);
```

## Parameters

 `RVA`
 [in] The relative virtual address of the string to return.

 `lpString`
 [out] The returned string.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)
