---
description: "Learn more about: IObjectHandle::Unwrap Method"
title: "IObjectHandle::Unwrap Method"
ms.date: "03/30/2017"
api_name:
  - "IObjectHandle.Unwrap"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "Unwrap"
helpviewer_keywords:
  - "Unwrap method [.NET Framework hosting]"
  - "IObjectHandle::Unwrap method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IObjectHandle::Unwrap Method

Unwraps a marshal-by-value object from indirection.

## Syntax

```cpp
HRESULT Unwrap (
    [out, retval] VARIANT *ppv
);
```

## Parameters

 `ppv`
 [out] A pointer to the object to be unwrapped.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0
