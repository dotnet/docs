---
title: "IMetaDataImport::EnumMembersWithName Method"
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
  - "IMetaDataImport.EnumMembersWithName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumMembersWithName"
helpviewer_keywords: 
  - "IMetaDataImport::EnumMembersWithName method [.NET Framework metadata]"
  - "EnumMembersWithName method [.NET Framework metadata]"
ms.assetid: 7c9e9120-3104-42f0-86ce-19a025f20dcc
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::EnumMembersWithName Method
Enumerates MemberDef tokens representing members of the specified type with the specified name.  
  
## Syntax  
  
```  
HRESULT EnumMembersWithName (  
   [in, out] HCORENUM    *phEnum,   
   [in]      mdTypeDef   cl,   
   [in]      LPCWSTR     szName,   
   [out]     mdToken     rMembers[],   
   [in]      ULONG       cMax,   
   [out]     ULONG       *pcTokens  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the enumerator.  
  
 `cl`  
 [in] A TypeDef token representing the type with members to enumerate.  
  
 `szName`  
 [in] The member name that limits the scope of the enumerator.  
  
 `rMembers`  
 [out] The array used to store the MemberDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rMembers` array.  
  
 `pcTokens`  
 [out] The actual number of MemberDef tokens returned in `rMembers`.  
  
## Remarks  
 This method enumerates fields and methods, but not properties or events. Unlike [IMetaDataImport::EnumMembers](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-enummembers-method.md), `EnumMembersWithName` discards all field and member tokens that do not have the specified name.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumTypeDefs` returned successfully.|  
|`S_FALSE`|There are no MemberDef tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
