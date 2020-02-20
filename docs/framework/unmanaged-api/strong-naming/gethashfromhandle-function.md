---
title: "GetHashFromHandle Function"
ms.date: "03/30/2017"
api_name: 
  - "GetHashFromHandle"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHashFromHandle"
helpviewer_keywords: 
  - "GetHashFromHandle function [.NET Framework strong naming]"
ms.assetid: 9e00337f-b307-4602-9bc3-965a8dbf02cd
topic_type: 
  - "apiref"
---
# GetHashFromHandle Function
Generates a hash over the contents of the file with the specified file handle, using the specified hash algorithm.  
  
 This function has been deprecated. Use the [ICLRStrongName::GetHashFromHandle](../hosting/iclrstrongname-gethashfromhandle-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT GetHashFromHandle (  
    [in]  HANDLE   hFile,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE     *pbHash,  
    [in]  DWORD    cchHash,  
    [out] DWORD    *pchHash  
);  
```  
  
## Parameters  
 `hFile`  
 [in] The handle of the file to be hashed.  
  
 `piHashAlg`  
 [in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.  
  
 `pbHash`  
 [out] The returned hash buffer.  
  
 `cchHash`  
 [in] The requested maximum size of `pbHash`.  
  
 `pchHash`  
 [out] The size, in bytes, of the returned `pbHash`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [GetHashFromHandle Method](../hosting/iclrstrongname-gethashfromhandle-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
