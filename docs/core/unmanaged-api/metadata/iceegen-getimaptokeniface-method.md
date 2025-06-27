---
description: "Learn more about: ICeeGen::GetIMapTokenIface Method"
title: "ICeeGen::GetIMapTokenIface Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.GetIMapTokenIface"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::GetIMapTokenIface"
helpviewer_keywords:
  - "GetIMapTokenIface method [.NET Framework metadata]"
  - "ICeeGen::GetIMapTokenIface method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::GetIMapTokenIface Method

Gets the interface referenced by the specified token.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT GetIMapTokenIface (
    [in, out] IUnknown   **pIMapToken
);
```

## Parameters

 `pIMapToken`
 [in, out] The metadata token for the interface to be returned.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)
