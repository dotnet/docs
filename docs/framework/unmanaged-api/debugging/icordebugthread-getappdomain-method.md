---
title: "ICorDebugThread::GetAppDomain Method"
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
  - "ICorDebugThread.GetAppDomain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetAppDomain"
helpviewer_keywords: 
  - "GetAppDomain method, ICorDebugThread interface [.NET Framework debugging]"
  - "ICorDebugThread::GetAppDomain method [.NET Framework debugging]"
ms.assetid: 415b3d34-8b35-4b60-a318-140646cc83f8
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::GetAppDomain Method
Gets an interface pointer to the application domain in which this ICorDebugThread is currently executing.  
  
## Syntax  
  
```  
HRESULT GetAppDomain (  
    [out] ICorDebugAppDomain  **ppAppDomain  
);  
```  
  
#### Parameters  
 `ppAppDomain`  
 [out] A pointer to an ICorDebugAppDomain object that represents the application domain in which this thread is currently executing.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
