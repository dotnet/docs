---
title: "CorMethodAttr Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CorMethodAttr"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorMethodAttr"
helpviewer_keywords: 
  - "CorMethodAttr enumeration [.NET Framework metadata]"
ms.assetid: 4e0c3521-e54d-43c1-9857-cc76b49b8ffc
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorMethodAttr Enumeration
Contains values that describe the features of a method.  
  
## Syntax  
  
```  
typedef enum CorMethodAttr {  
  
    mdMemberAccessMask          =   0x0007,  
    mdPrivateScope              =   0x0000,  
    mdPrivate                   =   0x0001,  
    mdFamANDAssem               =   0x0002,  
    mdAssem                     =   0x0003,  
    mdFamily                    =   0x0004,  
    mdFamORAssem                =   0x0005,  
    mdPublic                    =   0x0006,  
  
    mdStatic                    =   0x0010,  
    mdFinal                     =   0x0020,  
    mdVirtual                   =   0x0040,  
    mdHideBySig                 =   0x0080,  
  
    mdVtableLayoutMask          =   0x0100,  
    mdReuseSlot                 =   0x0000,  
    mdNewSlot                   =   0x0100,  
  
    mdCheckAccessOnOverride     =   0x0200,  
    mdAbstract                  =   0x0400,  
    mdSpecialName               =   0x0800,  
  
    mdPinvokeImpl               =   0x2000,  
    mdUnmanagedExport           =   0x0008,  
  
    mdReservedMask              =   0xd000,  
    mdRTSpecialName             =   0x1000,  
    mdHasSecurity               =   0x4000,  
    mdRequireSecObject          =   0x8000,  
  
} CorMethodAttr;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`mdMemberAccessMask`|Specifies member access.|  
|`mdPrivateScope`|Specifies that the member cannot be referenced.|  
|`mdPrivate`|Specifies that the member is accessible only by the parent type.|  
|`mdFamANDAssem`|Specifies that the member is accessible by subtypes only in this assembly.|  
|`mdAssem`|Specifies that the member is accessibly by anyone in the assembly.|  
|`mdFamily`|Specifies that the member is accessible only by type and subtypes.|  
|`mdFamORAssem`|Specifies that the member is accessible by derived classes and by other types in its assembly.|  
|`mdPublic`|Specifies that the member is accessible by all types with access to the scope.|  
|`mdStatic`|Specifies that the member is defined as part of the type rather than as a member of an instance.|  
|`mdFinal`|Specifies that the method cannot be overridden.|  
|`mdVirtual`|Specifies that the method can be overridden.|  
|`mdHideBySig`|Specifies that the method hides by name and signature, rather than just by name.|  
|`mdVtableLayoutMask`|Specifies virtual table layout.|  
|`mdReuseSlot`|Specifies that the slot used for this method in the virtual table be reused. This is the default.|  
|`mdNewSlot`|Specifies that the method always gets a new slot in the virtual table.|  
|`mdCheckAccessOnOverride`|Specifies that the method can be overridden by the same types to which it is visible.|  
|`mdAbstract`|Specifies that the method is not implemented.|  
|`mdSpecialName`|Specifies that the method is special, and that its name describes how.|  
|`mdPinvokeImpl`|Specifies that the method implementation is forwarded using PInvoke.|  
|`mdUnmanagedExport`|Specifies that the method is a managed method exported to unmanaged code.|  
|`mdReservedMask`|Reserved for internal use by the common language runtime.|  
|`mdRTSpecialName`|Specifies that the common language runtime should check the encoding of the method name.|  
|`mdHasSecurity`|Specifies that the method has security associated with it.|  
|`mdRequireSecObject`|Specifies that the method calls another method containing security code.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
