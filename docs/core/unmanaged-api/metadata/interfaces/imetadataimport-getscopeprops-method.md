---
description: "Learn more about: IMetaDataImport::GetScopeProps Method"
title: "IMetaDataImport::GetScopeProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetScopeProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetScopeProps"
  - "GetScopeProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetScopeProps Method

Gets the name and optionally the version identifier of the assembly or module in the current metadata scope.

## Syntax

```cpp
HRESULT GetScopeProps (
   [out] LPWSTR           szName,
   [in]  ULONG            cchName,
   [out] ULONG            *pchName,
   [out, optional] GUID   *pmvid
);
```

## Parameters

 `szName`
 [out] A buffer for the assembly or module name.

 `cchName`
 [in] The size in wide characters of `szName`.

 `pchName`
 [out] The number of wide characters returned in `szName`.

 `pmvid`
 [out, optional] A pointer to a GUID that uniquely identifies the version of the assembly or module.

## Remarks

 The [IMetaDataEmit::SetModuleProps](imetadataemit-setmoduleprops-method.md) method is used to set these properties.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
