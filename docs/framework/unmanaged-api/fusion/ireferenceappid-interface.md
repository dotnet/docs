---
description: "Learn more about: IReferenceAppId Interface"
title: "IReferenceAppId Interface"
ms.date: "03/30/2017"
api_name: 
  - "IReferenceAppId"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IReferenceAppId"
helpviewer_keywords: 
  - "IReferenceAppId interface [.NET Framework fusion]"
ms.assetid: 8eb9e565-f358-43ce-900e-a8f8a5aa6cfb
topic_type: 
  - "apiref"
---
# IReferenceAppId Interface

Represents a reference to the unique identifier for the application in the current scope.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IReferenceAppId::get_CodeBase`|Gets a pointer to a string representation of the code identifier for the application referenced by this `IReferenceAppId`.|  
|`IReferenceAppId::put_CodeBase`|Sets the code identifier for the application referenced by this `IReferenceAppId`.|  
|`IReferenceAppId::EnumAppPath`|Gets an interface pointer to an `IEnumReferenceIdentity` instance containing the `IReferenceIdentity` instances that represent members of this `IReferenceAppId`.|  
|`IReferenceAppId::get_SubscriptionId`|Gets a pointer to a string representation of the token identifier for a subscription to this `IReferenceAppId`.|  
|`IReferenceAppId::put_SubscriptionId`|Sets the token identifier for a subscription to this `IReferenceAppId` to the specified string value.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
- [IEnumReferenceIdentity Interface](ienumreferenceidentity-interface.md)
- [IReferenceIdentity Interface](ireferenceidentity-interface.md)
