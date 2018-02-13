---
title: "USER_THREAD Structure"
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
  - "USER_THREAD"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "USER_THREAD"
helpviewer_keywords: 
  - "USER_THREAD structure [.NET Framework debugging]"
ms.assetid: a57c7d71-c4b0-41f9-a964-0c5ee84a3124
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# USER_THREAD Structure
Provides information to a debugger about a thread. For more information, see the [INotifySource2::SetNotifyFilter](../../../../docs/framework/unmanaged-api/diagnostics/inotifysource2-setnotifyfilter-method.md) method.  
  
## Syntax  
  
```  
typedef struct tagUSER_THREAD  
{  
    BYTE    *pSidBuffer;  
    DWORD   dwSidLen;  
    DWORD   dwTid;  
} USER_THREAD;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pSidBuffer`|Address of thread buffer.|  
|`dwSidLen`|Length of thread buffer, in bytes.|  
|`dwTid`|Thread ID.|  
  
## Requirements  
 **Header:** ProtocolNotify2.idl  
  
## See Also  
 [SetNotifyFilter Method](../../../../docs/framework/unmanaged-api/diagnostics/inotifysource2-setnotifyfilter-method.md)  
 [Diagnostics Symbol Store Structures](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-structures.md)
