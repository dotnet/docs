---
description: "Learn more about: IMetaDataEmit::SetParent Method"
title: "IMetaDataEmit::SetParent Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetParent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetParent"
helpviewer_keywords: 
  - "SetParent method [.NET Framework metadata]"
  - "IMetaDataEmit::SetParent method [.NET Framework metadata]"
ms.assetid: 02a02ff7-ae0e-4692-a20e-372405f23052
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SetParent Method

Establishes that the specified member, as defined by a prior call to [IMetaDataEmit::DefineMemberRef](imetadataemit-definememberref-method.md), is a member of the specified type, as defined by a prior call to [IMetaDataEmit::DefineTypeDef](imetadataemit-definetypedef-method.md).  
  
## Syntax  
  
```cpp  
HRESULT SetParent (
    [in]  mdMemberRef mr,
    [in]  mdToken     tk
);  
```  
  
## Parameters  

 `mr`  
 [in] The `mdMemberRef` token to receive a new parent.  
  
 `tk`  
 [in] The `mdToken` for the new parent.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
