---
title: "CeeSectionRelocExtra Union"
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
  - "CeeSectionRelocExtra Union"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CeeSectionRelocExtra"
helpviewer_keywords: 
  - "CeeSectionRelocExtra union [.NET Framework metadata]"
ms.assetid: d9568cf6-7f98-4cd6-ab36-0a2bd509afcc
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CeeSectionRelocExtra Union
Represents an address offset that is used by the [ICeeGen](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md) interface to relocate a section.  
  
## Syntax  
  
```  
typedef union  {  
    USHORT highAdj;  
} CeeSectionRelocExtra;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`highAdj`|The upper address adjustment for the section.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Unions](../../../../docs/framework/unmanaged-api/metadata/metadata-unions.md)
