---
description: "Learn more about: IMetaDataImport::IsValidToken Method"
title: "IMetaDataImport::IsValidToken Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.IsValidToken"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::IsValidToken"
helpviewer_keywords:
  - "IMetaDataImport::IsValidToken method [.NET Framework metadata]"
  - "IsValidToken method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::IsValidToken Method

Gets a value indicating whether the specified token holds a valid reference to a code object.

## Syntax

```cpp
BOOL IsValidToken (
   [in] mdToken     tk
);
```

## Parameters

 `tk`
 [in] The token to check the reference validity for.

## Return Value

 `true` if `tk` is a valid metadata token within the current scope. Otherwise, `false`.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
