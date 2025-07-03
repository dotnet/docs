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
helpviewer_keywords:
  - "DeleteToken method [.NET Framework metadata]"
  - "IMetaDataEmit::DeleteToken method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
