---
title: "StrongNameCompareAssemblies Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "StrongNameCompareAssemblies"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameCompareAssemblies"
helpviewer_keywords: 
  - "StrongNameCompareAssemblies function [.NET Framework strong naming]"
ms.assetid: 763f2375-efc6-4219-8806-a3b0567ef72b
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameCompareAssemblies Function
Determines whether two assemblies differ only by their strong name signatures.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameCompareAssemblies](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamecompareassemblies-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameCompareAssemblies (  
    [in]  LPCWSTR   wszAssembly1,  
    [in]  LPCWSTR   wszAssembly2,  
    [out] DWORD     *pdwResult  
);  
```  
  
#### Parameters  
 `wszAssembly1`  
 [in] The path to the first assembly.  
  
 `wszAssembly2`  
 [in] The path to the second assembly.  
  
 `pdwResult`  
 [out] One of the following values:  
  
-   `SN_CMP_DIFFERENT` (0) - Specifies that the assemblies contain different data.  
  
-   `SN_CMP_IDENTICAL` (1) - Specifies that the assemblies are exactly the same, including their signatures and checksum.  
  
-   `SN_CMP_SIGONLY` (2) - Specifies that the assemblies differ only by signature and checksum.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## Remarks  
 The strong name signature of an assembly consists of the assembly's text name, version, culture, and public key token.  
  
 If the `StrongNameCompareAssemblies` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## See Also  
 [StrongNameCompareAssemblies Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamecompareassemblies-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
