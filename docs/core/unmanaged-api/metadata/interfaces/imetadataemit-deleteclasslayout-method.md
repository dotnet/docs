---
description: "Learn more about: IMetaDataEmit::DeleteClassLayout Method"
title: "IMetaDataEmit::DeleteClassLayout Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DeleteClassLayout"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DeleteClassLayout"
  - "IMetaDataEmit::DeleteClassLayout method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DeleteClassLayout Method

Destroys the class layout metadata signature for the type represented by the specified token.

## Syntax

```cpp
HRESULT DeleteClassLayout (
    [in]  mdTypeDef   td
);
```

## Parameters

 `td`
 [in] An `mdTypeDef` metadata token that represents the type for which the class layout will be deleted.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
