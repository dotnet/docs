---
title: "CorRefToDefCheck Enumeration"
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
  - "CorRefToDefCheck"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorRefToDefCheck"
helpviewer_keywords: 
  - "CorRefToDefCheck enumeration [.NET Framework metadata]"
ms.assetid: f9a80f1a-55af-4459-b095-8441aae16119
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorRefToDefCheck Enumeration
Specifies flags to control which referenced items are converted to their definitions in order to optimize the code.  
  
## Syntax  
  
```  
typedef enum CorRefToDefCheck {  
    MDRefToDefDefault           = 0x00000003,  
    MDRefToDefAll               = 0xffffffff,  
    MDRefToDefNone              = 0x00000000,  
    MDTypeRefToDef              = 0x00000001,  
    MDMemberRefToDef            = 0x00000002  
} CorRefToDefCheck;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDRefToDefDefault`|Specifies that type references and member references should be converted to definitions. This is the default value (`MDTypeRefToDef` &#124; `MDMemberRefToDef`).|  
|`MDRefToDefAll`|Specifies that all referenced items should be converted to definitions.|  
|`MDRefToDefNone`|Specifies that no referenced items should be converted to definitions.|  
|`MDTypeRefToDef`|Specifies that only type references should be converted to type definitions.|  
|`MDMemberRefToDef`|Specifies that only member references should be converted to definitions. That is, member references should be converted to either method definitions or field definitions.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
