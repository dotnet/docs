---
description: "Learn more about: IMetaDataDispenserEx::OpenScopeOnITypeInfo Method"
title: "IMetaDataDispenserEx::OpenScopeOnITypeInfo Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenserEx.OpenScopeOnITypeInfo"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenserEx::OpenScopeOnITypeInfo"
helpviewer_keywords:
  - "OpenScopeOnITypeInfo method [.NET Framework metadata]"
  - "IMetaDataDispenserEx::OpenScopeOnITypeInfo method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx::OpenScopeOnITypeInfo Method

This method is not implemented. If called, it returns E_NOTIMPL.

## Syntax

```cpp
HRESULT OpenScopeOnITypeInfo (
    [in]  ITypeInfo   *pITI,
    [in]  DWORD       dwOpenFlags,
    [in]  REFIID      riid,
    [out] IUnknown    **ppIUnk
);
```

## Parameters

 `pITI`
 [in] Pointer to an [ITypeInfo](/previous-versions/windows/desktop/api/oaidl/nn-oaidl-itypeinfo) interface that provides the type information on which to open the scope.

 `dwOpenFlags`
 [in] The open mode flags.

 `riid`
 [in] The desired interface.

 `ppIUnk`
 [out] Pointer to a pointer to the returned interface.

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
