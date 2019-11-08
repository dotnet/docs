---
title: "ICLRStrongName::GetHashFromHandle Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.GetHashFromHandle"
  - "ICLRStrongName.StrongNameCompareAssemblies"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::GetHashFromHandle"
helpviewer_keywords: 
  - "GetHashFromHandle method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::GetHashFromHandle method [.NET Framework hosting]"
ms.assetid: 3bedbb7d-3cdd-4175-b370-10ae734062db
topic_type: 
  - "apiref"
---
# ICLRStrongName::GetHashFromHandle Method
Generates a hash over the contents of the file that has the specified file handle, using the specified hash algorithm.  
  
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
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](https://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
