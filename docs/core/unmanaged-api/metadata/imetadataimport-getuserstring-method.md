---
description: "Learn more about: IMetaDataImport::GetUserString Method"
title: "IMetaDataImport::GetUserString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetUserString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetUserString"
helpviewer_keywords:
  - "IMetaDataImport::GetUserString method [.NET Framework metadata]"
  - "GetUserString method, IMetaDataImport interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetUserString Method

Gets the literal string represented by the specified metadata token.

## Syntax

```cpp
HRESULT GetUserString (
   [in]   mdString    stk,
   [out]  LPWSTR      szString,
   [in]   ULONG       cchString,
   [out]  ULONG       *pchString
);
```

## Parameters

 `stk`
 [in] The String token to return the associated string for.

 `szString`
 [out] A copy of the requested string.

 `cchString`
 [in] The maximum size in wide characters of the requested `szString`.

 `pchString`
 [out] The size in wide characters of the returned `szString`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
