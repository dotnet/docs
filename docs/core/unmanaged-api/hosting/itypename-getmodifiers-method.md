---
description: "Learn more about: ITypeName::GetModifiers Method"
title: "ITypeName::GetModifiers Method"
ms.date: "03/30/2017"
api_name:
  - "ITypeName.GetModifiers"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "GetModifiers"
helpviewer_keywords:
  - "ITypeName::GetModifiers method [.NET Framework hosting]"
  - "GetModifiers method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ITypeName::GetModifiers Method

This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.

## Syntax

```cpp
HRESULT GetModifiers (
    [in] DWORD           count,
    [out] DWORD*         rgModifiers,
    [out, retval] DWORD* pCount
);
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Interfaces](hosting-interfaces.md)
