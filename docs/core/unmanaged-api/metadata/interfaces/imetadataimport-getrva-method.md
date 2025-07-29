---
description: "Learn more about: IMetaDataImport::GetRVA Method"
title: "IMetaDataImport::GetRVA Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetRVA"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetRVA"
  - "IMetaDataImport::GetRVA method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetRVA Method

Gets the relative virtual address (RVA) and the implementation flags of the method or field represented by the specified token.

## Syntax

```cpp
HRESULT GetRVA (
   [in]  mdToken     tk,
   [out] ULONG       *pulCodeRVA,
   [out]  DWORD      *pdwImplFlags
);
```

## Parameters

 `tk`
 [in] A MethodDef or FieldDef metadata token that represents the code object to return the RVA for. If the token is a FieldDef, the field must be a global variable.

 `pulCodeRVA`
 [out] A pointer to the relative virtual address of the code object represented by the token.

 `pdwImplFlags`
 [out] A pointer to the implementation flags for the method. This value is a bitmask from the [CorMethodImpl](../enumerations/cormethodimpl-enumeration.md) enumeration. The value of `pdwImplFlags` is valid only if `tk` is a MethodDef token.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
