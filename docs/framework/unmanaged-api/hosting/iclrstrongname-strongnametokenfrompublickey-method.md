---
title: "ICLRStrongName::StrongNameTokenFromPublicKey Method"
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
  - "ICLRStrongName.StrongNameTokenFromPublicKey"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameTokenFromPublicKey"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameTokenFromPublicKey method [.NET Framework hosting]"
  - "StrongNameTokenFromPublicKey method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 7962ce88-7e86-4a6f-8298-621b01ffc3c2
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameTokenFromPublicKey Method
Gets a token that represents a public key. A strong name token is the shortened form of a public key.  
  
## Syntax  
  
```  
HRESULT StrongNameTokenFromPublicKey (   
    [in]  BYTE    *pbPublicKeyBlob,  
    [in]  ULONG   cbPublicKeyBlob,  
    [out] BYTE    **ppbStrongNameToken,  
    [out] ULONG   *pcbStrongNameToken  
);  
```  
  
#### Parameters  
 `pbPublicKeyBlob`  
 [in] A structure of type [PublicKeyBlob](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md) that contains the public portion of the key pair used to generate the strong name signature.  
  
 `cbPublicKeyBlob`  
 [in] The size, in bytes, of `pbPublicKeyBlob`.  
  
 `ppbStrongNameToken`  
 [out] The strong name token corresponding to the key passed in `pbPublicKeyBlob`. The common language runtime allocates the memory in which to return the token. The caller must free this memory by using the [ICLRStrongName::StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamefreebuffer-method.md) method.  
  
 `pcbStrongNameToken`  
 [out] The size, in bytes, of the returned strong name token.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Remarks  
 A strong name token is the shortened form of a public key that is used to save space when storing key information in metadata. Specifically, strong name tokens are used in assembly references to refer to the dependent assembly.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in mscoree.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [StrongNameGetPublicKey Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetpublickey-method.md)  
 [PublicKeyBlob Structure](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
