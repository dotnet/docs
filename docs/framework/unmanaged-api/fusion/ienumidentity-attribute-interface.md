---
description: "Learn more about: IEnumIDENTITY_ATTRIBUTE Interface"
title: "IEnumIDENTITY_ATTRIBUTE Interface"
ms.date: "03/30/2017"
api_name: 
  - "IEnumIDENTITY_ATTRIBUTE"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IEnumIDENTITY_ATTRIBUTE"
helpviewer_keywords: 
  - "IEnumIDENTITY_ATTRIBUTE interface [.NET Framework fusion]"
ms.assetid: c2ec2748-e9ae-4e1b-80db-6fcec5cb81a1
topic_type: 
  - "apiref"
---
# IEnumIDENTITY_ATTRIBUTE Interface

Serves as an enumerator for the attributes of the code object in the current scope.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|`IEnumIDENTITY_ATTRIBUTE::Clone`|Gets an interface pointer to a new `IEnumIDENTITY_ATTRIBUTE` that contains the same members as this `IEnumIDENTITY_ATTRIBUTE`.|  
|`IEnumIDENTITY_ATTRIBUTE::CurrentIntoBuffer`|Writes the data contained in the elements of this `IEnumIDENTITY_ATTRIBUTE` to the specified data buffer.|  
|`IEnumIDENTITY_ATTRIBUTE::Next`|Gets the specified number of attributes, starting at the current position.|  
|`IEnumIDENTITY_ATTRIBUTE::Reset`|Moves the instruction pointer to the beginning of this `IEnumIDENTITY_ATTRIBUTE`.|  
|`IEnumIDENTITY_ATTRIBUTE::Skip`|Moves the instruction pointer forward by the specified number of elements, starting at the current position.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Interfaces](fusion-interfaces.md)
