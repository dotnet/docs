---
description: "Learn more about: IMetaDataImport::EnumModuleRefs Method"
title: "IMetaDataImport::EnumModuleRefs Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumModuleRefs"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumModuleRefs"
  - "IMetaDataImport::EnumModuleRefs method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumModuleRefs Method

Enumerates ModuleRef tokens that represent imported modules.

## Syntax

```cpp
HRESULT EnumModuleRefs (
   [in, out] HCORENUM     *phEnum,
   [out]     mdModuleRef  rModuleRefs[],
   [in]      ULONG        cMax,
   [out]     ULONG        *pcModuleRefs
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.

 `rModuleRefs`
 [out] The array used to store the ModuleRef tokens.

 `cMax`
 [in] The maximum size of the `rModuleRefs` array.

 `pcModuleRefs`
 [out] The number of ModuleRef tokens returned in `rModuleRefs`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumModuleRefs` returned successfully.|
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcModuleRefs` is zero.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
