---
description: "Learn more about: IMetaDataEmit::SetPinvokeMap Method"
title: "IMetaDataEmit::SetPinvokeMap Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetPinvokeMap"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetPinvokeMap"
  - "SetPinvokeMap method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetPinvokeMap Method

Sets or changes features of a method's PInvoke signature, as defined by a prior call to [IMetaDataEmit::DefinePinvokeMap](imetadataemit-definepinvokemap-method.md).

## Syntax

```cpp
HRESULT SetPinvokeMap (
    [in]  mdToken      tk,
    [in]  DWORD        dwMappingFlags,
    [in]  LPCWSTR      szImportName,
    [in]  mdModuleRef  mrImportDLL
);
```

## Parameters

 `tk`
 [in] The `mdToken` to which mapping information applies.

 `dwMappingFlags`
 [in] Flags used by PInvoke to do the mapping. This is a bitmask of `CorPinvokeMap` values.

 `szImportName`
 [in] The name of the target export in the native DLL.

 `mrImportDLL`
 [in] The `mdModuleRef` token for the target unmanaged DLL.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
