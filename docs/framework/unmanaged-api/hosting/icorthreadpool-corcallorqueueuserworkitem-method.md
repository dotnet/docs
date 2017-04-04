---
title: "ICorThreadpool::CorCallOrQueueUserWorkItem Method | Microsoft Docs"
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
  - "ICorThreadpool.CorCallOrQueueUserWorkItem"
apilocation: 
  - "mscoree.dll"
apitype: "COM"
f1_keywords: 
  - "CorCallOrQueueUserWorkItem"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorThreadpool::CorCallOrQueueUserWorkItem method [.NET Framework hosting]"
  - "CorCallOrQueueUserWorkItem method [.NET Framework hosting]"
ms.assetid: a2081223-84ca-4331-a8d3-9352f422f3e7
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorThreadpool::CorCallOrQueueUserWorkItem Method
This method supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CorCallOrQueueUserWorkItem (  
    [in] LPTHREAD_START_ROUTINE Function,  
    [in] PVOID                  Context,  
    [out] BOOL*                 result  
);  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorThreadpool Interface](../../../../docs/framework/unmanaged-api/hosting/icorthreadpool-interface.md)