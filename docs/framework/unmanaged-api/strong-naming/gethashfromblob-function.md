---
title: "GetHashFromBlob Function"
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
  - "GetHashFromBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHashFromBlob"
helpviewer_keywords: 
  - "GetHashFromBlob function [.NET Framework strong naming]"
ms.assetid: b712d862-f2d0-4b55-87d4-65bbeadef982
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetHashFromBlob Function
Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.  
  
 This function has been deprecated. Use the [ICLRStronName::GetHashFromBlob](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromblob-method.md) method instead.  
  
## Syntax  
  
```  
HRESULT GetHashFromBlob (  
    [in]  BYTE    *pbBlob,  
    [in]  DWORD   cchBlob,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE    *pbHash,  
    [in]  DWORD   cchHash,  
    [out] DWORD   *pchHash  
);  
```  
  
#### Parameters  
 `pbBlob`  
 [in] A pointer to the address of the memory block to be hashed.  
  
 `cchBlob`  
 [in] The length, in bytes, of the memory block.  
  
 `piHashAlg`  
 [in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.  
  
 `pbHash`  
 [out] The returned hash buffer.  
  
 `cchHash`  
 [in] The requested maximum size of `pbHash`.  
  
 `pchHash`  
 [out] The size, in bytes, of the returned `pbHash`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [GetHashFromBlob Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromblob-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
