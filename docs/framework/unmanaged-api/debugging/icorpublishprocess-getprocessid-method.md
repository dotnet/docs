---
title: "ICorPublishProcess::GetProcessID Method"
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
  - "ICorPublishProcess.GetProcessID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcess::GetProcessID"
helpviewer_keywords: 
  - "ICorPublishProcess::GetProcessID method [.NET Framework debugging]"
  - "GetProcessID method [.NET Framework debugging]"
ms.assetid: f31185e0-f01d-463a-b392-42163e39bfe9
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorPublishProcess::GetProcessID Method
Gets the operating system identifier for this process.  
  
## Syntax  
  
```  
HRESULT GetProcessID (  
    [out] unsigned   *pid  
);  
```  
  
#### Parameters  
 `pid`  
 [out] A pointer to the identifier of the process represented by this [ICorPublishProcess](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md) object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorPublishProcess Interface](../../../../docs/framework/unmanaged-api/debugging/icorpublishprocess-interface.md)
