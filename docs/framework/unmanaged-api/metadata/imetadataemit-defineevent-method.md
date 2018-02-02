---
title: "IMetaDataEmit::DefineEvent Method"
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
  - "IMetaDataEmit.DefineEvent"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineEvent"
helpviewer_keywords: 
  - "IMetaDataEmit::DefineEvent method [.NET Framework metadata]"
  - "DefineEvent method [.NET Framework metadata]"
ms.assetid: cf064bac-9a9f-41c5-9e1d-108ff7af3afe
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineEvent Method
Creates a definition for an event with the specified metadata signature, and gets a token to that event definition.  
  
## Syntax  
  
```  
HRESULT DefineEvent (   
    [in]  mdTypeDef    td,   
    [in]  LPCWSTR      szEvent,   
    [in]  DWORD        dwEventFlags,   
    [in]  mdToken      tkEventType,   
    [in]  mdMethodDef  mdAddOn,   
    [in]  mdMethodDef  mdRemoveOn,   
    [in]  mdMethodDef  mdFire,   
    [in]  mdMethodDef  rmdOtherMethods[],   
    [out] mdEvent      *pmdEvent   
);  
```  
  
#### Parameters  
 `td`  
 [in] The token for the target class or interface. This is either a `mdTypeDef` or `mdTypeDefNil` token.  
  
 `szEvent`  
 [in] The name of the event.  
  
 `dwEventFlags`  
 [in] Event flags.  
  
 `tkEventType`  
 [in] The token for the event class. This is a `mdTypeDef`, a `mdTypeRef`, or a `mdTokenNil` token.  
  
 `mdAddOn`  
 [in] The method used to subscribe to the event, or null.  
  
 `mdRemoveOn`  
 [in] The method used to unsubscribe to the event, or null.  
  
 `mdFire`  
 [in] The method used (by a derived class) to raise the event.  
  
 `rmdOtherMethods[]`  
 [in] An array of tokens for other methods associated with the event. The array is terminated with a `mdMethodDefNil` token.  
  
 `pmdEvent`  
 [out] The metadata token assigned to the event.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
