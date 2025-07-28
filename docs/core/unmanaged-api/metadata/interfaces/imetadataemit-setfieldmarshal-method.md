---
description: "Learn more about: IMetaDataEmit::SetFieldMarshal Method"
title: "IMetaDataEmit::SetFieldMarshal Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetFieldMarshal"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetFieldMarshal"
  - "IMetaDataEmit::SetFieldMarshal method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetFieldMarshal Method

Sets the PInvoke marshalling information for the field, method return, or method parameter referenced by the specified token.

## Syntax

```cpp
HRESULT SetFieldMarshal (
    [in]  mdToken          tk,
    [in]  PCCOR_SIGNATURE  pvNativeType,
    [in]  ULONG            cbNativeType
);
```

## Parameters

 `tk`
 [in] The token for target data item. This is either a `mdFieldDef` or a `mdParamDef` token.

 `pvNativeType`
 [in] The signature for unmanaged type.

 `cbNativeType`
 [in] The count of bytes in `pvNativeType`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
