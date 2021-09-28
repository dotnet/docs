---
description: "Learn more about: ICorDebugAppDomainEnum Interface"
title: "ICorDebugAppDomainEnum Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomainEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomainEnum"
helpviewer_keywords: 
  - "ICorDebugAppDomainEnum interface [.NET Framework debugging]"
ms.assetid: e9226e6e-ca2c-428e-bb38-0c099210f507
topic_type: 
  - "apiref"
---
# ICorDebugAppDomainEnum Interface

Provides the `Next` method, which returns a specified number of `ICorDebugAppDomainEnum` values starting at the next location in the enumeration. This interface is a subclass of "ICorDebugEnum".  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](icordebugappdomainenum-next-method.md)|Gets the specified number of application domains from the collection, starting at the current cursor position.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebug Interface](icordebug-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
