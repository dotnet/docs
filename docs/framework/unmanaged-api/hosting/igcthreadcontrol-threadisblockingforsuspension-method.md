---
title: "IGCThreadControl::ThreadIsBlockingForSuspension Method"
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
  - "IGCThreadControl.ThreadIsBlockingForSuspension"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ThreadIsBlockingForSuspension"
helpviewer_keywords: 
  - "IGCThreadControl::ThreadIsBlockingForSuspension method [.NET Framework hosting]"
  - "ThreadIsBlockingForSuspension method [.NET Framework hosting]"
ms.assetid: ed5b5b58-7db7-46b5-9e2c-278db7159cee
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCThreadControl::ThreadIsBlockingForSuspension Method
Notifies the host that the thread that is making the call is about to block, perhaps for a garbage collection or other suspension.  
  
## Syntax  
  
```  
HRESULT ThreadIsBlockingForSuspension ( );  
```  
  
## Remarks  
 The host may choose within the `ThreadIsBlockingForSuspension` callback whether to reschedule a thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IGCThreadControl Interface](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-interface.md)
