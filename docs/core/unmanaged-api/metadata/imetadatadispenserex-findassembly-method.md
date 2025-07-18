---
description: "Learn more about: IMetaDataDispenserEx::FindAssembly Method"
title: "IMetaDataDispenserEx::FindAssembly Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenserEx.FindAssembly"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenserEx::FindAssembly"
helpviewer_keywords:
  - "FindAssembly method [.NET Framework metadata]"
  - "IMetaDataDispenserEx::FindAssembly method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx::FindAssembly Method

This method is not implemented. If called, it returns E_NOTIMPL.

## Syntax

```cpp
HRESULT FindAssembly(
    [in]  LPCWSTR  szAppBase,
    [in]  LPCWSTR  szPrivateBin,
    [in]  LPCWSTR  szGlobalBin,
    [in]  LPCWSTR  szAssemblyName,
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
 [in] The assembly to be found.

 `szName`
 [out] The simple name of the assembly.

 `cchName`
 [in] The size, in bytes, of `szName`.

 `pcName`
 [out] The number of characters actually returned in `szName`.

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
