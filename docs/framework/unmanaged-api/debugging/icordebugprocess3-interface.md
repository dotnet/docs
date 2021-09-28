---
description: "Learn more about: ICorDebugProcess3 Interface"
title: "ICorDebugProcess3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess3"
helpviewer_keywords: 
  - "ICorDebugProcess3 interface [.NET Framework debugging]"
ms.assetid: ced9c82e-d7b0-4806-a151-98b6611d3097
topic_type: 
  - "apiref"
---
# ICorDebugProcess3 Interface

Controls custom debugger notifications.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetEnableCustomNotification Method](icordebugprocess3-setenablecustomnotification-method.md)|Enables and disables custom debugger notifications of the specified type.|  
  
## Remarks  

 This interface logically extends the ICorDebugProcess and ICorDebugProcess2 interfaces.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
