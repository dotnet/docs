---
description: "Learn more about: IMetaDataEmit::DeleteFieldMarshal Method"
title: "IMetaDataEmit::DeleteFieldMarshal Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DeleteFieldMarshal"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DeleteFieldMarshal"
  - "DeleteFieldMarshal method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DeleteFieldMarshal Method

Destroys the PInvoke marshalling metadata signature for the object referenced by the specified token.

## Syntax

```cpp
HRESULT DeleteFieldMarshal (
    [in]  mdToken     tk
);
```

## Parameters

 `tk`
 [in] An `mdFieldDef` or `mdParamDef` token that represents the field or parameter for which to delete the marshalling metadata signature.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
