---
description: "Learn more about: IMetaDataEmit::SetMethodProps Method"
title: "IMetaDataEmit::SetMethodProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetMethodProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetMethodProps"
  - "IMetaDataEmit::SetMethodProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetMethodProps Method

Sets or updates the feature, stored at the specified relative virtual address, of a method defined by a prior call to [IMetaDataEmit::DefineMethod](imetadataemit-definemethod-method.md).

## Syntax

```cpp
HRESULT SetMethodProps (
    [in]  mdMethodDef md,
    [in]  DWORD       dwMethodFlags,
    [in]  ULONG       ulCodeRVA,
    [in]  DWORD       dwImplFlags
);
```

## Parameters

 `md`
 [in] The token for the method to be changed.

 `dwMethodFlags`
 [in] The member attributes.

 `ulCodeRVA`
 [in] The address of the code.

 `dwImplFlags`
 [in] The implementation flags for the method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
