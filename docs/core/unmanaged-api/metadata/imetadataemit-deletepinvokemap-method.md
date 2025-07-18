---
description: "Learn more about: IMetaDataEmit::DeletePinvokeMap Method"
title: "IMetaDataEmit::DeletePinvokeMap Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DeletePinvokeMap"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DeletePinvokeMap"
helpviewer_keywords:
  - "IMetaDataEmit::DeletePinvokeMap method [.NET Framework metadata]"
  - "DeletePinvokeMap method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DeletePinvokeMap Method

Destroys the PInvoke mapping metadata for the object referenced by the specified token.

## Syntax

```cpp
HRESULT DeletePinvokeMap (
    [in]  mdToken     tk
);
```

## Parameters

 `tk`
 [in] An `mdFieldDef` or `mdMethodDef` token that represents the object for which to delete the PInvoke mapping metadata.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
