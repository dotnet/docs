---
description: "Learn more about: IMetaDataEmit::SetFieldRVA Method"
title: "IMetaDataEmit::SetFieldRVA Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetFieldRVA"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetFieldRVA"
  - "SetFieldRVA method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetFieldRVA Method

Sets a global variable value for the relative virtual address of the field referenced by the specified token.

## Syntax

```cpp
HRESULT SetFieldRVA (
    [in]  mdFieldDef  fd,
    [in]  ULONG       ulRVA
);
```

## Parameters

 `fd`
 [in] The token for the target field.

 `ulRVA`
 [in] The address of a code or data area.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
