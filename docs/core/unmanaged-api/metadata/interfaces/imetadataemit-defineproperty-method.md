---
description: "Learn more about: IMetaDataEmit::DefineProperty Method"
title: "IMetaDataEmit::DefineProperty Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineProperty"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineProperty"
  - "DefineProperty method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineProperty Method

Creates a property definition for the specified type, with the specified `get` and `set` method accessors, and gets a token to that property definition.

## Syntax

```cpp
HRESULT DefineProperty (
    [in]  mdTypeDef          td,
    [in]  LPCWSTR            szProperty,
    [in]  DWORD              dwPropFlags,
    [in]  PCCOR_SIGNATURE    pvSig,
    [in]  ULONG              cbSig,
    [in]  DWORD              dwCPlusTypeFlag,
    [in]  void const         *pValue,
    [in]  ULONG              cchValue,
    [in]  mdMethodDef        mdSetter,
    [in]  mdMethodDef        mdGetter,
    [in]  mdMethodDef        rmdOtherMethods[],
    [out] mdProperty         *pmdProp
);
```

## Parameters

 `td`
 [in] The token for class or interface on which the property is being defined.

 `szProperty`
 [in] The name of the property.

 `dwPropFlags`
 [in] The property flags.

 `pvSig`
 [in] The property signature.

 `cbSig`
 [in] The count of bytes in `pvSig`.

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
 [in] An array of other methods associated with the property. Terminate the array with an `mdTokenNil`.

 `pmdProp`
 [out] The `mdProperty` token assigned.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
