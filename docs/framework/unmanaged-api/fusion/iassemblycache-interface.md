---
title: "IAssemblyCache Interface"
ms.date: "03/30/2017"
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
---
# IAssemblyCache Interface
Represents the global assembly cache for use by the fusion technology.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateAssemblyCacheItem Method](iassemblycache-createassemblycacheitem-method.md)|Gets a reference to a new [IAssemblyCacheItem](iassemblycacheitem-interface.md).|  
|[CreateAssemblyScavenger Method](iassemblycache-createassemblyscavenger-method.md)|Reserved for internal use by the fusion technology.|  
|[InstallAssembly Method](iassemblycache-installassembly-method.md)|Installs the specified assembly in the global assembly cache.|  
|[QueryAssemblyInfo Method](iassemblycache-queryassemblyinfo-method.md)|Gets the requested data about the specified assembly.|  
|[UninstallAssembly Method](iassemblycache-uninstallassembly-method.md)|Uninstalls the specified assembly from the global assembly cache.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
- [Global Assembly Cache](../../app-domains/gac.md)
