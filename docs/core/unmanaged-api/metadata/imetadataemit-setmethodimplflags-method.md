---
description: "Learn more about: IMetaDataEmit::SetMethodImplFlags Method"
title: "IMetaDataEmit::SetMethodImplFlags Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetMethodImplFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetMethodImplFlags"
  - "SetMethodImpFlags method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetMethodImplFlags Method

Sets or updates the metadata signature of the inherited method implementation that is referenced by the specified token.

## Syntax

```cpp
HRESULT SetMethodImplFlags (
    [in]  mdMethodDef   md,
    [in]  DWORD         dwImplFlags
);
```

## Parameters

 `md`
 [in] The token for the method to be changed.

 `dwImplFlags`
 [in] A combination of the values of the [CorMethodImpl](./cormethodimpl-enumeration.md) enumeration that specifies the method implementation features.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
