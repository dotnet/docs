---
title: "IAssemblyCacheItem Interface"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyCacheItem"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyCacheItem"
helpviewer_keywords: 
  - "IAssemblyCacheItem interface [.NET Framework fusion]"
ms.assetid: ccc9387a-9f44-4f4f-bf8f-0ea6d2afa21b
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IAssemblyCacheItem Interface
Represents a single assembly in the global assembly cache.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[AbortItem Method](iassemblycacheitem-abortitem-method.md)|Allows the assembly in the global assembly cache to perform cleanup operations before it is released.|  
|[Commit Method](iassemblycacheitem-commit-method.md)|Commits the cached assembly reference to memory.|  
|[CreateStream Method](iassemblycacheitem-createstream-method.md)|Creates a stream with the specified name and format.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
- [Global Assembly Cache](../../app-domains/gac.md)
- [IAssemblyCache Interface](iassemblycache-interface.md)
