---
description: "Learn more about: IMetaDataEmit::TranslateSigWithScope Method"
title: "IMetaDataEmit::TranslateSigWithScope Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.TranslateSigWithScope"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::TranslateSigWithScope"
  - "IMetaDataEmit::TranslateSigWithScope method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::TranslateSigWithScope Method

Imports an assembly into the current scope and gets a new metadata signature for the merged scope.

## Syntax

```cpp
HRESULT TranslateSigWithScope (
    [in]  IMetaDataAssemblyImport   *pAssemImport,
    [in]  const void                *pbHashValue,
    [in]  ULONG                     cbHashValue,
    [in]  IMetaDataImport           *import,
    [in]  PCCOR_SIGNATURE           pbSigBlob,
    [in]  ULONG                     cbSigBlob,
    [in]  IMetaDataAssemblyEmit     *pAssemEmit,
    [in]  IMetaDataEmit             *emit,
    [out] PCOR_SIGNATURE            pvTranslatedSig,
    [in]  ULONG                     cbTranslatedSigMax,
    [out] ULONG                     *pcbTranslatedSig
);
```

## Parameters

 `pAssemImport`
 [in] The interface for import assembly (where the signature is defined).

 `pbHashValue`
 [in] The hash blob for the assembly.

 `cbHashValue`
 [in] The count of bytes in `pbHashValue`.

 `import`
 [in] The interface for import metadata scope.

 `pbSigBlob`
 [in] The signature to be imported.

 `cbSigBlob`
 [in] The size, in bytes, of `pbSigBlob`.

 `pAssemEmit`
 [in] The interface for export assembly.

 `emit`
 [in] The interface for export metadata scope.

 `pvTranslatedSig`
 [out] The buffer to hold the translated signature blob.

 `cbTranslatedSigMax`
 [in] The capacity, in bytes, of `pvTranslatedSig`.

 `pcbTranslatedSig`
 [out] The number of actual bytes in the translated signature.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
