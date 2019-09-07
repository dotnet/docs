---
title: "PublicKeyBlob Structure"
ms.date: "03/30/2017"
api_name: 
  - "PublicKeyBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "PublicKeyBlob"
helpviewer_keywords: 
  - "PublicKeyBlob structure [.NET Framework strong naming]"
ms.assetid: b9240712-829c-4c8d-9a09-a6e7aa63f63a
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# PublicKeyBlob Structure
Represents, in binary format, the public key of a public/private key pair.  
  
## Syntax  
  
```cpp  
typedef struct {  
    unsigned int SigAlgId;  
    unsigned int HashAlgId;  
    ULONG cbPublicKey;  
    BYTE PublicKey[1]  
} PublicKeyBlob;   
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`SigAlgId`|The identifier for the signature algorithm (of type `ALG_ID`, as defined in WinCrypt.h) of the public key.|  
|`HashAlgId`|The identifier for the hash algorithm (of type `ALG_ID`, as defined in WinCrypt.h) of the public key.|  
|`cbPublicKey`|The length of the key in bytes.|  
|`PublicKey`|A variable-length byte array that contains the key value in the format returned by the CryptoAPI.|  
  
## Remarks  
 The `PublicKeyBlob` structure is used by [StrongNameGetPublicKey](strongnamegetpublickey-function.md), [StrongNameSignatureGeneration](strongnamesignaturegeneration-function.md), and other strong name functions to represent the public key of a public/private key pair.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameGetPublicKey Function](strongnamegetpublickey-function.md)
- [StrongNameSignatureGeneration Function](strongnamesignaturegeneration-function.md)
