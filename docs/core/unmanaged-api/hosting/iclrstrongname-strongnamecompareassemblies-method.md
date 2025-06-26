---
description: "Learn more about: ICLRStrongName::StrongNameCompareAssemblies Method"
title: "ICLRStrongName::StrongNameCompareAssemblies Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameCompareAssemblies"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameCompareAssemblies"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameCompareAssemblies method [.NET Framework hosting]"
  - "StrongNameCompareAssemblies method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: b1fb356c-72cf-4aa4-8376-f291a6d97c01
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameCompareAssemblies Method

Determines whether two assemblies differ only by their strong name signatures.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameCompareAssemblies (  
    [in]  LPCWSTR   wszAssembly1,  
    [in]  LPCWSTR   wszAssembly2,  
    [out] DWORD     *pdwResult  
);  
```  
  
## Parameters  

 `wszAssembly1`  
 [in] The path to the first assembly.  
  
 `wszAssembly2`  
 [in] The path to the second assembly.  
  
 `pdwResult`  
 [out] One of the following values:  
  
- `SN_CMP_DIFFERENT` (0) - Specifies that the assemblies contain different data.  
  
- `SN_CMP_IDENTICAL` (1) - Specifies that the assemblies are exactly the same, including their signatures and checksum.  
  
- `SN_CMP_SIGONLY` (2) - Specifies that the assemblies differ only by signature and checksum.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## Remarks  

 The strong name signature of an assembly consists of the assembly's text name, version, culture, and public key token.  
  
## See also

- [ICLRStrongName Interface](iclrstrongname-interface.md)
