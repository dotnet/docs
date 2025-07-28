---
description: "Learn more about: IMetaDataImport::GetNestedClassProps Method"
title: "IMetaDataImport::GetNestedClassProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetNestedClassProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetNestedClassProps"
  - "IMetaDataImport::GetNestedClassProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetNestedClassProps Method

Gets the TypeDef token for the parent <xref:System.Type> of the specified nested type.

## Syntax

```cpp
HRESULT GetNestedClassProps (
   [in]   mdTypeDef      tdNestedClass,
   [out]  mdTypeDef      *ptdEnclosingClass
);
```

## Parameters

 `tdNestedClass`
 [in] A TypeDef token representing the <xref:System.Type> to return the parent class token for.

 `ptdEnclosingClass`
 [out] A pointer to the TypeDef token for the <xref:System.Type> that `tdNestedClass` is nested in.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
