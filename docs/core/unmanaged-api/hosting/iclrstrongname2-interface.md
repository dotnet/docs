---
description: "Learn more about: ICLRStrongName2 Interface"
title: "ICLRStrongName2 Interface"
ms.date: "03/30/2017"
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
---
# ICLRStrongName2 Interface

Provides the ability to create strong names using the SHA-2 group of Secure Hash Algorithms (SHA-256, SHA-384, and SHA-512).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[StrongNameGetPublicKeyEx Method](strongnamegetpublickeyex-method.md)|Gets the public key from a public/private key pair, and specifies a hash algorithm and a signature algorithm.|  
|[StrongNameSignatureVerificationEx2 Method](strongnamesignatureverificationex2-method.md)|Verifies the signature of a strongly named assembly, and provides a mapping from the ECMA key to a real key.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]
