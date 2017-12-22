---
title: "CorCheckDuplicatesFor Enumeration"
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
  - "CorCheckDuplicatesFor"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorCheckDuplicatesFor"
helpviewer_keywords: 
  - "CorCheckDuplicatesFor enumeration [.NET Framework metadata]"
ms.assetid: d8ec8d3c-70f7-4cc6-9957-68068fd8f49c
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorCheckDuplicatesFor Enumeration
Specifies the metadata tokens that will be checked for duplicates.  
  
## Syntax  
  
```  
typedef enum CorCheckDuplicatesFor {  
  
    MDDupAll                    = 0xffffffff,  
    MDDupENC                    = MDDupAll,  
    MDNoDupChecks               = 0x00000000,  
    MDDupTypeDef                = 0x00000001,  
    MDDupInterfaceImpl          = 0x00000002,  
    MDDupMethodDef              = 0x00000004,  
    MDDupTypeRef                = 0x00000008,  
    MDDupMemberRef              = 0x00000010,  
    MDDupCustomAttribute        = 0x00000020,  
    MDDupParamDef               = 0x00000040,  
    MDDupPermission             = 0x00000080,  
    MDDupProperty               = 0x00000100,  
    MDDupEvent                  = 0x00000200,  
    MDDupFieldDef               = 0x00000400,  
    MDDupSignature              = 0x00000800,  
    MDDupModuleRef              = 0x00001000,  
    MDDupTypeSpec               = 0x00002000,  
    MDDupImplMap                = 0x00004000,  
    MDDupAssemblyRef            = 0x00008000,  
    MDDupFile                   = 0x00010000,  
    MDDupExportedType           = 0x00020000,  
    MDDupManifestResource       = 0x00040000,  
    MDDupGenericParam           = 0x00080000,  
    MDDupMethodSpec             = 0x00100000,  
    MDDupGenericParamConstraint = 0x00200000,  
  
    MDDupAssembly               = 0x10000000,  
  
    MDDupDefault =   
        MDNoDupChecks | MDDupTypeRef | MDDupMemberRef |   
        MDDupSignature | MDDupTypeSpec | MDDupMethodSpec  
  
} CorCheckDuplicatesFor;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDDupAll`|Check all metadata tokens for duplicates.|  
|`MDDupENC`|Not used.|  
|`MDNoDupChecks`|Do not check metadata tokens for duplicates.|  
|`MDDupTypeDef`|Check for duplicates of `mdTypeDef` tokens.|  
|`MDDupInterfaceImpl`|Check for duplicates of `mdInterfaceImpl` tokens.|  
|`MDDupMethodDef`|Check for duplicates of `mdMethodDef` tokens.|  
|`MDDupTypeRef`|Check for duplicates of `mdTypeRef` tokens.|  
|`MDDupMemberRef`|Check for duplicates of `mdMemberRef` tokens.|  
|`MDDupCustomAttribute`|Check for duplicates of `mdCustomAttribute` tokens.|  
|`MDDupParamDef`|Check for duplicates of `mdParamDef` tokens.|  
|`MDDupPermission`|Check for duplicates of `mdPermission` tokens.|  
|`MDDupProperty`|Check for duplicates of `mdProperty` tokens.|  
|`MDDupEvent`|Check for duplicates of `mdEvent` tokens.|  
|`MDDupFieldDef`|Check for duplicates of `mdFieldDef` tokens.|  
|`MDDupSignature`|Check for duplicates of `mdSignature` tokens.|  
|`MDDupModuleRef`|Check for duplicates of `mdModuleRef` tokens.|  
|`MDDupTypeSpec`|Check for duplicates of `mdTypeSpec` tokens.|  
|`MDDupImplMap`|Check for duplicates of `mdImplMap` tokens.|  
|`MDDupAssemblyRef`|Check for duplicates of `mdAssemblyRef` tokens.|  
|`MDDupFile`|Check for duplicates of `mdFile` tokens.|  
|`MDDupExportedType`|Check for duplicates of `mdExportedType` tokens.|  
|`MDDupManifestResource`|Check for duplicates of `mdManifestResource` tokens.|  
|`MDDupGenericParam`|Check for duplicates of `mdGenericParam` tokens.|  
|`MDDupMethodSpec`|Check for duplicates of `mdMethodSpec` tokens.|  
|`MDDupGenericParamConstraint`|Check for duplicates of `mdGenericParamConstraint` tokens.|  
|`MDDupAssembly`|Check for duplicates of `mdAssembly` tokens.|  
|`MDDupDefault`|Check for duplicates of `mdMemberRef`, `mdTypeRef`, `mdSignature`, `mdTypeSpec`, and `mdMethodSpec` tokens.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
