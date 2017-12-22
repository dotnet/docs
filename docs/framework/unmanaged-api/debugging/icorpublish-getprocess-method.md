---
title: "ICorPublish::GetProcess Method"
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
  - "ICorPublish.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublish::GetProcess"
helpviewer_keywords: 
  - "ICorPublish::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorPublish interface [.NET Framework debugging]"
ms.assetid: c5143805-2eb7-45b8-85ed-c8fb34df1084
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorPublish::GetProcess Method
Gets an [ICorPublishProcess](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md) instance that represents the process with the specified identifier.  
  
## Syntax  
  
```  
HRESULT GetProcess(  
    [in] unsigned              pid,   
    [out] ICorPublishProcess   **ppProcess  
);  
```  
  
#### Parameters  
 `pid`  
 [in] The identifier of the process.  
  
 `ppProcess`  
 [out] A pointer to the address of an `ICorPublishProcess` instance that represents the process.  
  
## Remarks  
 `GetProcess` fails if the process doesn't exist, or isn't a managed process that can be debugged by the current user.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorPublish Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublish-interface.md)
