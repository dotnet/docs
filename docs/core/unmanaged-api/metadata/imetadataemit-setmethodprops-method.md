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
  - "IMetaDataEmit::SetMethodProps method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
