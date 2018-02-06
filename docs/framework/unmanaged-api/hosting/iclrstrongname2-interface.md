---
title: "ICLRStrongName2 Interface"
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
  - "ICLRStrongName2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName2"
helpviewer_keywords: 
  - "ICLRStrongName2 interface [.NET Framework hosting]"
ms.assetid: 9f098a74-201e-4628-a468-8dee9ab99b4a
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName2 Interface
Provides the ability to create strong names using the SHA-2 group of Secure Hash Algorithms (SHA-256, SHA-384, and SHA-512).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[StrongNameGetPublicKeyEx Method](../../../../docs/framework/unmanaged-api/hosting/strongnamegetpublickeyex-method.md)|Gets the public key from a public/private key pair, and specifies a hash algorithm and a signature algorithm.|  
|[StrongNameSignatureVerificationEx2 Method](../../../../docs/framework/unmanaged-api/hosting/strongnamesignatureverificationex2-method.md)|Verifies the signature of a strongly named assembly, and provides a mapping from the ECMA key to a real key.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]
