---
description: "Learn more about: IMetaDataEmit::Merge Method"
title: "IMetaDataEmit::Merge Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.Merge"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::Merge"
  - "Merge method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::Merge Method

Adds the specified imported scope to the list of scopes to be merged.

## Syntax

```cpp
HRESULT Merge (
    [in]  IMetaDataImport  *pImport,
    [in]  IMapToken        *pHostMapToken,
    [in]  IUnknown         *pHandler
);
```

## Parameters

 `pImport`
 [in] A pointer to an [IMetaDataImport](imetadataimport-interface.md) object that identifies the imported scope to be merged.

 `pIMap`
 [in] A pointer to an [IMapToken](./imaptoken-interface.md) object that specifies the token re-map.

 `pHandler`
 [in] A pointer to an [IUnknown](/cpp/atl/iunknown) object that specifies the errors.

## Remarks

 Call [IMetaDataEmit::MergeEnd](imetadataemit-mergeend-method.md) to trigger the merger of metadata into a single scope.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
