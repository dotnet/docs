---
title: "IMetaDataFilter Interface"
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
  - "IMetaDataFilter"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataFilter"
helpviewer_keywords: 
  - "IMetaDataFilter interface [.NET Framework metadata]"
ms.assetid: ec0856ef-8c56-40ba-bf60-86e0ce8b337f
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataFilter Interface
Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[IsTokenMarked Method](../../../../docs/framework/unmanaged-api/metadata/imetadatafilter-istokenmarked-method.md)|Gets a value indicating whether the specified metadata token has been processed.|  
|[MarkToken Method](../../../../docs/framework/unmanaged-api/metadata/imetadatafilter-marktoken-method.md)|Sets a value indicating that the specified metadata token has been processed.|  
|[UnmarkAll Method](../../../../docs/framework/unmanaged-api/metadata/imetadatafilter-unmarkall-method.md)|Removes the processing marks from all the tokens in the current metadata scope.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)
