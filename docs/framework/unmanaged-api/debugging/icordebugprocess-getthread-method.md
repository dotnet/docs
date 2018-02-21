---
title: "ICorDebugProcess::GetThread Method"
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
  - "ICorDebugProcess.GetThread"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::GetThread"
helpviewer_keywords: 
  - "ICorDebugProcess::GetThread method [.NET Framework debugging]"
  - "GetThread method, ICorDebugProcess interface [.NET Framework debugging]"
ms.assetid: a48261ed-700b-41c9-8cb4-18c526546603
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::GetThread Method
Gets this process's thread that has the specified operating system (OS) thread ID.  
  
## Syntax  
  
```  
HRESULT GetThread(  
    [in] DWORD dwThreadId,  
    [out] ICorDebugThread **ppThread);  
```  
  
#### Parameters  
 `dwThreadId`  
 [in] The OS thread ID of the thread to be retrieved.  
  
 `ppThread`  
 [out] A pointer to the address of an ICorDebugThread object that represents the thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
