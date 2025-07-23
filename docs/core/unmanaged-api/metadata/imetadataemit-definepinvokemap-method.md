---
description: "Learn more about: IMetaDataEmit::DefinePinvokeMap Method"
title: "IMetaDataEmit::DefinePinvokeMap Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefinePinvokeMap"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefinePinvokeMap"
  - "IMetaDataEmit::DefinePinvokeMap method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefinePinvokeMap Method

Sets features of the PInvoke signature of the method referenced by the specified token.

## Syntax

```cpp
HRESULT DefinePinvokeMap (
    [in]  mdToken            tk,
    [in]  DWORD              dwMappingFlags,
    [in]  LPCWSTR            szImportName,
    [in]  mdModuleRef        mrImportDLL
);
```

## Parameters

 `tk`
 [in] The token for the target method.

 `dwMappingFlags`
 [in] Flags used by PInvoke to do the mapping.

 `szImportName`
 [in] The name of the target export method in an unmanaged DLL.

 `mrImportDLL`
 [in] The token for the target native DLL.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
