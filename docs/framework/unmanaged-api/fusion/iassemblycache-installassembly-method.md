---
description: "Learn more about: IAssemblyCache::InstallAssembly Method"
title: "IAssemblyCache::InstallAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyCache.InstallAssembly"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyCache::InstallAssembly"
helpviewer_keywords: 
  - "InstallAssembly method [.NET Framework fusion]"
  - "IAssemblyCache::InstallAssembly method [.NET Framework fusion]"
ms.assetid: 33c1d269-c85e-4cb1-b0e6-1c510c8fb5fa
topic_type: 
  - "apiref"
---
# IAssemblyCache::InstallAssembly Method

Installs the specified assembly in the global assembly cache.  
  
## Syntax  
  
```cpp  
HRESULT InstallAssembly (  
    [in] DWORD dwFlags,  
    [in] LPCWSTR pszManifestFilePath,  
    [in] LPCFUSION_INSTALL_REFERENCE pRefData  
);  
```  
  
## Parameters  

 `dwFlags`  
 [in] Flags defined in Fusion.idl. The following values are supported:  
  
- IASSEMBLYCACHE_INSTALL_FLAG_REFRESH (0x00000001)  
  
- IASSEMBLYCACHE_INSTALL_FLAG_FORCE_REFRESH (0x00000002)  
  
 `pszManifestFilePath`  
 [in] The path to the manifest for the assembly to install.  
  
 `pRefData`  
 [in] A [FUSION_INSTALL_REFERENCE](fusion-install-reference-structure.md) structure that contains data for the installation.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyCache Interface](iassemblycache-interface.md)
