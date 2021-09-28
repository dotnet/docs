---
description: "Learn more about: IEnumReferenceIdentity Interface"
title: "IEnumReferenceIdentity Interface"
ms.date: "03/30/2017"
api_name: 
  - "IEnumReferenceIdentity"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IEnumReferenceIdentity"
helpviewer_keywords: 
  - "IEnumReferenceIdentity interface [.NET Framework fusion]"
ms.assetid: a17b3155-7216-4e16-8c9f-abce21f549e7
topic_type: 
  - "apiref"
---
# IEnumReferenceIdentity Interface

Serves as an enumerator for a collection of `IReferenceIdentity` objects.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IEnumReferenceIdentity::Clone`|Gets an interface pointer to a new `IEnumReferenceIdentity` that contains the same members as this `IEnumReferenceIdentity`.|  
|`IEnumReferenceIdentity::Next`|Gets the specified number of `IReferenceIdentity` objects, starting at the current position.|  
|`IEnumReferenceIdentity::Reset`|Moves the instruction pointer to the beginning of this `IEnumReferenceIdentity`.|  
|`IEnumReferenceIdentity::Skip`|Moves the instruction pointer forward by the specified number of elements, starting at the current position.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
- [IReferenceIdentity Interface](ireferenceidentity-interface.md)
