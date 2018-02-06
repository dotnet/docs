---
title: "IAssemblyName Interface"
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
  - "IAssemblyName"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyName"
helpviewer_keywords: 
  - "IAssemblyName interface [.NET Framework fusion]"
ms.assetid: f7f8e605-6b67-4151-936f-f04ecd671d90
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IAssemblyName Interface
Provides methods for describing and working with an assembly's unique identity.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Clone Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-clone-method.md)|Creates a shallow copy of this `IAssemblyName` object.|  
|[Finalize Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-finalize-method.md)|Allows this `IAssemblyName` object to release resources and perform other cleanup operations before its destructor is called.|  
|[GetDisplayName Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-getdisplayname-method.md)|Gets the human-readable name of the assembly referenced by this `IAssemblyName` object.|  
|[GetName Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-getname-method.md)|Gets the simple, unencrypted name of the assembly referenced by this `IAssemblyName` object.|  
|[GetProperty Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-getproperty-method.md)|Gets a pointer to the property referenced by the specified `PropertyId`.|  
|[GetVersion Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-getversion-method.md)|Gets the version information for the assembly referenced by this `IAssemblyName` object.|  
|[IsEqual Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-isequal-method.md)|Determines whether a specified `IAssemblyName` object is equal to this `IAssemblyName`, based on the specified comparison flags.|  
|[SetProperty Method](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-setproperty-method.md)|Sets the value of the property referenced by the specified `PropertyId`.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)  
 [IAssemblyEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyenum-interface.md)
