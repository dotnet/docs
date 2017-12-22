---
title: "ICeeGen::GetStringSection Method"
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
  - "ICeeGen.GetStringSection"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen::GetStringSection"
helpviewer_keywords: 
  - "ICeeGen::GetStringSection method [.NET Framework metadata]"
  - "GetStringSection method [.NET Framework metadata]"
ms.assetid: a2267d39-69d1-4de1-bf37-f752cafacc71
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICeeGen::GetStringSection Method
Gets a string representation of the code section referenced by the specified handle.  
  
 This method is obsolete and should not be used.  
  
## Syntax  
  
```  
HRESULT GetStringSection (  
    [in, out] HCEESECTION     *section  
);  
```  
  
#### Parameters  
 `section`  
 [in, out] The handle to the code section.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)
