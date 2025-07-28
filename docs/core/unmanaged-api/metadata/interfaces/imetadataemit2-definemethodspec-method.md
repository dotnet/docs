---
description: "Learn more about: IMetaDataEmit2::DefineMethodSpec Method"
title: "IMetaDataEmit2::DefineMethodSpec Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.DefineMethodSpec"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::DefineMethodSpec"
  - "IMetaDataEmit2::DefineMethodSpec method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::DefineMethodSpec Method

Creates a generic instance of a method, and gets a token to the definition.

## Syntax

```cpp
HRESULT DefineMethodSpec (
    [in]  mdToken           tkParent,
    [in]  PCCOR_SIGNATURE   pvSigBlob,
    [in]  ULONG             cbSigBlob,
    [out] mdMethodSpec      *pmi
);
```

## Parameters

 `tkParent`
 [in] A token for the method of which to create the generic instance. The token must be of type `mdMethodDef` or `mdMemberRef`.

 `pvSigBlob`
 [in] A pointer to the binary COM+ signature of the method.

 `cbSibBlob`
 [in] The size, in bytes, of `pvSigBlob`.

 `pmi`
 [out] A token to the metadata signature definition of the method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
