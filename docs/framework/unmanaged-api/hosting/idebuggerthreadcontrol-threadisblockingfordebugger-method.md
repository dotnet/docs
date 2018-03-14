---
title: "IDebuggerThreadControl::ThreadIsBlockingForDebugger Method"
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
  - "IDebuggerThreadControl.ThreadIsBlockingForDebugger"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ThreadIsBlockingForDebugger"
helpviewer_keywords: 
  - "ThreadIsBlockingForDebugger method [.NET Framework hosting]"
  - "IDebuggerThreadControl::ThreadIsBlockingForDebugger method [.NET Framework hosting]"
ms.assetid: d4d7cb2d-69da-48b3-879a-1a8a68c9bfa8
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IDebuggerThreadControl::ThreadIsBlockingForDebugger Method
Notifies the host that the thread that is sending this callback is about to block within the debugging services.  
  
## Syntax  
  
```  
HRESULT ThreadIsBlockingForDebugger ( );  
```  
  
## Remarks  
 The `ThreadIsBlockingForDebugger` method will always be called on a runtime thread.  
  
 The `ThreadIsBlockingForDebugger` method gives the host an opportunity to perform another action while the thread blocks.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IDebuggerThreadControl Interface](../../../../docs/framework/unmanaged-api/hosting/idebuggerthreadcontrol-interface.md)
