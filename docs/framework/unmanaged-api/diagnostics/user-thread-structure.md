---
description: "Learn more about: USER_THREAD Structure"
title: "USER_THREAD Structure"
ms.date: "03/30/2017"
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
---
# USER_THREAD Structure

Provides information to a debugger about a thread. For more information, see the [INotifySource2::SetNotifyFilter](inotifysource2-setnotifyfilter-method.md) method.  
  
## Syntax  
  
```cpp  
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
  
## See also

- [SetNotifyFilter Method](inotifysource2-setnotifyfilter-method.md)
- [Diagnostics Symbol Store Structures](diagnostics-symbol-store-structures.md)
