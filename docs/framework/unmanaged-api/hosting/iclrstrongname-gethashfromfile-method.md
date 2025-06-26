---
description: "Learn more about: ICLRStrongName::GetHashFromFile Method"
title: "ICLRStrongName::GetHashFromFile Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.GetHashFromFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::GetHashFromFile"
helpviewer_keywords: 
  - "ICLRStrongName::GetHashFromFile method [.NET Framework hosting]"
  - "GetHashFromFile method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 9e50480a-8ada-4044-b2a5-97bb14ed3525
topic_type: 
  - "apiref"
---
# ICLRStrongName::GetHashFromFile Method

Generates a hash over the contents of the specified file.  
  
## Syntax  
  
```cpp  
HRESULT GetHashFromFile (  
    [in]  LPCSTR   szFilePath,  
    [in, out] unsigned int   *piHashAlg,
    [out] BYTE     *pbHash,
    [in]  DWORD    cchHash,
    [out] DWORD    *pchHash  
);  
```  
  
## Parameters  

 `szFilePath`  
 [in] The name of the file to hash.  
  
 `piHashAlg`  
 [in, out] The algorithm to use when generating the hash. Valid algorithms are those defined by the Win32 CryptoAPI. If `piHashAlg` is set to 0, the default algorithm CALG_SHA-1 is used.  
  
 `pbHash`  
 [out] A byte array containing the generated hash.  
  
 `cchHash`  
 [in] The maximum size of the buffer that `pbHash` points to.  
  
 `pchHash`  
 [out] The size, in bytes, of the returned `pbHash`.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Remarks  

 This method is the same as the [ICLRStrongName::GetHashFromFileW](iclrstrongname-gethashfromfilew-method.md) method, except that the file name specification is ANSI instead of Unicode.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [GetHashFromFileW Method](iclrstrongname-gethashfromfilew-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
