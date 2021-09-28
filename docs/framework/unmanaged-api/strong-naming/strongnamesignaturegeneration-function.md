---
description: "Learn more about: StrongNameSignatureGeneration Function"
title: "StrongNameSignatureGeneration Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameSignatureGeneration"
api_location: 
  - "mscoree.dll"
  - "mscorsn.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameSignatureGeneration"
helpviewer_keywords: 
  - "StrongNameSignatureGeneration function [.NET Framework strong naming]"
ms.assetid: 839b765c-3e41-44ce-bf1b-dc10453db18e
---
# StrongNameSignatureGeneration Function

Generates a strong name signature for the specified assembly.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameSignatureGeneration](../hosting/iclrstrongname-strongnamesignaturegeneration-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameSignatureGeneration (
    [in]  LPCWSTR   wszFilePath,  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  BYTE      *pbKeyBlob,  
    [in]  ULONG     cbKeyBlob,  
    [out] BYTE      **ppbSignatureBlob,  
    [out] ULONG     *pcbSignatureBlob  
);  
```  
  
## Parameters  

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
  
 If `ppbSignatureBlob` is not null, the common language runtime allocates space in which to return the signature. The caller must free this space using the [StrongNameFreeBuffer](strongnamefreebuffer-function.md) function.  
  
 `pcbSignatureBlob`  
 [out] The size, in bytes, of the returned signature.  
  
## Return Value  

 `true` on successful completion; otherwise, `false`.  
  
## Remarks  

 Specify null for `wszFilePath` to calculate the size of the signature without creating the signature.  
  
 The signature can be stored either directly in the file, or returned to the caller.  
  
 If the `StrongNameSignatureGeneration` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameSignatureGeneration Method](../hosting/iclrstrongname-strongnamesignaturegeneration-method.md)
- [StrongNameSignatureGenerationEx Method](../hosting/iclrstrongname-strongnamesignaturegenerationex-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
