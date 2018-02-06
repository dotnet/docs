---
title: "ICLRStrongName::StrongNameGetPublicKey Method"
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
  - "ICLRStrongName.StrongNameGetPublicKey"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameGetPublicKey"
helpviewer_keywords: 
  - "StrongNameGetPublicKey method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameGetPublicKey method [.NET Framework hosting]"
ms.assetid: a31dcaa9-a404-4c1d-8cc7-081827c52935
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameGetPublicKey Method
Gets the public key from a public/private key pair. The key pair can be supplied either as a key container name within a cryptographic service provider (CSP) or as a raw collection of bytes.  
  
## Syntax  
  
```  
HRESULT StrongNameGetPublicKey (   
    [in]  LPCWSTR   szKeyContainer,  
    [in]  BYTE      *pbKeyBlob,  
    [in]  ULONG     cbKeyBlob,  
    [out] BYTE      **ppbPublicKeyBlob,  
    [out] ULONG     *pcbPublicKeyBlob  
);  
```  
  
#### Parameters  
 `szKeyContainer`  
 [in] The name of the key container that contains the public/private key pair. If `pbKeyBlob` is null, `szKeyContainer` must specify a valid container within the CSP. In this case, the [ICLRStrongName::StrongNameGetPublicKey](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetpublickey-method.md) method extracts the public key from the key pair stored in the container.  
  
 If `pbKeyBlob` is not null, the key pair is assumed to be contained in the key binary large object (BLOB).  
  
 The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.  
  
 `pbKeyBlob`  
 [in] A pointer to the public/private key pair. This pair is in the format created by the Win32 `CryptExportKey` function. If `pbKeyBlob` is null, the key container specified by `szKeyContainer` is assumed to contain the key pair.  
  
 `cbKeyBlob`  
 [in] The size, in bytes, of `pbKeyBlob`.  
  
 `ppbPublicKeyBlob`  
 [out] The returned public key BLOB. The `ppbPublicKeyBlob` parameter is allocated by the common language runtime and returned to the caller. The caller must free the memory by using the [ICLRStrongName::StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamefreebuffer-method.md) method.  
  
 `pcbPublicKeyBlob`  
 [out] The size of the returned public key BLOB.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Remarks  
 The public key is contained in a [PublicKeyBlob](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md) structure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [StrongNameTokenFromPublicKey Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfrompublickey-method.md)  
 [PublicKeyBlob Structure](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
