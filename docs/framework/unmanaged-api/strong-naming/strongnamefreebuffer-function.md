---
title: "StrongNameFreeBuffer Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameFreeBuffer"
api_location: 
  - "mscoree.dll"
  - "mscorsn.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameFreeBuffer"
helpviewer_keywords: 
  - "StrongNameFreeBuffer function [.NET Framework strong naming]"
ms.assetid: eda21ecf-4734-4f92-aaba-9f34884385db
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# StrongNameFreeBuffer Function
Frees memory that was allocated with a previous call to a strong name function such as [StrongNameGetPublicKey](strongnamegetpublickey-function.md), [StrongNameTokenFromPublicKey](strongnametokenfrompublickey-function.md), or [StrongNameSignatureGeneration](strongnamesignaturegeneration-function.md).  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameFreeBuffer](../hosting/iclrstrongname-strongnamefreebuffer-method.md) method instead.  
  
## Syntax  
  
```cpp  
VOID StrongNameFreeBuffer (   
   [in] BYTE   *pbMemory  
);  
```  
  
## Parameters  
 `pbMemory`  
 [in] A pointer to the memory to free.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameFreeBuffer Method](../hosting/iclrstrongname-strongnamefreebuffer-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
