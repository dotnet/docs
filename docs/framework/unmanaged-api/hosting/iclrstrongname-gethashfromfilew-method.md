---
title: "ICLRStrongName::GetHashFromFileW Method"
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
  - "ICLRStrongName.GetHashFromFileW"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::GetHashFromFileW"
helpviewer_keywords: 
  - "GetHashFromFileW method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::GetHashFromFileW method [.NET Framework hosting]"
ms.assetid: c6ff45fc-905d-4c6e-b00c-97c6c7c55d99
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::GetHashFromFileW Method
Generates a hash over the contents of the file specified by a Unicode string.  
  
## Syntax  
  
```  
HRESULT GetHashFromFileW (   
    [in]  LPCWSTR   wszFilePath,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE      *pbHash,  
    [in]  DWORD     cchHash,  
    [out] DWORD     *pchHash  
);   
```  
  
#### Parameters  
 `wszFilePath`  
 [in] The Unicode name of the file to hash.  
  
 `piHashAlg`  
 [in, out] The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI. If `piHashAlg` is set to 0, the default algorithm CALG_SHA-1 is used.  
  
 `pbHash`  
 [out] A byte array containing the generated hash.  
  
 `cchHash`  
 [in] The maximum size of the buffer pointed to by `pbHash`.  
  
 `pchHash`  
 [out] The size, in bytes, of `pbHash`.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Remarks  
 This method is the same as the [ICLRStrongName::GetHashFromFile](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromfile-method.md) method, except that the file name specification is Unicode instead of ANSI.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [GetHashFromFile Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromfile-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
