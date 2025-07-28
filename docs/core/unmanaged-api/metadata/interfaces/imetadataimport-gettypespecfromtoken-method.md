---
description: "Learn more about: IMetaDataImport::GetTypeSpecFromToken Method"
title: "IMetaDataImport::GetTypeSpecFromToken Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetTypeSpecFromToken"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetTypeSpecFromToken"
  - "IMetaDataImport::GetTypeSpecFromToken method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetTypeSpecFromToken Method

Gets the binary metadata signature of the type specification represented by the specified token.

## Syntax

```cpp
HRESULT GetTypeSpecFromToken (
   [in]  mdTypeSpec            typespec,
   [out] PCCOR_SIGNATURE       *ppvSig,
   [out] ULONG                 *pcbSig
);
```

## Parameters

 `typespec`
 [in] The TypeSpec token associated with the requested metadata signature.

 `ppvSig`
 [out] A pointer to the binary metadata signature.

 `pcbSig`
 [out] The size, in bytes, of the metadata signature.

## Return Value

 An HRESULT that indicates success or failure. Failures can be tested with the FAILED macro.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
