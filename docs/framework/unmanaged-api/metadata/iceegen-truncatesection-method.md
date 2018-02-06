---
title: "ICeeGen::TruncateSection Method"
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
  - "ICeeGen.TruncateSection"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::TruncateSection"
helpviewer_keywords: 
  - "TruncateSection method [.NET Framework metadata]"
  - "ICeeGen::TruncateSection method [.NET Framework metadata]"
ms.assetid: 0451d752-1e5c-4c9a-8bad-6cd35b7ba3df
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICeeGen::TruncateSection Method
Truncates the specified code section by the specified length.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```  
HRESULT TruncateSection (  
    [in]  HCEESECTION     section,  
    [in]  ULONG           len  
);  
```  
  
#### Parameters  
 `section`  
 [in] The section to truncate.  
  
 `len`  
 [in] The length, in bytes, by which to truncate the section.  
  
## Remarks  
 Call `TruncateSection` only if you have special section requirements that are not handled by other methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)
