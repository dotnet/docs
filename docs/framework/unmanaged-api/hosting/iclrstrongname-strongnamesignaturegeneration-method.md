---
title: "ICLRStrongName::StrongNameSignatureGeneration Method"
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
  - "ICLRStrongName.StrongNameSignatureGeneration"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameSignatureGeneration"
helpviewer_keywords: 
  - "StrongNameSignatureGeneration method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameSignatureGeneration method [.NET Framework hosting]"
ms.assetid: 4cdb1284-947a-4ed4-94c1-c5ff5cdfce56
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameSignatureGeneration Method
Generates a strong name signature for the specified assembly.  
  
## Syntax  
  
```  
HRESULT StrongNameSignatureGeneration (   
    [in]  LPCWSTR   wszFilePath,  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  BYTE      *pbKeyBlob,  
    [in]  ULONG     cbKeyBlob,  
    [out] BYTE      **ppbSignatureBlob,  
    [out] ULONG     *pcbSignatureBlob  
);  
```  
  
#### Parameters  
 `wszFilePath`  
 [in] The path to the file that contains the manifest of the assembly for which the strong name signature will be generated.  
  
 `wszKeyContainer`  
 [in] The name of the key container that contains the public/private key pair.  
  
 If `pbKeyBlob` is null, `wszKeyContainer` must specify a valid container within the cryptographic service provider (CSP). In this case, the key pair stored in the container is used to sign the file.  
  
 If `pbKeyBlob` is not null, the key pair is assumed to be contained in the key binary large object (BLOB).  
  
 The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.  
  
 `pbKeyBlob`  
 [in] A pointer to the public/private key pair. This pair is in the format created by the Win32 `CryptExportKey` function. If `pbKeyBlob` is null, the key container specified by `wszKeyContainer` is assumed to contain the key pair.  
  
 `cbKeyBlob`  
 [in] The size, in bytes, of `pbKeyBlob`.  
  
 `ppbSignatureBlob`  
 [out] A pointer to the location to which the common language runtime returns the signature. If `ppbSignatureBlob` is null, the runtime stores the signature in the file specified by `wszFilePath`.  
  
 If `ppbSignatureBlob` is not null, the common language runtime allocates space in which to return the signature. The caller must free this space by using the [ICLRStrongName::StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamefreebuffer-method.md) method.  
  
 `pcbSignatureBlob`  
 [out] The size, in bytes, of the returned signature.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Remarks  
 Specify null for `wszFilePath` to calculate the size of the signature without creating the signature.  
  
 The signature can be stored either directly in the file, or returned to the caller.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [StrongNameSignatureGenerationEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignaturegenerationex-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
