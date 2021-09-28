---
description: "Learn more about: CorDebugMDAFlags Enumeration"
title: "CorDebugMDAFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugMDAFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugMDAFlags"
helpviewer_keywords: 
  - "CorDebugMDAFlags enumeration [.NET Framework debugging]"
ms.assetid: 7c0c92fe-8bd2-477f-b307-aca0143732ca
topic_type: 
  - "apiref"
---
# CorDebugMDAFlags Enumeration

Specifies the status of the thread on which the managed debugging assistant (MDA) is fired.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugMDAFlags {  
    MDA_FLAG_SLIP = 0x2  
} CorDebugMDAFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDA_FLAG_SLIP`|The thread on which the MDA was fired has slipped since the MDA was fired.|  
  
## Remarks  

 When the call stack no longer describes where the MDA was originally raised, the thread is considered to have *slipped*. This is an unusual circumstance brought about by the thread's execution of an invalid operation upon exiting.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
