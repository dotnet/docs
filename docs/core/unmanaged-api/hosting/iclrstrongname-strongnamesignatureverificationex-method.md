---
description: "Learn more about: ICLRStrongName::StrongNameSignatureVerificationEx Method"
title: "ICLRStrongName::StrongNameSignatureVerificationEx Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameSignatureVerificationEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameSignatureVerificationEx"
helpviewer_keywords: 
  - "StrongNameSignatureVerificationEx method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameSignatureVerificationEx method [.NET Framework hosting]"
ms.assetid: dbd2f662-208b-4174-b301-5c99af91040f
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameSignatureVerificationEx Method

Gets a value that indicates whether the assembly manifest at the supplied path contains a strong name signature.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameSignatureVerificationEx (  
    [in]  LPCWSTR   wszFilePath,  
    [in]  BOOLEAN   fForceVerification,  
    [out] BOOLEAN   *pfWasVerified  
);  
```  
  
## Parameters  

 `wszFilePath`  
 [in] The path to the portable executable (.exe or .dll) file for the assembly to be verified.  
  
 `fForceVerification`  
 [in] `true` to perform verification, even if it is necessary to override registry settings; otherwise, `false`.  
  
 `pfWasVerified`  
 [out] `true` if the strong name signature was verified; otherwise, `false`. `pfWasVerified` is also set to `false` if the verification was successful due to registry settings.  
  
## Return Value  

 `S_OK` if the verification was successful; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Remarks  

 The [ICLRStrongName::StrongNameSignatureVerificationEx](iclrstrongname-strongnamesignatureverificationex-method.md) method provides a capability similar to the [ICLRStrongName::StrongNameSignatureVerification](iclrstrongname-strongnamesignatureverification-method.md) method. However, the second input parameter and the output parameter for [ICLRStrongName::StrongNameSignatureVerificationEx](iclrstrongname-strongnamesignatureverificationex-method.md) are of type `BOOLEAN` instead of `DWORD`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [StrongNameSignatureVerification Method](iclrstrongname-strongnamesignatureverification-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
