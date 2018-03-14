---
title: "ICLRStrongName::GetHashFromAssemblyFile Method"
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
  - "ICLRStrongName.GetHashFromAssemblyFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::GetHashFromAssemblyFile"
helpviewer_keywords: 
  - "ICLRStrongName::GetHashFromAssemblyFile method [.NET Framework hosting]"
  - "GetHashFromAssemblyFile method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 0b67ea03-d474-4605-acaa-57455790250c
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::GetHashFromAssemblyFile Method
Gets a hash of the specified assembly file, using the specified hash algorithm.  
  
## Syntax  
  
```  
HRESULT GetHashFromAssemblyFile (  
    [in]  LPCSTR   szFilePath,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE     *pbHash,  
    [in]  DWORD    cchHash,  
    [out] DWORD    *pchHash  
);  
```  
  
#### Parameters  
 `szFilePath`  
 [in] The path to the file to be hashed.  
  
 `piHashAlg`  
 [in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.  
  
 `pbHash`  
 [out] The returned hash buffer.  
  
 `cchHash`  
 [in] The requested maximum size of `pbHash`.  
  
 `pchHash`  
 [out] The returned size, in bytes, of `pbHash`.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [GetHashFromAssemblyFileW Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromassemblyfilew-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
