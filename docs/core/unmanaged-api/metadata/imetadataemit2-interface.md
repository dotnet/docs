---
description: "Learn more about: IMetaDataEmit2 Interface"
title: "IMetaDataEmit2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit2"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit2"
helpviewer_keywords: 
  - "IMetaDataEmit2 interface [.NET Framework metadata]"
ms.assetid: 866dc96b-bbfc-4c0f-80c2-38ce93072106
topic_type: 
  - "apiref"
---
# IMetaDataEmit2 Interface

Extends the [IMetaDataEmit](imetadataemit-interface.md) interface primarily to provide the ability to work with generic types.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DefineGenericParam Method](imetadataemit2-definegenericparam-method.md)|Creates a definition for a generic type parameter, and gets a token to that generic type parameter.|  
|[DefineMethodSpec Method](imetadataemit2-definemethodspec-method.md)|Creates a generic instance of a method, and gets a token to the definition.|  
|[GetDeltaSaveSize Method](imetadataemit2-getdeltasavesize-method.md)|Gets a value indicating the difference in size of the data that is required to express the changes for the current edit-and-continue session.|  
|[ResetENCLog Method](imetadataemit2-resetenclog-method.md)|Resets the edit-and-continue log and starts a new session.|  
|[SaveDelta Method](imetadataemit2-savedelta-method.md)|Saves changes from the current edit-and-continue session to the specified file.|  
|[SaveDeltaToMemory Method](imetadataemit2-savedeltatomemory-method.md)|Saves changes from the current edit-and-continue session to memory.|  
|[SaveDeltaToStream Method](imetadataemit2-savedeltatostream-method.md)|Saves changes from the current edit-and-continue session to the specified stream.|  
|[SetGenericParamProps Method](imetadataemit2-setgenericparamprops-method.md)|Sets property values for the generic parameter definition referenced by the specified token.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Metadata Interfaces](metadata-interfaces.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
