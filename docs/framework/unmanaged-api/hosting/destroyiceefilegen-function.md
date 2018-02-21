---
title: "DestroyICeeFileGen Function"
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
  - "DestroyICeeFileGen"
api_location: 
  - "mscoree.dll"
  - "mscorpehost.dll"
  - "mscorpe.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "DestroyICeeFileGen"
helpviewer_keywords: 
  - "DestroyICeeFileGen function [.NET Framework hosting]"
ms.assetid: dc1e2235-e721-4cb2-a0b8-6b0c030d7bab
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# DestroyICeeFileGen Function
Destroys an [ICeeFileGen](../../../../docs/framework/unmanaged-api/hosting/iceefilegen-class.md) object.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT DestroyICeeFileGen (  
    [in] ICeeFileGen  **ceeFileGen  
);  
```  
  
#### Parameters  
 `ceeFileGen`  
 [in] The `ICeeFileGen` object to destroy.  
  
## Return Value  
 This method returns standard COM error codes.  
  
## Remarks  
 `DestroyICeeFileGen` destroys the `ICeeFileGen` object created by the [CreateICeeFileGen](../../../../docs/framework/unmanaged-api/hosting/createiceefilegen-function.md) function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ICeeFileGen.h  
  
 **Library:** MSCorPE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
