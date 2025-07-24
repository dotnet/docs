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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
