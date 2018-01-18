---
title: "LoggingLevelEnum Enumeration"
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
  - "LoggingLevelEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "LoggingLevelEnum"
helpviewer_keywords: 
  - "LoggingLevelEnum enumeration [.NET Framework debugging]"
ms.assetid: 09daac08-005a-46b2-beab-408d0820c5e5
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LoggingLevelEnum Enumeration
Indicates the severity level of a descriptive message that is written to the event log when a managed thread logs an event.  
  
## Syntax  
  
```  
typedef enum LoggingLevelEnum {  
    LTraceLevel0 = 0,  
    LTraceLevel1,  
    LTraceLevel2,  
    LTraceLevel3,  
    LTraceLevel4,  
    LStatusLevel0 = 20,  
    LStatusLevel1,  
    LStatusLevel2,  
    LStatusLevel3,  
    LStatusLevel4,  
    LWarningLevel = 40,  
    LErrorLevel = 50,  
    LPanicLevel = 100  
} LoggingLevelEnum;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`LTraceLevel0`|The message is a trace level 0.|  
|`LTraceLevel1`|The message is a trace level 1.|  
|`LTraceLevel2`|The message is a trace level 2.|  
|`LTraceLevel3`|The message is a trace level 3.|  
|`LTraceLevel4`|The message is a trace level 4.|  
|`LStatusLevel0`|The message is a status level 0.|  
|`LStatusLevel1`|The message is a status level 1.|  
|`LStatusLevel2`|The message is a status level 2.|  
|`LStatusLevel3`|The message is a status level 3.|  
|`LStatusLevel4`|The message is a status level 4.|  
|`LWarningLevel`|The message is a warning level.|  
|`LErrorLevel`|The message is an error level.|  
|`LPanicLevel`|The message is a panic level.|  
  
## Remarks  
 The common language runtime (CLR) calls the [ICorDebugManagedCallback::LogMessage](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-logmessage-method.md) method to notify the debugger that a managed thread has logged an event. The CLR passes a value of the `LoggingLevelEnum` enumeration to indicate the severity level of the message that the managed thread wrote to the event log.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 <xref:System.Diagnostics.EventLog>  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
