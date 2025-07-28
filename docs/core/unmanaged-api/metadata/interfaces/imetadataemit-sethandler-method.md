---
description: "Learn more about: IMetaDataEmit::SetHandler Method"
title: "IMetaDataEmit::SetHandler Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetHandler"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetHandler"
  - "SetHandler method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetHandler Method

Sets the method referenced by the specified `IUnknown` pointer as a notification callback for token remaps.

## Syntax

```cpp
HRESULT SetHandler (
    [in]  IUnknown    *pUnk
);
```

## Parameters

 `pUnk`
 [in] The handler to register.

## Remarks

 The metadata engine sends notification by using the method that is provided by `SetHandler`, to compilers that do not generate records in an optimized way and that would like to optimize saved records.

 If the callback method is not provided through `SetHandler`, no optimization will be performed on save except where several import scopes have been merged using `IMapToken` on merge for each scope.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
