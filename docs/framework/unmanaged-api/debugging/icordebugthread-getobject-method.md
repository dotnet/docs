---
title: "ICorDebugThread::GetObject Method"
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
  - "ICorDebugThread.GetObject"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetObject"
helpviewer_keywords: 
  - "GetObject method, ICorDebugThread interface [.NET Framework debugging]"
  - "ICorDebugThread::GetObject method [.NET Framework debugging]"
ms.assetid: 1590febe-96c2-4046-97db-d81d81d67e01
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::GetObject Method
Gets an interface pointer to the common language runtime (CLR) thread.  
  
## Syntax  
  
```  
HRESULT GetObject (  
    [out] ICorDebugValue   **ppObject  
);  
```  
  
#### Parameters  
 `ppObject`  
 [out] A pointer to the address of an ICorDebugValue interface object that represents the CLR thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 <xref:System.Threading.Thread>
