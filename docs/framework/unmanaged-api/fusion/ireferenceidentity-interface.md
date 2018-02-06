---
title: "IReferenceIdentity Interface"
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
  - "IReferenceIdentity"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IReferenceIdentity"
helpviewer_keywords: 
  - "IReferenceIdentity interface [.NET Framework fusion]"
ms.assetid: 9180ac5a-7019-4716-9f83-8a91d157239a
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IReferenceIdentity Interface
Represents a reference to the unique signature of a code object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IReferenceIdentity::Clone`|Gets an interface pointer to a new `IReferenceIdentity` instance that is identical to this `IReferenceIdentity`, except for the specified attribute changes.|  
|`IReferenceIdentity::EnumAttributes`|Gets an interface pointer to an `IEnumIDENTITY_ATTRIBUTE` instance that contains the attributes associated with this `IReferenceIdentity`.|  
|`IReferenceIdentity::GetAttribute`|Gets the value of the attribute in the specified namespace, with the specified name.|  
|`IReferenceIdentity::SetAttribute`|Sets the attribute that has the specified namespace and the specified name to the specified value.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Interfaces](../../../../docs/framework/unmanaged-api/fusion/fusion-interfaces.md)  
 [IEnumIDENTITY_ATTRIBUTE Interface](../../../../docs/framework/unmanaged-api/fusion/ienumidentity-attribute-interface.md)
