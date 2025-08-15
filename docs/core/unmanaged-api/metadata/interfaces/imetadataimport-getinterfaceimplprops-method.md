---
description: "Learn more about: IMetaDataImport::GetInterfaceImplProps Method"
title: "IMetaDataImport::GetInterfaceImplProps Method"
ms.date: "02/25/2019"
api_name:
  - "IMetaDataImport.GetInterfaceImplProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetInterfaceImplProps"
  - "GetInterfaceImpProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetInterfaceImplProps Method

Gets a pointer to the metadata tokens for the <xref:System.Type> that implements the specified method, and for the interface that declares that method.

## Syntax

```cpp
HRESULT GetInterfaceImplProps (
   [in]  mdInterfaceImpl        iiImpl,
   [out] mdTypeDef              *pClass,
   [out] mdToken                *ptkIface
);
```

## Parameters

 `iiImpl`
 [in] The metadata token representing the method to return the class and interface tokens for.

 `pClass`
 [out] The metadata token representing the class that implements the method.

 `ptkIface`
 [out] The metadata token representing the interface that defines the implemented method.

## Remarks

 You obtain the value for `iImpl` by calling the [EnumInterfaceImpls](imetadataimport-enuminterfaceimpls-method.md) method.

 For example, suppose that a class has an `mdTypeDef` token value of 0x02000007 and that it implements three
interfaces whose types have tokens:

- 0x02000003 (TypeDef)
- 0x0100000A (TypeRef)
- 0x0200001C (TypeDef)

Conceptually, this information is stored into an interface implementation table as:

| Row number | Class token | Interface token |
|------------|-------------|-----------------|
| 4          |             |                 |
| 5          | 02000007    | 02000003        |
| 6          | 02000007    | 0100000A        |
| 7          |             |                 |
| 8          | 02000007    | 0200001C        |

Recall, the token is a 4-byte value:

- The lower 3 bytes hold the row number, or RID.
- The upper byte holds the token type – 0x09 for `mdtInterfaceImpl`.

`GetInterfaceImplProps` returns the information held in the row whose token you provide in the `iImpl` argument.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
