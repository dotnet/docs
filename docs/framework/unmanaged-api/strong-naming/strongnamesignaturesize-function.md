---
title: "StrongNameSignatureSize Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameSignatureSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameSignatureSize"
helpviewer_keywords: 
  - "StrongNameSignatureSize function [.NET Framework strong naming]"
ms.assetid: 4fde4cd0-f53e-4411-a2fe-fc5c54472f95
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# StrongNameSignatureSize Function
Returns the size of the strong name signature. `StrongNameSignatureSize` is typically used by compilers to determine how much space to reserve in the file when creating a delay-signed assembly.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameSignatureSize](../hosting/iclrstrongname-strongnamesignaturesize-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameSignatureSize (   
    [in]  BYTE   *pbPublicKeyBlob,  
    [in]  ULONG  cbPublicKeyBlob,   
    [in]  DWORD  *pcbSize  
);   
```  
  
## Parameters  
 `pbPublicKeyBlob`  
 [in] A structure of type [PublicKeyBlob](publickeyblob-structure.md) that contains the public portion of the key pair used to generate the strong name signature.  
  
 `cbPublicKeyBlob`  
 [in] The size, in bytes, of `pbPublicKeyBlob`.  
  
 `pcbSize`  
 [in] The number of bytes required to store the strong name signature.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 If the `StrongNameSignatureSize` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameSignatureSize Method](../hosting/iclrstrongname-strongnamesignaturesize-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
