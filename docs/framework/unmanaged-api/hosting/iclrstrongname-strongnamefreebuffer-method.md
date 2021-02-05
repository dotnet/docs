---
description: "Learn more about: ICLRStrongName::StrongNameFreeBuffer Method"
title: "ICLRStrongName::StrongNameFreeBuffer Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameFreeBuffer"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameFreeBuffer"
helpviewer_keywords: 
  - "StrongNameFreeBuffer method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameFreeBuffer method [.NET Framework hosting]"
ms.assetid: 6148c508-bd1d-4a37-85c3-06ecb09cc857
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameFreeBuffer Method

Frees memory that was allocated with a previous call to a strong name method such as [ICLRStrongName::StrongNameGetPublicKey](iclrstrongname-strongnamegetpublickey-method.md), [ICLRStrongName::StrongNameTokenFromPublicKey](iclrstrongname-strongnametokenfrompublickey-method.md), or [ICLRStrongName::StrongNameSignatureGeneration](iclrstrongname-strongnamesignaturegeneration-method.md).  
  
## Syntax  
  
```cpp  
HRESULT StrongNameFreeBuffer (
   [in] BYTE   *pbMemory  
);  
```  
  
## Parameters  

 `pbMemory`  
 [in] A pointer to the memory to free.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRStrongName Interface](iclrstrongname-interface.md)
