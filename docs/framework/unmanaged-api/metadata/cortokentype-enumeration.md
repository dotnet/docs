---
title: "CorTokenType Enumeration"
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
  - "CorTokenType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorTokenType"
helpviewer_keywords: 
  - "CorTokenType enumeration [.NET Framework metadata]"
ms.assetid: 93c9a369-225f-4eff-9b78-3fbee4902cf1
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorTokenType Enumeration
Indicates the type of a metadata token.  
  
## Syntax  
  
```  
typedef enum CorTokenType {  
  
    mdtModule                       = 0x00000000,  
    mdtTypeRef                      = 0x01000000,  
    mdtTypeDef                      = 0x02000000,  
    mdtFieldDef                     = 0x04000000,  
    mdtMethodDef                    = 0x06000000,  
    mdtParamDef                     = 0x08000000,  
    mdtInterfaceImpl                = 0x09000000,  
    mdtMemberRef                    = 0x0a000000,  
    mdtCustomAttribute              = 0x0c000000,  
    mdtPermission                   = 0x0e000000,  
    mdtSignature                    = 0x11000000,  
    mdtEvent                        = 0x14000000,  
    mdtProperty                     = 0x17000000,  
    mdtModuleRef                    = 0x1a000000,  
    mdtTypeSpec                     = 0x1b000000,  
    mdtAssembly                     = 0x20000000,  
    mdtAssemblyRef                  = 0x23000000,  
    mdtFile                         = 0x26000000,  
    mdtExportedType                 = 0x27000000,  
    mdtManifestResource             = 0x28000000,  
    mdtGenericParam                 = 0x2a000000,  
    mdtMethodSpec                   = 0x2b000000,  
    mdtGenericParamConstraint       = 0x2c000000,  
    mdtString                       = 0x70000000,  
    mdtName                         = 0x71000000,  
    mdtBaseType                     = 0x72000000  
  
} CorTokenType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`mdtModule`|An `mdModule` token.|  
|`mdtTypeRef`|An `mdTypeRef` token.|  
|`mdtTypeDef`|An `mdTypeDef` token.|  
|`mdtFieldDef`|An `mdFieldDef` token.|  
|`mdtMethodDef`|An `mdMethodDef` token.|  
|`mdtParamDef`|An `mdParamDef` token.|  
|`mdtInterfaceImpl`|An `mdInterfaceImpl` token.|  
|`mdtMemberRef`|An `mdMemberRef` token.|  
|`mdtCustomAttribute`|An `mdCustomAttribute` token.|  
|`mdtPermission`|An `mdPermission` token.|  
|`mdtSignature`|An `mdSignature` token.|  
|`mdtEvent`|An `mdEvent` token.|  
|`mdtProperty`|An `mdProperty` token.|  
|`mdtModuleRef`|An `mdModuleRef` token.|  
|`mdtTypeSpec`|An `mdTypeSpec` token.|  
|`mdtAssembly`|An `mdAssembly` token.|  
|`mdtAssemblyRef`|An `mdAssemblyRef` token.|  
|`mdtFile`|An `mdFile` token.|  
|`mdtExportedType`|An `mdExportedType` token.|  
|`mdtManifestResource`|An `mdManifestResource` token.|  
|`mdtGenericParam`|An `mdGenericParam` token.|  
|`mdtMethodSpec`|An `mdMethodSpec` token.|  
|`mdtGenericParamConstraint`|An `mdGenericParamConstraint` token.|  
|`mdtString`|An `mdString` token.|  
|`mdtName`|An `mdName` token.|  
|`mdtBaseType`|Not used.|  
  
## Remarks  
 Each value is equal to the value of the top byte in the corresponding metadata token.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
