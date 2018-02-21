---
title: "IDebuggerThreadControl::StartBlockingForDebugger Method"
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
  - "IDebuggerThreadControl.StartBlockingForDebugger"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "StartBlockingForDebugger"
helpviewer_keywords: 
  - "IDebuggerThreadControl::StartBlockingForDebugger method [.NET Framework hosting]"
  - "StartBlockingForDebugger method [.NET Framework hosting]"
ms.assetid: 5c8f11b4-35d3-4c39-9bbd-58b896ba5ba6
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IDebuggerThreadControl::StartBlockingForDebugger Method
Notifies the host that the debugging services are about to start blocking all threads.  
  
## Syntax  
  
```  
HRESULT StartBlockingForDebugger (  
    [in] DWORD dwUnused  
);  
```  
  
#### Parameters  
 `dwUnused`  
 [in] Reserved for future use.  
  
## Remarks  
 The `StartBlockingForDebugger` method could be called on a runtime thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IDebuggerThreadControl Interface](../../../../docs/framework/unmanaged-api/hosting/idebuggerthreadcontrol-interface.md)
