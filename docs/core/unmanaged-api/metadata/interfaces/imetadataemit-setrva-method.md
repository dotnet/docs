---
description: "Learn more about: IMetaDataEmit::SetRVA Method"
title: "IMetaDataEmit::SetRVA Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetRVA"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetRVA"
  - "SetRVA method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetRVA Method

Sets the relative virtual address of the specified method.

## Syntax

```cpp
HRESULT SetRVA (
    [in]  mdMethodDef  md,
    [in]  ULONG        ulRVA
);
```

## Parameters

 `md`
 [in] The token for the target method or method implementation.

 `ulRVA`
 [in] The address of the code or data area.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
