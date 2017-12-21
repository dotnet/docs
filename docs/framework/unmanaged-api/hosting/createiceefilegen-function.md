---
title: "CreateICeeFileGen Function"
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
  - "CreateICeeFileGen"
api_location: 
  - "mscoree.dll"
  - "mscorpehost.dll"
  - "mscorpe.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CreateICeeFileGen"
helpviewer_keywords: 
  - "CreateICeeFileGen function [.NET Framework hosting]"
ms.assetid: e36e1fd8-8456-4359-bdc3-3ec1765f041f
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateICeeFileGen Function
Creates an [ICeeFileGen](../../../../docs/framework/unmanaged-api/hosting/iceefilegen-class.md) object.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT CreateICeeFileGen (  
    [out] ICeeFileGen  **ceeFileGen  
);  
```  
  
#### Parameters  
 `ceeFileGen`  
 [out] A pointer to the address of a new `ICeeFileGen` object.  
  
## Return Value  
 This method returns standard COM error codes.  
  
## Remarks  
 The `ICeeFileGen` object is used to create common language runtime (CLR) portable executable (PE) files.  
  
 Call the [DestroyICeeFileGen](../../../../docs/framework/unmanaged-api/hosting/destroyiceefilegen-function.md) function to destroy the `ICeeFileGen` object when finished.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ICeeFileGen.h  
  
 **Library:** MSCorPE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
