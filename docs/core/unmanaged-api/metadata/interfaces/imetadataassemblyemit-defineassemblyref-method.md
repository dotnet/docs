---
description: "Learn more about: IMetaDataAssemblyEmit::DefineAssemblyRef Method"
title: "IMetaDataAssemblyEmit::DefineAssemblyRef Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyEmit.DefineAssemblyRef"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyEmit::DefineAssemblyRef"
  - "IMetaDataAssemblyEmit::DefineAssemblyRef method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyEmit::DefineAssemblyRef Method

Creates an `AssemblyRef` structure containing metadata for the assembly that this assembly references, and returns the associated metadata token.

## Syntax

```cpp
HRESULT DefineAssemblyRef (
    [in]  void                *pbPublicKeyOrToken,
    [in]  ULONG               cbPublicKeyOrToken,
    [in]  LPCWSTR             szName,
    [in]  ASSEMBLYMETADATA    pMetaData,
    [in]  void                *pbHashValue,
    [in]  ULONG               cbHashValue,
    [in]  DWORD               dwAssemblyRefFlags,
    [out] mdAssemblyRef       *pmdar
);
```

## Parameters

 `pbPublicKeyOrToken`
 [in] The public key of the publisher of the referenced assembly. The helper function [StrongNameTokenFromAssembly](../../../../framework/unmanaged-api/strong-naming/strongnametokenfromassembly-function.md) can be used to get the hash of the public key to pass as this parameter.

 `cbPublicKeyOrToken`
 [in] The size in bytes of `pbPublicKeyOrToken`.

 `szName`
 [in] The human-readable text name of the assembly. This value must not exceed 1024 characters.

 `pMetaData`
 [in] An ASSEMBLYMETADATA instance that contains the version, platform and locale information of the referenced assembly.

 `pbHashValue`
 [in] The hash data associated with the referenced assembly. Optional.

 `cbHashValue`
 [in] The size in bytes of `pbHashValue`.

 `dwAssemblyRefFlags`
 [in] A bitwise combination of [CorAssemblyFlags](../enumerations/corassemblyflags-enumeration.md) values that influence the behavior of the execution engine.

 `pmdar`
 [out] A pointer to the returned `AssemblyRef` metadata token.

## Remarks

 One `AssemblyRef` metadata structure must be defined for each assembly that this assembly references.

 At run time, the details of a referenced assembly are passed to the assembly resolver with an indication that they represent the "as built" information. The assembly resolver then applies policy.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
