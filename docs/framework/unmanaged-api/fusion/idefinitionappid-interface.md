---
title: "IDefinitionAppId Interface"
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
  - "IDefinitionAppId"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IDefinitionAppId"
helpviewer_keywords: 
  - "IDefinitionAppId interface [.NET Framework fusion]"
ms.assetid: e72f2550-bdec-4a20-a2f4-2e14847266c1
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IDefinitionAppId Interface
Represents a unique identifier for the code that defines the application in the current scope.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IDefinitionAppId::get_Codebase`|Gets a formatted string that represents the code in this `IDefinitionAppId` object.|  
|`IDefinitionAppId::put_Codebase`|Sets the code of this `IDefinitionAppId` object to the specified formatted string value.|  
|`IDefinitionAppId::EnumAppPath`|Gets an interface pointer to an [IEnumDefinitionIdentity](../../../../docs/framework/unmanaged-api/fusion/ienumdefinitionidentity-interface.md) object that contains the assemblies in the current application path.|  
|`IDefinitionAppId::SetAppPath`|Sets the application path for the assembly in the current scope to the value referenced by the specified [IDefinitionIdentity](../../../../docs/framework/unmanaged-api/fusion/idefinitionidentity-interface.md) object.|  
|`IDefinitionAppId::get_SubscriptionId`|Gets a pointer to a string representation of the token identifier for a subscription to this `IDefinitionAppId` object.|  
|`IDefinitionAppId::put_SubscriptionId`|Sets the token identifier for a subscription to this `IDefinitionAppId` object to the specified string value.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)
