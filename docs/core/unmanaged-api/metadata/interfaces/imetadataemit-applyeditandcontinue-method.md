---
description: "Learn more about: IMetaDataEmit::ApplyEditAndContinue Method"
title: "IMetaDataEmit::ApplyEditAndContinue Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.ApplyEditAndContinue"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::ApplyEditAndContinue"
  - "IMetaDataEmit::ApplyEditAndContinue method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::ApplyEditAndContinue Method

Updates the current assembly scope with the changes made in the specified metadata.

## Syntax

```cpp
HRESULT ApplyEditAndContinue (
    [in]  IUnknown    *pImport
);
```

## Parameters

 `pImport`
 \[in\] Pointer to an [IUnknown](/cpp/atl/iunknown) object that represents the delta metadata from the portable executable (PE) file.

 The delta metadata is the block of metadata that includes the changes that were made to the copy of the module's actual metadata.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
