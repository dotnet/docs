---
description: "Learn more about: IMetaDataEmit::SetPropertyProps Method"
title: "IMetaDataEmit::SetPropertyProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetPropertyProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetPropertyProps"
  - "IMetaDataEmit::SetPropertyProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetPropertyProps Method

Sets the features stored in metadata for a property defined by a prior call to [DefineProperty Method](imetadataemit-defineproperty-method.md).

## Syntax

```cpp
HRESULT SetPropertyProps (
    [in]  mdProperty      pr,
    [in]  DWORD           dwPropFlags,
    [in]  DWORD           dwCPlusTypeFlag,
    [in]  void const      *pValue,
    [in]  ULONG           cchValue,
    [in]  mdMethodDef     mdSetter,
    [in]  mdMethodDef     mdGetter,
    [in]  mdMethodDef     rmdOtherMethods[]
);
```

## Parameters

 `pr`
 [in] The token for the property to be changed

 `dwPropFlags`
 [in] Property flags.

 `dwCPlusTypeFlag`
 [in] The type of the property's default value.

 `pValue`
 [in] The default value for the property.

 `cchValue`
 [in] The count of (Unicode) characters in `pValue`.

 `mdSetter`
 [in] The method that sets the property value.

 `mdGetter`
 [in] The method that gets the property value.

 `rmdOtherMethods[]`
 [in] An array of other methods associated with the property. Terminate this array with an `mdTokenNil` token.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
