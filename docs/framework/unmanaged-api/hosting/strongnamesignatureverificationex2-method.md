---
title: "StrongNameSignatureVerificationEx2 Method"
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
  - "ICLRStrongName2.StrongNameSignatureVerificationEx2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "StrongNameSignatureVerificationEx2"
helpviewer_keywords: 
  - "StrongNameSignatureVerificationEx2 method, ICLRStrongName2 interface [.NET Framework hosting]"
  - "ICLRStrongName2::StrongNameSignatureVerificationEx2 method [.NET Framework hosting]"
ms.assetid: dfd4133f-a074-4db3-a7ee-4f250fe9ad3a
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameSignatureVerificationEx2 Method
Verifies the signature of a strongly named assembly, and provides a mapping from the ECMA key to a real key.  
  
## Syntax  
  
```  
HRESULT StrongNameSignatureVerificationEx (  
    [in]  LPCWSTR   wszFilePath,  
    [in]  BOOLEAN   fForceVerification,    [in]  BYTE      *pbEcmaPublicKey,  
    [in]  DWORD     cbEcmaPublicKey,  
    [out] BOOLEAN   *pfWasVerified  
);  
```  
  
#### Parameters  
 `wszFilePath`  
 [in] The path to the portable executable (.exe or .dll) file for the assembly to be verified.  
  
 `fForceVerification`  
 [in] `true` to perform verification, even if it is necessary to override registry settings; otherwise, `false`.  
  
 `pbEcmaPublicKey`  
 [in] A pointer to the mapping from the ECMA public key to the real key used for verification.  
  
 `cbEcmaPublicKey`  
 [in] The length of the real ECMA public key.  
  
 `pfWasVerified`  
 [out] `true` if the strong name signature was verified; otherwise, `false`. This parameter is also set to `false` if the verification was successful due to registry settings.  
  
## Return Value  
 `S_OK` if the verification was successful; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [StrongNameSignatureVerification Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverification-method.md)  
 [StrongNameSignatureVerificationEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverificationex-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
