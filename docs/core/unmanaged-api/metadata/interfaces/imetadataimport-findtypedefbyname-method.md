---
description: "Learn more about: IMetaDataImport::FindTypeDefByName Method"
title: "IMetaDataImport::FindTypeDefByName Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.FindTypeDefByName"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::FindTypeDefByName"
  - "IMetaDataImport::FindTypeDefByName method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::FindTypeDefByName Method

Gets a pointer to the TypeDef metadata token for the <xref:System.Type> with the specified name.

## Syntax

```cpp
HRESULT FindTypeDefByName
   [in]  LPCWSTR       szTypeDef,
   [in]  mdToken       tkEnclosingClass,
   [out] mdTypeDef     *ptd
);
```

## Parameters

 `szTypeDef`
 [in] The name of the type for which to get the TypeDef token.

 `tkEnclosingClass`
 [in] A TypeDef or TypeRef token representing the enclosing class. If the type to find is not a nested class, set this value to NULL.

 `ptd`
 [out] A pointer to the matching TypeDef token.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
