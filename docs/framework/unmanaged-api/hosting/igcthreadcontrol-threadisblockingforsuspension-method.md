---
title: "IGCThreadControl::ThreadIsBlockingForSuspension Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "IGCThreadControl.ThreadIsBlockingForSuspension"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "ThreadIsBlockingForSuspension"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "IGCThreadControl::ThreadIsBlockingForSuspension method [.NET Framework hosting]"
  - "ThreadIsBlockingForSuspension method [.NET Framework hosting]"
ms.assetid: ed5b5b58-7db7-46b5-9e2c-278db7159cee
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
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