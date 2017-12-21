---
title: "ICorDebugThread2::GetVolatileOSThreadID Method"
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
  - "ICorDebugThread2.GetVolatileOSThreadID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread2::GetVolatileOSThreadID"
helpviewer_keywords: 
  - "GetVolatileOSThreadID method [.NET Framework debugging]"
  - "ICorDebugThread2::GetVolatileOSThreadID method [.NET Framework debugging]"
ms.assetid: f0922545-c2cf-40c8-9ef6-ca033563e682
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread2::GetVolatileOSThreadID Method
Gets the operating system thread identifier for this ICorDebugThread2.  
  
## Syntax  
  
```  
HRESULT GetVolatileOSThreadID (  
    [out] DWORD    *pdwTid  
);  
```  
  
#### Parameters  
 `pdwTid`  
 [out] The operating system thread identifier for this thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
