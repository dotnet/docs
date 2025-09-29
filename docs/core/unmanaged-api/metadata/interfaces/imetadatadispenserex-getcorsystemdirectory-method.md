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
  - "GetCORSystemDirectory method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenserEx::GetCORSystemDirectory Method

Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by .NET Framework out-of-process debuggers. If called from another component, it will return `E_NOTIMPL`.

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

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
