---
title: "IGCThreadControl::SuspensionStarting Method"
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
  - "IGCThreadControl.SuspensionStarting"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SuspensionStarting"
helpviewer_keywords: 
  - "IGCThreadControl::SuspensionStarting method [.NET Framework hosting]"
  - "SuspensionStarting method, IGCThreadControl interface [.NET Framework hosting]"
ms.assetid: 0af312af-98e9-415e-b182-42e80a1aee51
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IGCThreadControl::SuspensionStarting Method
Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.  
  
## Syntax  
  
```  
HRESULT SuspensionStarting ( );  
```  
  
## Remarks  
 Do not reschedule any threads during the `SuspensionStarting` callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IGCThreadControl Interface](../../../../docs/framework/unmanaged-api/hosting/igcthreadcontrol-interface.md)
