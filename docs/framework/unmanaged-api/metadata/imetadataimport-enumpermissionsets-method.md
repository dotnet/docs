---
title: "IMetaDataImport::EnumPermissionSets Method"
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
  - "IMetaDataImport.EnumPermissionSets"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumPermissionSets"
helpviewer_keywords: 
  - "EnumPermissionSets method [.NET Framework metadata]"
  - "IMetaDataImport::EnumPermissionSets method [.NET Framework metadata]"
ms.assetid: 347d7e5c-c90f-45ad-bd1e-2c7912b0b19c
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::EnumPermissionSets Method
Enumerates permissions for the objects in a specified metadata scope.  
  
## Syntax  
  
```  
HRESULT EnumPermissionSets  
   [in, out] HCORENUM      *phEnum,   
   [in]      mdToken       tk,   
   [in]      DWORD         dwActions,  
   [out]     mdPermission  rPermission[],  
   [in]      ULONG         cMax,  
   [out]     ULONG         *pcTokens  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `tk`  
 [in] A metadata token that limits the scope of the search, or NULL to search the widest scope possible.  
  
 `dwActions`  
 [in] Flags representing the <xref:System.Security.Permissions.SecurityAction> values to include in `rPermission`, or zero to return all actions.  
  
 `rPermission`  
 [out] The array used to store the Permission tokens.  
  
 `cMax`  
 [in] The maximum size of the `rPermission` array.  
  
 `pcTokens`  
 [out] The number of Permission tokens returned in `rPermission`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumPermissionSets` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTokens` is zero.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
