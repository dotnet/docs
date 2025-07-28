---
description: "Learn more about: CorGenericParamAttr Enumeration"
title: "CorGenericParamAttr Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorGenericParamAttr"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorGenericParamAttr"
topic_type:
  - "apiref"
---
# CorGenericParamAttr Enumeration

Contains values that describe the <xref:System.Type> parameters for generic types, as used in calls to [IMetaDataEmit2::DefineGenericParam](../interfaces/imetadataemit2-definegenericparam-method.md).

## Syntax

```cpp
typedef enum CorGenericParamAttr {

    gpVarianceMask                     =   0x0003,
    gpNonVariant                       =   0x0000,
    gpCovariant                        =   0x0001,
    gpContravariant                    =   0x0002,

    gpSpecialConstraintMask            =   0x001C,
    gpNoSpecialConstraint              =   0x0000,
    gpReferenceTypeConstraint          =   0x0004,
    gpNotNullableValueTypeConstraint   =   0x0008,
    gpDefaultConstructorConstraint     =   0x0010,
    gpAllowByRefLike                   =   0x0020,

} CorGenericParamAttr;
```

## Members

| Member                      | Description                                                                         |
|-----------------------------|-------------------------------------------------------------------------------------|
| `gpVarianceMask`            | Parameter variance applies only to generic parameters for interfaces and delegates. |
| `gpNonVariant`              | Indicates the absence of variance.                                                  |
| `gpCovariant`               | Indicates covariance.                                                               |
| `gpContravariant`           | Indicates contravariance.                                                           |
| `gpSpecialConstraintMask`   | Special constraints can apply to any <xref:System.Type> parameter.                  |
| `gpNoSpecialConstraint`     | Indicates that no constraint applies to the <xref:System.Type> parameter.           |
| `gpReferenceTypeConstraint` | Indicates that the <xref:System.Type> parameter must be a reference type.           |
|`gpNotNullableValueTypeConstraint`|Indicates that the <xref:System.Type> parameter must be a value type that cannot be a null value.|
|`gpDefaultConstructorConstraint`|Indicates that the <xref:System.Type> parameter must have a default public constructor that takes no parameters.|
|`gpAllowByRefLike`|Indicates that the <xref:System.Type> parameter can be a [byref-like type](xref:System.Type.IsByRefLike). (available since .NET 7) |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 2.0
