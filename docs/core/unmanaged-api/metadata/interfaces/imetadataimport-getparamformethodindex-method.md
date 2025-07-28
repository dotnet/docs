---
description: "Learn more about: IMetaDataImport::GetParamForMethodIndex Method"
title: "IMetaDataImport::GetParamForMethodIndex Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetParamForMethodIndex"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetParamForMethodIndex"
  - "GetParamForMethodIndex method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetParamForMethodIndex Method

Gets the token that represents a specified parameter of the method represented by the specified MethodDef token.

## Syntax

```cpp
HRESULT GetParamForMethodIndex (
   [in]  mdMethodDef      md,
   [in]  ULONG            ulParamSeq,
   [out] mdParamDef       *ppd
);
```

## Parameters

 `md`
 [in] A token that represents the method to return the parameter token for.

 `ulParamSeq`
 [in] The ordinal position in the parameter list where the requested parameter occurs. Parameters are numbered starting from one, with the method's return value in position zero.

 `ppd`
 [out] A pointer to a ParamDef token that represents the requested parameter.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
