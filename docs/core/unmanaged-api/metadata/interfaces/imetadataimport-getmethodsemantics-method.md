---
description: "Learn more about: IMetaDataImport::GetMethodSemantics Method"
title: "IMetaDataImport::GetMethodSemantics Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetMethodSemantics"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetMethodSemantics"
  - "IMetaDataImport::GetMethodSemantics method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetMethodSemantics Method

Gets flags indicating the relationship between the method referenced by the specified MethodDef token and the paired property and event referenced by the specified EventProp token.

## Syntax

```cpp
HRESULT GetMethodSemantics (
   [in]  mdMethodDef   mb,
   [in]  mdToken       tkEventProp,
   [out] DWORD         *pdwSemanticsFlags
);
```

## Parameters

 `mb`
 [in] A MethodDef token representing the method to get the semantic role information for.

 `tkEventProp`
 [in] A token representing the paired property and event for which to get the method's role.

 `pdwSemanticsFlags`
 [out] A pointer to the associated semantics flags. This value is a bitmask from the [CorMethodSemanticsAttr](../enumerations/cormethodsemanticsattr-enumeration.md) enumeration.

## Remarks

 The [IMetaDataEmit::DefineProperty](imetadataemit-defineproperty-method.md) method sets a method's semantics flags.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
