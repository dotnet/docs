---
description: "Learn more about: IMetaDataImport2::GetVersionString Method"
title: "IMetaDataImport2::GetVersionString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.GetVersionString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::GetVersionString"
helpviewer_keywords:
  - "GetVersionString method, IMetaDataImport2 interface [.NET Framework metadata]"
  - "IMetaDataImport2::GetVersionString method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::GetVersionString Method

Gets the version number of the runtime that was used to build the assembly.

## Syntax

```cpp
HRESULT GetVersionString (
   [out] LPWSTR      pwzBuf,
   [in]  DWORD       ccBufSize,
   [out] DWORD       *pccBufSize
);
```

## Parameters

 `pwzBuf`
 [out] An array to store the string that specifies the version.

 `ccBufSize`
 [in] The size, in wide characters, of the `pwzBuf` array.

 `pccBufSize`
 [out] The number of wide characters, including a null terminator, returned in the `pwzBuf` array.

## Remarks

 The `GetVersionString` method gets the built-for version of the current metadata scope. If the scope has never been saved, it will not have a built-for version, and an empty string will be returned.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
