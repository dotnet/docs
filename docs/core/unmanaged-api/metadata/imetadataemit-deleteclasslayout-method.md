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
helpviewer_keywords:
  - "DeleteClassLayout method [.NET Framework metadata]"
  - "IMetaDataEmit::DeleteClassLayout method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
