---
title: "IAssemblyCache Interface"
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
  - "IAssemblyCache"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyCache"
helpviewer_keywords: 
  - "IAssemblyCache interface [.NET Framework fusion]"
ms.assetid: 71ea170f-872d-4fc5-81b6-27da1dec9b19
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyCache Interface
Represents the global assembly cache for use by the fusion technology.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateAssemblyCacheItem Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-createassemblycacheitem-method.md)|Gets a reference to a new [IAssemblyCacheItem](../../../../docs/framework/unmanaged-api/fusion/iassemblycacheitem-interface.md).|  
|[CreateAssemblyScavenger Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-createassemblyscavenger-method.md)|Reserved for internal use by the fusion technology.|  
|[InstallAssembly Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-installassembly-method.md)|Installs the specified assembly in the global assembly cache.|  
|[QueryAssemblyInfo Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-queryassemblyinfo-method.md)|Gets the requested data about the specified assembly.|  
|[UninstallAssembly Method](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-uninstallassembly-method.md)|Uninstalls the specified assembly from the global assembly cache.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)
