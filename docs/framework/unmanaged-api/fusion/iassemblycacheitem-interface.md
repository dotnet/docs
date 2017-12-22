---
title: "IAssemblyCacheItem Interface"
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
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyCacheItem Interface
Represents a single assembly in the global assembly cache.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[AbortItem Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-abortitem-method.md)|Allows the assembly in the global assembly cache to perform cleanup operations before it is released.|  
|[Commit Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-commit-method.md)|Commits the cached assembly reference to memory.|  
|[CreateStream Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-createstream-method.md)|Creates a stream with the specified name and format.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)  
 [IAssemblyCache Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-interface.md)
