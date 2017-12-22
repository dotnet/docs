---
title: "IMetaDataDispenser Interface"
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
  - "IMetaDataDispenser"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenser"
helpviewer_keywords: 
  - "IMetaDataDispenser interface [.NET Framework metadata]"
ms.assetid: 989840b3-9822-4ce5-a6c5-b375d3340a7a
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataDispenser Interface
Provides methods to create a new metadata scope, or open an existing one.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DefineScope Method](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-definescope-method.md)|Creates a new area in memory where you can create new metadata.|  
|[OpenScope Method](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-openscope-method.md)|Opens an existing, on-disk file and maps its metadata into memory.|  
|[OpenScopeOnMemory Method](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-openscopeonmemory-method.md)|Opens an area of memory that contains existing metadata. That is, this method opens a specified area of memory in which the existing data is treated as metadata.|  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataDispenserEx Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenserex-interface.md)  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)
