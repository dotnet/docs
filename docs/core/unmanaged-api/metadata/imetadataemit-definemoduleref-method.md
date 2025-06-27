---
description: "Learn more about: IMetaDataEmit::DefineModuleRef Method"
title: "IMetaDataEmit::DefineModuleRef Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineModuleRef"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineModuleRef"
helpviewer_keywords:
  - "DefineModuleRef method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineModuleRef method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineModuleRef Method

Creates the metadata signature for a module with the specified name.

## Syntax

```cpp
HRESULT DefineModuleRef (
    [in]  LPCWSTR           szName,
    [out] mdModuleRef       *pmur
);
```

## Parameters

 `szName`
 [in] The name of the other metadata file, typically a DLL. This is the file name only. Do not use a full path name.

 `pmur`
 [out] The assigned `mdModuleRef` token.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
