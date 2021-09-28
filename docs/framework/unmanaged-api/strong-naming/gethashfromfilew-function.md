---
description: "Learn more about: GetHashFromFileW Function"
title: "GetHashFromFileW Function"
ms.date: "03/30/2017"
api_name: 
  - "GetHashFromFileW"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHashFromFileW"
helpviewer_keywords: 
  - "GetHashFromFileW function [.NET Framework strong naming]"
ms.assetid: 97c2d7a6-5376-45a1-ba65-146a249147cc
topic_type: 
  - "apiref"
---
# GetHashFromFileW Function

Generates a hash over the contents of the file specified by a Unicode string.  
  
 This function has been deprecated. Use the [ICLRStrongName::GetHashFromFileW](../hosting/iclrstrongname-gethashfromfilew-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT GetHashFromFileW (
    [in]  LPCWSTR   wszFilePath,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE      *pbHash,  
    [in]  DWORD     cchHash,  
    [out] DWORD     *pchHash  
);
```  
  
## Parameters  

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
  
## Remarks  

 This function is the same as [GetHashFromFile](gethashfromfile-function.md), except that the file name specification is Unicode instead of ANSI.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [GetHashFromFileW Method](../hosting/iclrstrongname-gethashfromfilew-method.md)
- [GetHashFromFile Method](../hosting/iclrstrongname-gethashfromfile-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
