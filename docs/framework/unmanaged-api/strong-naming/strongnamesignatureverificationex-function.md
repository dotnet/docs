---
description: "Learn more about: StrongNameSignatureVerificationEx Function"
title: "StrongNameSignatureVerificationEx Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameSignatureVerificationEx"
api_location: 
  - "mscoree.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameSignatureVerificationEx"
helpviewer_keywords: 
  - "StrongNameSignatureVerificationEx function [.NET Framework strong naming]"
ms.assetid: cfe4b634-18bf-44b8-9773-d94fb7e8a480
topic_type: 
  - "apiref"
---
# StrongNameSignatureVerificationEx Function

Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameSignatureVerificationEx](../hosting/iclrstrongname-strongnamesignatureverificationex-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameSignatureVerificationEx (  
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

 `true` if the verification was successful; otherwise, `false`.  
  
## Remarks  

 `StrongNameSignatureVerificationEx` provides a capability similar to the [StrongNameSignatureVerification](strongnamesignatureverification-function.md) function. However, the second input parameter and the output parameter for `StrongNameSignatureVerificationEx` are of type `BOOLEAN` instead of `DWORD`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in mscoree.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameSignatureVerificationEx Method](../hosting/iclrstrongname-strongnamesignatureverificationex-method.md)
- [StrongNameSignatureVerification Method](../hosting/iclrstrongname-strongnamesignatureverification-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
