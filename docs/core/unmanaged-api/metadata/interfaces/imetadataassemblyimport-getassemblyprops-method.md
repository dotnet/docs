---
description: "Learn more about: IMetaDataAssemblyImport::GetAssemblyProps Method"
title: "IMetaDataAssemblyImport::GetAssemblyProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.GetAssemblyProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::GetAssemblyProps"
  - "IMetaDataAssemblyImport::GetAssemblyProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::GetAssemblyProps Method

Gets the set of properties for the assembly with the specified metadata signature.

## Syntax

```cpp
HRESULT GetAssemblyProps (
    [in]  mdAssembly          mda,
    [out] const void          **ppbPublicKey,
    [out] ULONG               *pcbPublicKey,
    [out] ULONG               *pulHashAlgId,
    [out] LPWSTR              szName,
    [in] ULONG                cchName,
    [out] ULONG               *pchName,
    [out] ASSEMBLYMETADATA    *pMetaData,
    [out] DWORD               *pdwAssemblyFlags
);
```

## Parameters

 `mda`
 [in]. The `mdAssembly` metadata token that represents the assembly for which to get the properties.

 `ppbPublicKey`
 [out] A pointer to the public key or the metadata token.

 `pcbPublicKey`
 [out] The number of bytes in the returned public key.

 `pulHashAlgId`
 [out] A pointer to the algorithm used to hash the files in the assembly.

 `szName`
 [out] The simple name of the assembly.

 `cchName`
 [in] The size, in wide chars, of `szName`.

 `pchName`
 [out] The number of wide chars actually returned in `szName`.

 `pMetaData`
 [out] A pointer to an ASSEMBLYMETADATA structure that contains the assembly metadata.

 `pdwAssemblyFlags`
 [out] Flags that describe the metadata applied to an assembly. This value is a combination of one or more [CorAssemblyFlags](../enumerations/corassemblyflags-enumeration.md) values.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
