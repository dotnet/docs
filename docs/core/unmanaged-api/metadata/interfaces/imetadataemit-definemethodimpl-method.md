---
description: "Learn more about: IMetaDataEmit::DefineMethodImpl Method"
title: "IMetaDataEmit::DefineMethodImpl Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineMethodImpl"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineMethodImpl"
  - "IMetaDataEmit::DefineMethodImpl method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineMethodImpl Method

Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.

## Syntax

```cpp
HRESULT DefineMethodImpl (
    [in]  mdTypeDef         td,
    [in]  mdToken           tkBody,
    [in]  mdToken           tkDecl
);
```

## Parameters

 `td`
 [in] The `mdTypedef` token of the implementing class.

 `tkBody`
 [in] The `mdMethodDef` or `mdMemberRef` token of the code body.

 `tkDecl`
 [in] The `mdMethodDef` or `mdMemberRef` token of the interface method being implemented.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
