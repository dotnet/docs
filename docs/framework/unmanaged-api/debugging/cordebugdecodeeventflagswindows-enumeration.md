---
description: "Learn more about: CorDebugDecodeEventFlagsWindows Enumeration"
title: "CorDebugDecodeEventFlagsWindows Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugDecodeEventFlagsWindows"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: aa6cf962-30ae-4cfd-8895-826deeb46a54
topic_type: 
  - "apiref"
---
# CorDebugDecodeEventFlagsWindows Enumeration

Provides additional information about debug events on the Windows platform.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugDecodeEventFlagsWindows {  
    IS_FIRST_CHANCE = 1,  
} CorDebugDecodeEventFlagsWindows;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`IS_FIRST_CHANCE`|Indicates that the debug event is a first-chance exception.|  
  
## Remarks  

 The [ICorDebugProcess6::DecodeEvent](icordebugprocess6-decodeevent-method.md) method includes a `dwFlags` parameter that provides additional information about a debug event and whose value is dependent on the target architecture. The `CorDebugDecodeEventFlagsWindows` enumeration can be used with debug events on the Windows platform.  
  
> [!NOTE]
> This enumeration is intended for use in .NET Native debugging scenarios only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
