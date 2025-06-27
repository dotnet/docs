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
helpviewer_keywords:
  - "IMetaDataEmit::DeleteFieldMarshal method [.NET Framework metadata]"
  - "DeleteFieldMarshal method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
