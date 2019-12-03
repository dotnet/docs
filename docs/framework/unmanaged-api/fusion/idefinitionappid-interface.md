---
title: "IDefinitionAppId Interface"
ms.date: "03/30/2017"
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
---
# IDefinitionAppId Interface
Represents a unique identifier for the code that defines the application in the current scope.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IDefinitionAppId::get_Codebase`|Gets a formatted string that represents the code in this `IDefinitionAppId` object.|  
|`IDefinitionAppId::put_Codebase`|Sets the code of this `IDefinitionAppId` object to the specified formatted string value.|  
|`IDefinitionAppId::EnumAppPath`|Gets an interface pointer to an [IEnumDefinitionIdentity](ienumdefinitionidentity-interface.md) object that contains the assemblies in the current application path.|  
|`IDefinitionAppId::SetAppPath`|Sets the application path for the assembly in the current scope to the value referenced by the specified [IDefinitionIdentity](idefinitionidentity-interface.md) object.|  
|`IDefinitionAppId::get_SubscriptionId`|Gets a pointer to a string representation of the token identifier for a subscription to this `IDefinitionAppId` object.|  
|`IDefinitionAppId::put_SubscriptionId`|Sets the token identifier for a subscription to this `IDefinitionAppId` object to the specified string value.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
