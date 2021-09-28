---
description: "Learn more about: IDefinitionIdentity Interface"
title: "IDefinitionIdentity Interface"
ms.date: "03/30/2017"
api_name: 
  - "IDefinitionIdentity"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IDefinitionIdentity"
helpviewer_keywords: 
  - "IDefinitionIdentity interface [.NET Framework fusion]"
ms.assetid: ce5ba888-5fbe-4efd-91cf-f0ff94d8428b
topic_type: 
  - "apiref"
---
# IDefinitionIdentity Interface

Represents the unique signature of the code that defines the application in the current scope.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IDefinitionIdentity::Clone`|Gets an interface pointer to a new `IDefinitionIdentity` object that is identical to this `IDefinitionIdentity`, except for the specified attribute changes.|  
|`IDefinitionIdentity::EnumAttributes`|Gets an interface pointer to an [IEnumIDENTITY_ATTRIBUTE](ienumidentity-attribute-interface.md) object that contains the attributes associated with this `IDefinitionIdentity`.|  
|`IDefinitionIdentity::GetAttribute`|Gets the value of the attribute with the specified name in the specified namespace.|  
|`IDefinitionIdentity::SetAttribute`|Sets the attribute that has the specified name in the specified namespace to the specified value.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
