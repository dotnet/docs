---
description: "Learn more about: IMetaDataEmit::DefineMemberRef Method"
title: "IMetaDataEmit::DefineMemberRef Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineMemberRef"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineMemberRef"
  - "IMetaDataEmit::DefineMemberRef method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineMemberRef Method

Defines a reference to a member of a module outside the current scope, and gets a token to that reference definition.

## Syntax

```cpp
HRESULT DefineMemberRef (
    [in]  mdToken           tkImport,
    [in]  LPCWSTR           szName,
    [in]  PCCOR_SIGNATURE   pvSigBlob,
    [in]  ULONG             cbSigBlob,
    [out] mdMemberRef       *pmr
);
```

## Parameters

 `tkImport`
 [in] Token for the target member's class or interface, if the member is not global; if the member is global, the `mdModuleRef` token for that other file.

 `szName`
 [in] The name of the target member.

 `pvSigBlob`
 [in] The signature of the target member.

 `cbSigBlob`
 [in] The count of bytes in `pvSigBlob`.

 `pmr`
 [out] The `mdMemberRef` token assigned.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
