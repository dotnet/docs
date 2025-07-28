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
  - "IMetaDataEmit::DefinePinvokeMap method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
