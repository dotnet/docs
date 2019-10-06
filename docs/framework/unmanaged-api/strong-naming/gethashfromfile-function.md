---
title: "GetHashFromFile Function"
ms.date: "03/30/2017"
api_name: 
  - "GetHashFromFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHashFromFile"
helpviewer_keywords: 
  - "GetHashFromFile function [.NET Framework strong naming]"
ms.assetid: b3c526a4-8fb4-4ad6-b6af-42ce9c06492e
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# GetHashFromFile Function
Generates a hash over the contents of the specified file.  
  
 This function has been deprecated. Use the [ICLRStrongName::GetHashFromFile](../hosting/iclrstrongname-gethashfromfile-method.md) method instead.  
  
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
  
## Remarks  
 This function is the same as [GetHashFromFileW](gethashfromfilew-function.md), except that the file name specification is ANSI instead of Unicode.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [GetHashFromFile Method](../hosting/iclrstrongname-gethashfromfile-method.md)
- [GetHashFromFileW Method](../hosting/iclrstrongname-gethashfromfilew-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
