---
description: "Learn more about: IMetaDataEmit::SetModuleProps Method"
title: "IMetaDataEmit::SetModuleProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetModuleProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetModuleProps"
helpviewer_keywords:
  - "SetModuleProps method [.NET Framework metadata]"
  - "IMetaDataEmit::SetModuleProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetModuleProps Method

Updates references to a module defined by a prior call to [IMetaDataEmit::DefineModuleRef](imetadataemit-definemoduleref-method.md).

## Syntax

```cpp
HRESULT SetModuleProps (
    [in]  LPCWSTR     szName
);
```

## Parameters

 `szName`
 [in] The module name in Unicode. This is the file name only and not the full path name.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
