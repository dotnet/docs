---
description: "Learn more about: IMetaDataAssemblyEmit::SetAssemblyRefProps Method"
title: "IMetaDataAssemblyEmit::SetAssemblyRefProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyEmit.SetAssemblyRefProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyEmit::SetAssemblyRefProps"
  - "IMetaDataAssemblyEmit::SetAssemblyRefProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyEmit::SetAssemblyRefProps Method

Modifies the specified `AssemblyRef` metadata structure.

## Syntax

```cpp
HRESULT SetAssemblyRefProps (
    [in] mdAssemblyRef              ar,
    [in] const void                 *pbPublicKeyOrToken,
    [in] ULONG                      cbPublicKeyOrToken,
    [in] LPCWSTR                    szName,
    [in] const ASSEMBLYMETADATA     *pMetaData,
    [in] const void                 *pbHashValue,
    [in] ULONG                      cbHashValue,
    [in] DWORD                      dwAssemblyRefFlags
);
```

## Parameters

 `ar`
 [in] The metadata token that specifies the `AssemblyRef` metadata structure to be modified.

 `pbPublicKeyOrToken`
 [in] The public key of the publisher of the referenced assembly.

 `cbPublicKeyOrToken`
 [in] The size in bytes of `pbPublicKeyOrToken`.

 `szName`
 [in] The human-readable text name of the assembly.

 `pMetaData`
 [in] A pointer to an ASSEMBLYMETADATA instance that contains the version, platform, and locale information for the assembly.

 `pbHashValue`
 [in] A pointer to the hash data associated with the assembly.

 `cbHashValue`
 [in] The size in bytes of `pbHashValue`.

 `dwAssemblyRefFlags`
 [in] A bitwise combination of [AssemblyRefFlags](../enumerations/assemblyrefflags-enumeration.md) values that specify attributes of the referenced assembly.

## Remarks

 To create an `AssemblyRef` metadata structure, use the [IMetaDataAssemblyEmit::DefineAssemblyRef](imetadataassemblyemit-defineassemblyref-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
