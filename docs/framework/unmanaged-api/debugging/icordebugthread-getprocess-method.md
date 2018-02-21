---
title: "ICorDebugThread::GetProcess Method"
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
  - "ICorDebugThread.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetProcess"
helpviewer_keywords: 
  - "ICorDebugThread::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 163816e7-0739-4566-b3df-cd256be8b8a4
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::GetProcess Method
Gets an interface pointer to the process of which this ICorDebugThread forms a part.  
  
## Syntax  
  
```  
HRESULT GetProcess (  
    [out] ICorDebugProcess   **ppProcess  
);  
```  
  
#### Parameters  
 `ppProcess`  
 [out] A pointer to the address of an ICorDebugProcess interface object that represents the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
