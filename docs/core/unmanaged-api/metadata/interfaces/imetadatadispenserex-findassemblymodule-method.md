---
description: "Learn more about: IMetaDataDispenserEx::FindAssemblyModule Method"
title: "IMetaDataDispenserEx::FindAssemblyModule Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenserEx.FindAssemblyModule"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenserEx::FindAssemblyModule"
  - "IMetaDataDispenserEx::FindAssemblyModule method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx::FindAssemblyModule Method

This method is not implemented. If called, it returns E_NOTIMPL.

## Syntax

```cpp
HRESULT FindAssemblyModule(
    [in]  LPCWSTR  szAppBase,
    [in]  LPCWSTR  szPrivateBin,
    [in]  LPCWSTR  szGlobalBin,
    [in]  LPCWSTR  szAssemblyName,
    [in]  LPCWSTR  szModuleName,
    [out] LPCWSTR  szName,
    [in]  ULONG    cchName,
    [out] ULONG    *pcName
);
```

## Parameters

 `szAppBase`
 [in] Not used.

 `szPrivateBin`
 [in] Not used.

 `szGlobalBin`
 [in] Not used.

 `szAssemblyName`
 [in] The name of the module.

 `szModuleName`
 [in] The assembly to be found.

 `szName`
 [out] The simple name of the assembly.

 `cchName`
 [in] The size, in bytes, of `szName`.

 `pcName`
 [out] The number of characters actually returned in `szName`.

## Requirements

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
