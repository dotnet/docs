---
title: "ICLRMetadataLocator Interface"
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
  - "ICLRMetadataLocator"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetadataLocator"
helpviewer_keywords: 
  - "ICLRMetadataLocator interface [.NET Framework debugging]"
ms.assetid: 43c944f4-406a-4df6-981e-0eabb33dd5d0
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRMetadataLocator Interface
Used by the data access services layer to locate metadata of assemblies in a target process.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetMetadata Method](../../../../docs/framework/unmanaged-api/debugging/iclrmetadatalocator-getmetadata-method.md)|Retrieves the metadata of an image from the target process.|  
  
## Remarks  
 The API client (that is, the debugger) must implement this interface as appropriate for the particular target process. For example, the implementation for a live process would be different from that of a memory dump.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.** **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
