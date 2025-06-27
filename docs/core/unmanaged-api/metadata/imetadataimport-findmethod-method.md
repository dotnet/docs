---
description: "Learn more about: IMetaDataImport::FindMethod Method"
title: "IMetaDataImport::FindMethod Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.FindMethod"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::FindMethod"
helpviewer_keywords:
  - "FindMethod method [.NET Framework metadata]"
  - "IMetaDataImport::FindMethod method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::FindMethod Method

Gets a pointer to the MethodDef token for the method that is enclosed by the specified <xref:System.Type> and that has the specified name and metadata signature.

## Syntax

```cpp
HRESULT FindMethod (
   [in]  mdTypeDef          td,
   [in]  LPCWSTR            szName,
   [in]  PCCOR_SIGNATURE    pvSigBlob,
   [in]  ULONG              cbSigBlob,
   [out] mdMethodDef        *pmb
);
```

## Parameters

 `td`
 [in] The `mdTypeDef` token for the type (a class or interface) that encloses the member to search for. If this value is `mdTokenNil`, then the lookup is done for a global function.

 `szName`
 [in] The name of the method to search for.

 `pvSigBlob`
 [in] A pointer to the binary metadata signature of the method.

 `cbSigBlob`
 [in] The size in bytes of `pvSigBlob`.

 `pmb`
 [out] A pointer to the matching MethodDef token.

## Remarks

 You specify the method using its enclosing class or interface (`td`), its name (`szName`), and optionally its signature (`pvSigBlob`). There might be multiple methods with the same name in a class or interface. In that case, pass the method's signature to find the unique match.

 The signature passed to `FindMethod` must have been generated in the current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of the current scope and use that signature as input to input to `FindMethod`.

 `FindMethod` finds only methods that were defined directly in the class or interface; it does not find inherited methods.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- <xref:System.Reflection.MethodInfo>
- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
