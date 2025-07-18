---
description: "Learn more about: IMetaDataAssemblyImport::GetAssemblyFromScope Method"
title: "IMetaDataAssemblyImport::GetAssemblyFromScope Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.GetAssemblyFromScope"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::GetAssemblyFromScope"
helpviewer_keywords:
  - "IMetaDataAssemblyImport::GetAssemblyFromScope method [.NET Framework metadata]"
  - "GetAssemblyFromScope method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::GetAssemblyFromScope Method

Gets a pointer to the assembly in the current scope.

## Syntax

```cpp
HRESULT GetAssemblyFromScope (
    [out] mdAssembly  *ptkAssembly
);
```

## Parameters

 `ptkAssembly`
 [out] A pointer to the retrieved `mdAssembly` token that identifies the assembly.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
