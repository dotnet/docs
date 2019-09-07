---
title: "StrongNameTokenFromAssembly Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameTokenFromAssembly"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameTokenFromAssembly"
helpviewer_keywords: 
  - "StrongNameTokenFromAssembly function [.NET Framework strong naming]"
ms.assetid: 0a4b47ee-02f6-4a98-864e-a6f11ca3f2d9
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# StrongNameTokenFromAssembly Function
Creates a strong name token from the specified assembly file.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameTokenFromAssembly](../hosting/iclrstrongname-strongnametokenfromassembly-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameTokenFromAssembly (  
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
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read from the assembly metadata.  
  
 After the token is created, you should call the [StrongNameFreeBuffer](strongnamefreebuffer-function.md) function to release the allocated memory.  
  
 If the `StrongNameTokenFromAssembly` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in mscoree.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameTokenFromAssembly Method](../hosting/iclrstrongname-strongnametokenfromassembly-method.md)
- [StrongNameTokenFromAssemblyEx Method](../hosting/iclrstrongname-strongnametokenfromassemblyex-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
