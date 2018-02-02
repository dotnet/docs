---
title: "CoInitializeEE Function"
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
  - "CoInitializeEE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CoInitializeEE"
helpviewer_keywords: 
  - "CoInitializeEE function [.NET Framework hosting]"
ms.assetid: 7e42a928-5068-4ba6-b8c3-806551a01fa8
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CoInitializeEE Function
Ensures that the common language runtime execution engine is loaded into a process. This function is deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)]. Use the [ICLRRuntimeHost::Start](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-start-method.md) method instead.  
  
## Syntax  
  
```  
HRESULT CoInitializeEE (  
   [in] DWORD fFlags  
);  
```  
  
#### Parameters  
 `fFlags`  
 [in] One of the [COINITIEE](../../../../docs/framework/unmanaged-api/metadata/coinitiee-enumeration.md) enumeration constants.  
  
## Return Value  
 This method returns standard COM error codes as defined in Winerror.h, and the values in the following table.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The execution engine was loaded successfully.|  
|S_FALSE|The execution engine is already loaded.|  
|E_FAIL|The execution engine could not be loaded.|  
  
## Remarks  
 This method loads the execution engine if it has not been previously loaded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
