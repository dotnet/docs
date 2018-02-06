---
title: "IAssemblyCache::CreateAssemblyCacheItem Method"
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
  - "IAssemblyCache.CreateAssemblyCacheItem"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyCache::CreateAssemblyCacheItem"
helpviewer_keywords: 
  - "IAssemblyCache::CreateAssemblyCacheItem method [.NET Framework fusion]"
  - "CreateAssemblyCacheItem method [.NET Framework fusion]"
ms.assetid: 017a7ba5-aaaf-44e2-9cbe-ceebef259df0
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyCache::CreateAssemblyCacheItem Method
Gets a reference to a new [IAssemblyCacheItem](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-interface.md) object.  
  
## Syntax  
  
```  
HRESULT CreateAssemblyCacheItem (  
    [in]  DWORD dwFlags,  
    [in]  PVOID pvReserved,  
    [out] IAssemblyCacheItem **ppAsmItem,  
    [in, optional] LPCWSTR pszAssemblyName  
);  
```  
  
#### Parameters  
 `dwFlags`  
 [in] Flags defined in Fusion.idl. The following values are supported:  
  
-   IASSEMBLYCACHE_INSTALL_FLAG_REFRESH (0x00000001)  
  
-   IASSEMBLYCACHE_INSTALL_FLAG_FORCE_REFRESH (0x00000002)  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
 `ppAsmItem`  
 [out] The returned `IAssemblyCacheItem` pointer.  
  
 `pszAssemblyName`  
 [in, optional] Uncanonicalized, comma-separated `name=value` pairs.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyCache Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-interface.md)  
 [IAssemblyCacheItem Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-interface.md)
