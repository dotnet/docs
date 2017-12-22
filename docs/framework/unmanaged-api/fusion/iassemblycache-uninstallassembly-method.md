---
title: "IAssemblyCache::UninstallAssembly Method"
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
  - "IAssemblyCache.UninstallAssembly"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyCache::UninstallAssembly"
helpviewer_keywords: 
  - "UninstallAssembly method [.NET Framework fusion]"
  - "IAssemblyCache::UninstallAssembly method [.NET Framework fusion]"
ms.assetid: 973b2c44-8dfc-40c1-9035-10f4846627e9
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyCache::UninstallAssembly Method
Uninstalls the specified assembly from the global assembly cache.  
  
## Syntax  
  
```  
HRESULT UninstallAssembly (  
    [in] DWORD dwFlags,  
    [in] LPCWSTR pszAssemblyName,  
    [in] LPCFUSION_INSTALL_REFERENCE pRefData,  
    [out, optional] ULONG *pulDisposition  
);  
```  
  
#### Parameters  
 `dwFlags`  
 [in] Flags defined in Fusion.idl.  
  
 `pszAssemblyName`  
 [in] The name of the assembly to uninstall.  
  
 `pRefData`  
 [in] A [FUSION_INSTALL_REFERENCE](../../../../docs/framework/unmanaged-api/fusion/fusion-install-reference-structure.md) structure that contains the installation data for the assembly.  
  
 `pulDisposition`  
 [out, optional] One of the disposition values defined in Fusion.idl. Possible values include the following:  
  
-   IASSEMBLYCACHE_UNINSTALL_DISPOSITION_UNINSTALLED (1)  
  
-   IASSEMBLYCACHE_UNINSTALL_DISPOSITION_STILL_IN_USE (2)  
  
-   IASSEMBLYCACHE_UNINSTALL_DISPOSITION_ALREADY_UNINSTALLED (3)  
  
-   IASSEMBLYCACHE_UNINSTALL_DISPOSITION_DELETE_PENDING (4)  
  
-   IASSEMBLYCACHE_UNINSTALL_DISPOSITION_HAS_INSTALL_REFERENCES (5)  
  
-   IASSEMBLYCACHE_UNINSTALL_DISPOSITION_REFERENCE_NOT_FOUND (6)  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyCache Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-interface.md)
