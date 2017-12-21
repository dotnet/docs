---
title: "StrongNameGetPublicKey Function"
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
  - "StrongNameGetPublicKey"
api_location: 
  - "mscoree.dll"
  - "mscorsn.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameGetPublicKey"
helpviewer_keywords: 
  - "StrongNameGetPublicKey function [.NET Framework strong naming]"
ms.assetid: 5b58c87f-3f72-40df-9b9a-291076931cc3
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameGetPublicKey Function
Gets the public key from a private/public key pair. The key pair can be supplied either as a key container name within a cryptographic service provider (CSP) or as a raw collection of bytes.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameGetPublicKey](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetpublickey-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameGetPublicKey (   
    [in]  LPCWSTR   szKeyContainer,  
    [in]  BYTE      *pbKeyBlob,  
    [in]  ULONG     cbKeyBlob,  
    [out] BYTE      **ppbPublicKeyBlob,  
    [out] ULONG     *pcbPublicKeyBlob  
);  
```  
  
#### Parameters  
 `szKeyContainer`  
 [in] The name of the key container that contains the public/private key pair. If `pbKeyBlob` is null, `szKeyContainer` must specify a valid container within the CSP. In this case, `StrongNameGetPublicKey` extracts the public key from the key pair stored in the container.  
  
 If `pbKeyBlob` is not null, the key pair is assumed to be contained in the key binary large object (BLOB).  
  
 The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.  
  
 `pbKeyBlob`  
 [in] A pointer to the public/private key pair. This pair is in the format created by the Win32 `CryptExportKey` function. If `pbKeyBlob` is null, the key container specified by `szKeyContainer` is assumed to contain the key pair.  
  
 `cbKeyBlob`  
 [in] The size, in bytes, of `pbKeyBlob`.  
  
 `ppbPublicKeyBlob`  
 [out] The returned public key BLOB. The `ppbPublicKeyBlob` parameter is allocated by the common language runtime and returned to the caller. The caller must free the memory by using the [StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/strong-naming/strongnamefreebuffer-function.md) function.  
  
 `pcbPublicKeyBlob`  
 [out] The size of the returned public key BLOB.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 The public key is contained in a [PublicKeyBlob](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md) structure.  
  
 If the `StrongNameGetPublicKey` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameGetPublicKey Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetpublickey-method.md)  
 [StrongNameTokenFromPublicKey Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfrompublickey-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)  
 [PublicKeyBlob Structure](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md)
