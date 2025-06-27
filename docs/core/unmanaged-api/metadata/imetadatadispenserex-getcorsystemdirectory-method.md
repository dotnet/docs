---
description: "Learn more about: IMetaDataDispenserEx::GetCORSystemDirectory Method"
title: "IMetaDataDispenserEx::GetCORSystemDirectory Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenserEx.GetCORSystemDirectory"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenserEx::GetCORSystemDirectory"
helpviewer_keywords:
  - "IMetaDataDispenserEx::GetCORSystemDirectory method [.NET Framework metadata]"
  - "GetCORSystemDirectory method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx::GetCORSystemDirectory Method

Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by out-of-process debuggers. If called from another component, it will return E_NOTIMPL.

## Syntax

```cpp
HRESULT GetCORSystemDirectory (
    [out] LPWSTR      szBuffer,
    [in]  DWORD       cchBuffer,
    [out] DWORD*      pchBuffer
);
```

## Parameters

 `szBuffer`
 [out] The buffer to receive the directory name.

 `cchBuffer`
 [in] The size, in bytes, of `szBuffer`.

 `pchBuffer`
 [out] The number of bytes actually returned in `szBuffer`.

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
