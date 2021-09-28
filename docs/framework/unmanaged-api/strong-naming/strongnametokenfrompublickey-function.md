---
description: "Learn more about: StrongNameTokenFromPublicKey Function"
title: "StrongNameTokenFromPublicKey Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameTokenFromPublicKey"
api_location: 
  - "mscoree.dll"
  - "mscorsn.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "StrongNameTokenFromPublicKey"
helpviewer_keywords: 
  - "StrongNameTokenFromPublicKey function [.NET Framework strong naming]"
ms.assetid: 997e9e57-abb2-4217-bf20-1df621a75add
topic_type: 
  - "apiref"
---
# StrongNameTokenFromPublicKey Function

Gets a token representing a public key. A strong name token is the shortened form of a public key.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameTokenFromPublicKey](../hosting/iclrstrongname-strongnametokenfrompublickey-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameTokenFromPublicKey (
    [in]  BYTE    *pbPublicKeyBlob,  
    [in]  ULONG   cbPublicKeyBlob,  
    [out] BYTE    **ppbStrongNameToken,  
    [out] ULONG   *pcbStrongNameToken  
);  
```  
  
## Parameters  

 `pbPublicKeyBlob`  
 [in] A structure of type [PublicKeyBlob](publickeyblob-structure.md) that contains the public portion of the key pair used to generate the strong name signature.  
  
 `cbPublicKeyBlob`  
 [in] The size, in bytes, of `pbPublicKeyBlob`.  
  
 `ppbStrongNameToken`  
 [out] The strong name token corresponding to the key passed in `pbPublicKeyBlob`. The common language runtime allocates the memory in which to return the token. The caller must free this memory by using the [StrongNameFreeBuffer](strongnamefreebuffer-function.md) function.  
  
 `pcbStrongNameToken`  
 [out] The size, in bytes, of the returned strong name token.  
  
## Return Value  

 `true` on successful completion; otherwise, `false`.  
  
## Remarks  

 A strong name token is the shortened form of a public key used to save space when storing key information in metadata. Specifically, strong name tokens are used in assembly references to refer to the dependent assembly.  
  
 If the `StrongNameTokenFromPublicKey` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in mscoree.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameTokenFromPublicKey Method](../hosting/iclrstrongname-strongnametokenfrompublickey-method.md)
- [StrongNameGetPublicKey Method](../hosting/iclrstrongname-strongnamegetpublickey-method.md)
- [PublicKeyBlob Structure](publickeyblob-structure.md)
