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
helpviewer_keywords: 
  - "CorGenericParamAttr enumeration [.NET Framework metadata]"
ms.assetid: 36c76266-71d8-48dc-bd89-54943fa659c1
topic_type: 
  - "apiref"
---
# CorGenericParamAttr Enumeration

Contains values that describe the <xref:System.Type> parameters for generic types, as used in calls to [IMetaDataEmit2::DefineGenericParam](imetadataemit2-definegenericparam-method.md).  
  
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
    gpDefaultConstructorConstraint     =   0x0010  
  
} CorGenericParamAttr;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`gpVarianceMask`|Parameter variance applies only to generic parameters for interfaces and delegates.|  
|`gpNonVariant`|Indicates the absence of variance.|  
|`gpCovariant`|Indicates covariance.|  
|`gpContravariant`|Indicates contravariance.|  
|`gpSpecialConstraintMask`|Special constraints can apply to any <xref:System.Type> parameter.|  
|`gpNoSpecialConstraint`|Indicates that no constraint applies to the <xref:System.Type> parameter.|  
|`gpReferenceTypeConstraint`|Indicates that the <xref:System.Type> parameter must be a reference type.|  
|`gpNotNullableValueTypeConstraint`|Indicates that the <xref:System.Type> parameter must be a value type that cannot be a null value.|  
|`gpDefaultConstructorConstraint`|Indicates that the <xref:System.Type> parameter must have a default public constructor that takes no parameters.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
