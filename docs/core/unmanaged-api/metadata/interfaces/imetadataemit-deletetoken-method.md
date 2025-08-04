---
description: "Learn more about: IMetaDataEmit::DeleteToken Method"
title: "IMetaDataEmit::DeleteToken Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DeleteToken"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DeleteToken"
  - "IMetaDataEmit::DeleteToken method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DeleteToken Method

Deletes the specified token from the current metadata scope.

## Syntax

```cpp
HRESULT DeleteToken (
    [in]  mdToken     tkObj
);
```

## Parameters

 `tkObj`
 [in] The token to be deleted.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
