---
description: "Learn more about: IMetaDataImport2::GetMethodSpecProps Method"
title: "IMetaDataImport2::GetMethodSpecProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport2.GetMethodSpecProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport2::GetMethodSpecProps"
  - "IMetaDataImport2::GetMethodSpecProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport2::GetMethodSpecProps Method

Gets the metadata signature of the method referenced by the specified MethodSpec token.

## Syntax

```cpp
HRESULT GetMethodSpecProps (
   [in]  mdMethodSpec     mi,
   [out] mdToken          *tkParent,
   [out] PCCOR_SIGNATURE  *ppvSigBlob,
   [out] ULONG            *pcbSigBlob
);
```

## Parameters

 `mi`
 [in] A MethodSpec token that represents the instantiation of the method.

 `tkParent`
 [out] A pointer to the MethodDef or MethodRef token that represents the method definition.

 `ppvSigBlob`
 [out] A pointer to the binary metadata signature of the method.

 `pcbSigBlob`
 [out] The size, in bytes, of `ppvSigBlob`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
