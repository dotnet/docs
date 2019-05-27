---
title: "LogSwitchCallReason Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "LogSwitchCallReason"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "LogSwitchCallReason"
helpviewer_keywords: 
  - "LogSwitchCallReason enumeration [.NET Framework debugging]"
ms.assetid: 5bbb8d1b-bbc4-47b0-b1b1-2d54cc0be291
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# LogSwitchCallReason Enumeration
Indicates the operation that was performed on a debugging/tracing switch.  
  
## Syntax  
  
```  
typedef enum LogSwitchCallReason {  
    SWITCH_CREATE,  
    SWITCH_MODIFY,  
    SWITCH_DELETE  
} LogSwitchCallReason;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`SWITCH_CREATE`|A debugging/tracing switch was created.|  
|`SWITCH_MODIFY`|A debugging/tracing switch was modified.|  
|`SWITCH_DELETE`|A debugging/tracing switch was deleted.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
