---
description: "Learn more about: GetHashFromAssemblyFileW Function"
title: "GetHashFromAssemblyFileW Function"
ms.date: "03/30/2017"
api_name: 
  - "GetHashFromAssemblyFileW"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHashFromAssemblyFileW"
helpviewer_keywords: 
  - "GetHashFromAssemblyFileW function [.NET Framework strong naming]"
ms.assetid: d1b2b172-5353-42af-a877-cf653c68ece0
topic_type: 
  - "apiref"
---
# GetHashFromAssemblyFileW Function

Gets a hash of the specified assembly file, using the specified hash algorithm. The path to the assembly file must be specified as a Unicode string.  
  
 This function has been deprecated. Use the [ICLRStrongName::GetHashFromAssemblyFileW](../hosting/iclrstrongname-gethashfromassemblyfilew-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT GetHashFromAssemblyFileW (  
    [in]  LPCWSTR   wszFilePath,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE      *pbHash,  
    [in]  DWORD     cchHash,  
    [out] DWORD     *pchHash  
);  
```  
  
## Parameters  

 `wszFilePath`  
 [in] The path to the file to be hashed. This parameter must be a Unicode string.  
  
 `piHashAlg`  
 [in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.  
  
 `pbHash`  
 [out] The returned hash buffer.  
  
 `cchHash`  
 [in] The requested maximum size of `pbHash`.  
  
 `pchHash`  
 [out] The returned size, in bytes, of `pbHash`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [GetHashFromAssemblyFileW Method](../hosting/iclrstrongname-gethashfromassemblyfilew-method.md)
- [GetHashFromAssemblyFile Method](../hosting/iclrstrongname-gethashfromassemblyfile-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
