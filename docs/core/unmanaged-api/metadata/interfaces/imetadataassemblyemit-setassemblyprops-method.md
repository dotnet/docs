---
description: "Learn more about: IMetaDataAssemblyEmit::SetAssemblyProps Method"
title: "IMetaDataAssemblyEmit::SetAssemblyProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyEmit.SetAssemblyProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyEmit::SetAssemblyProps"
  - "IMetaDataAssemblyEmit::SetAssemblyProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyEmit::SetAssemblyProps Method

Modifies the specified `Assembly` metadata structure.

## Syntax

```cpp
HRESULT SetAssemblyProps (
    [in] mdAssembly               pma,
    [in] const void               *pbPublicKey,
    [in] ULONG                    cbPublicKey,
    [in] ULONG                    ulHashAlgId,
    [in] LPCWSTR                  szName,
    [in] const ASSEMBLYMETADATA   *pMetaData,
    [in] DWORD                    dwAssemblyFlags
);
```

## Parameters

 `pma`
 [in] The metadata token that specifies the `Assembly` metadata structure to be modified.

 `pbPublicKey`
 [in] A pointer to the public key of the publisher of the assembly.

 `cbPublicKey`
 [in] The size in bytes of `pbPublicKey`.

 `ulHashAlgId`
 [in] The identifier for the hash algorithm used to hash the assembly files.

 `szName`
 [in] The human-readable text name of the assembly.

 `pMetaData`
 [in] A pointer to the ASSEMBLYMETADATA that contains version, platform, and locale information for the assembly.

 `dwAssemblyFlags`
 [in] A bitwise combination of [CorAssemblyFlags](../enumerations/corassemblyflags-enumeration.md) values that specify various attributes of the assembly.

## Remarks

 To create an `Assembly` metadata structure, use the [IMetaDataAssemblyEmit::DefineAssembly](imetadataassemblyemit-defineassembly-method.md) method.

## Requirements

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
