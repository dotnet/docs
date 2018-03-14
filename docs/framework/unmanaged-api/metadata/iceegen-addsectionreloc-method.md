---
title: "ICeeGen::AddSectionReloc Method"
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
  - "ICeeGen.AddSectionReloc"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::AddSectionReloc"
helpviewer_keywords: 
  - "AddSectionReloc method [.NET Framework metadata]"
  - "ICeeGen::AddSectionReloc method [.NET Framework metadata]"
ms.assetid: b500a260-1d57-4953-95e1-c27063f7c8da
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICeeGen::AddSectionReloc Method
Adds a .reloc instruction to the code base.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```  
HRESULT AddSectionReloc (  
   [in] HCEESECTION            section,  
   [in] ULONG                  offset,  
   [in] HCEESECTION            relativeTo,   
   [in] CeeSectionRelocType    relocType  
);  
```  
  
#### Parameters  
 `section`  
 [in] The section of in-memory code to which to add a .reloc instruction.  
  
 `offset`  
 [in] The offset of the section.  
  
 `relativeTo`  
 [in] The section to which `offset` refers.  
  
 `relocType`  
 [in] One of the [CeeSectionRelocType](../../../../docs/framework/unmanaged-api/metadata/ceesectionreloctype-enumeration.md) values, indicating the kind of .reloc instruction to add.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)
