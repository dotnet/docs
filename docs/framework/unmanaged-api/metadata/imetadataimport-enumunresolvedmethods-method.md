---
title: "IMetaDataImport::EnumUnresolvedMethods Method"
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
  - "IMetaDataImport.EnumUnresolvedMethods"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumUnresolvedMethods"
helpviewer_keywords: 
  - "EnumUnresolvedMethods method [.NET Framework metadata]"
  - "IMetaDataImport::EnumUnresolvedMethods method [.NET Framework metadata]"
ms.assetid: eb3187d7-74cf-44b1-aeeb-7a8d2b60e3b7
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::EnumUnresolvedMethods Method
Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.  
  
## Syntax  
  
```  
HRESULT EnumUnresolvedMethods (  
   [in, out] HCORENUM    *phEnum,  
   [out]     mdToken     rMethods[],  
   [in]      ULONG       cMax,  
   [out]     ULONG       *pcTokens  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `rMethods`  
 [out] The array used to store the MemberDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rMethods` array.  
  
 `pcTokens`  
 [out] The number of MemberDef tokens returned in `rMethods`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumUnresolvedMethods` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Remarks  
 An unresolved method is one that has been declared but not implemented. A method is included in the enumeration if the method is marked `miForwardRef` and either `mdPinvokeImpl` or `miRuntime` is set to zero. In other words, an unresolved method is a class method that is marked `miForwardRef` but which is not implemented in unmanaged code (reached via PInvoke) nor implemented internally by the runtime itself  
  
 The enumeration excludes all methods that are defined either at module scope (globals) or in interfaces or abstract classes.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
