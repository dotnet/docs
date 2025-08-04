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
  - "IMetaDataImport2::GetVersionString method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
