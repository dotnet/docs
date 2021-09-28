---
description: "Learn more about: GetHashFromAssemblyFile Function"
title: "GetHashFromAssemblyFile Function"
ms.date: "03/30/2017"
api_name: 
  - "GetHashFromAssemblyFile"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHashFromAssemblyFile"
helpviewer_keywords: 
  - "GetHashFromAssemblyFile function [.NET Framework strong naming]"
ms.assetid: 751ed69f-b7ab-4e07-80de-e17ca9319b0c
topic_type: 
  - "apiref"
---
# GetHashFromAssemblyFile Function

Gets a hash of the specified assembly file, using the specified hash algorithm.  
  
 This function has been deprecated. Use the [ICLRStrongName::GetHashFromAssemblyFile](../hosting/iclrstrongname-gethashfromassemblyfile-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT GetHashFromAssemblyFile (  
    [in]  LPCSTR   szFilePath,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE     *pbHash,  
    [in]  DWORD    cchHash,  
    [out] DWORD    *pchHash  
);  
```  
  
## Parameters  

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
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [GetHashFromAssemblyFile Method](../hosting/iclrstrongname-gethashfromassemblyfile-method.md)
- [GetHashFromAssemblyFileW Method](../hosting/iclrstrongname-gethashfromassemblyfilew-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
