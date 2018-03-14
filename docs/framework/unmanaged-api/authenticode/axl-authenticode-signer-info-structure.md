---
title: "AXL_AUTHENTICODE_SIGNER_INFO Structure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 81c0f8b4-ce35-4716-8651-b642d40648a2
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AXL_AUTHENTICODE_SIGNER_INFO Structure
Defines the Authenticode signer information.  
  
## Syntax  
  
```  
typedef struct _AXL_AUTHENTICODE_SIGNER_INFO {  
    DWORD cbSize;  
    HRESULT dwError;  
    ALG_ID algHash;  
    LPCWSTR pwszHash  
    LPCWSTR pwszDescription;  
    LPCWSTR pwszDescriptionUrl;  
    PCCERT_CHAIN_CONTEXT pChainContext  
} AXL_AUTHENTICODE_SIGNER_INFO, * PAXL_AUTHENTICODE_SIGNER_INFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`cbSize`|The size of this structure.|  
|`dwError`|The error code.|  
|`algHash`|The hash algorithm.|  
|`pwszHash`|The hash.|  
|`pwszDescription`|The description.|  
|`pwszDescriptionUrl`|The URL of the description.|  
|`pChainContext`|The chain context of the signer. See the [CERT_CONTEXT](http://msdn.microsoft.com/library/windows/desktop/aa377189.aspx) structure.|  
  
## See Also  
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
