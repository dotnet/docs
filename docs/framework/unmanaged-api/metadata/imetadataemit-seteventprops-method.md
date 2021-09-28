---
description: "Learn more about: IMetaDataEmit::SetEventProps Method"
title: "IMetaDataEmit::SetEventProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetEventProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetEventProps"
helpviewer_keywords: 
  - "IMetaDataEmit::SetEventProps method [.NET Framework metadata]"
  - "SetEventProps method [.NET Framework metadata]"
ms.assetid: 3b039e50-63ec-4730-99ff-2327408de477
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SetEventProps Method

Sets or updates the specified feature of an event defined by a prior call to [IMetaDataEmit::DefineEvent](imetadataemit-defineevent-method.md).  
  
## Syntax  
  
```cpp  
HRESULT SetEventProps (  
    [in]  mdEvent     ev,
    [in]  DWORD       dwEventFlags,
    [in]  mdToken     tkEventType,
    [in]  mdMethodDef mdAddOn,
    [in]  mdMethodDef mdRemoveOn,
    [in]  mdMethodDef mdFire,
    [in]  mdMethodDef rmdOtherMethods[]
);  
```  
  
## Parameters  

 `ev`  
 [in] The event token.  
  
 `dwEventFlags`  
 [in] Event flags. This is a bitmask of `CorEventAttr` values.  
  
 `tkEventType`  
 [in] The token for the event class. This is either a `mdTypeDef` or a `mdTypeRef` token.  
  
 `mdAddOn`  
 [in] The method used to subscribe to the event, or null.  
  
 `mdRemoveOn`  
 [in] The method used to unsubscribe to the event, or null.  
  
 `mdFire`  
 [in] The method used (by a derived class) to raise the event.  
  
 `rmdOtherMethods[]`  
 [in] An array of tokens for other methods associated with the event. The last element of the array must be `mdMethodDefNil`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
