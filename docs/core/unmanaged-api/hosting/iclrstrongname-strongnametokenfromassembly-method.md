---
description: "Learn more about: ICLRStrongName::StrongNameTokenFromAssembly Method"
title: "ICLRStrongName::StrongNameTokenFromAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameTokenFromAssembly"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameTokenFromAssembly"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameTokenFromAssembly method [.NET Framework hosting]"
  - "StrongNameTokenFromAssembly method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: fc725afb-b66b-4015-aa44-1c0d1304197f
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameTokenFromAssembly Method

Creates a strong name token from the specified assembly file.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameTokenFromAssembly (  
    [in]  LPCWSTR   wszFilePath,  
    [out] BYTE      **ppbStrongNameToken,  
    [out] ULONG     *pcbStrongNameToken  
);  
```  
  
## Parameters  

 `wszFilePath`  
 [in] The path to the portable executable (PE) file for the assembly.  
  
 `ppbStrongNameToken`  
 [out] The returned strong name token.  
  
 `pcbStrongNameToken`  
 [out] The size, in bytes, of the strong name token.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Remarks  

 A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read from the assembly metadata.  
  
 After the token is created, you should call the [ICLRStrongName::StrongNameFreeBuffer](iclrstrongname-strongnamefreebuffer-method.md) method to release the allocated memory.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [StrongNameTokenFromAssemblyEx Method](iclrstrongname-strongnametokenfromassemblyex-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
