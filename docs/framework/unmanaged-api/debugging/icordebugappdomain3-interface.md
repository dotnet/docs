---
description: "Learn more about: ICorDebugAppDomain3 Interface"
title: "ICorDebugAppDomain3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain3"
helpviewer_keywords: 
  - "ICorDebugAppDomain3 interface [.NET Framework debugging]"
ms.assetid: 875ef5be-c1e7-4d95-97e9-d3a667aeaba0
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain3 Interface

Provides methods to retrieve information about the managed representations of Windows Runtime types currently loaded in an application domain. This interface is an extension of the ICorDebugAppDomain and ICorDebugAppDomain2 interfaces.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ICorDebugAppDomain3::GetCachedWinRTTypes](icordebugappdomain3-getcachedwinrttypes-method.md)|Gets an enumerator for all cached Windows Runtime types.|  
|[ICorDebugAppDomain3::GetCachedWinRTTypesForIIDs](icordebugappdomain3-getcachedwinrttypesforiids-method.md)|Gets an enumerator for cached Windows Runtime types in an application domain based on their interface identifiers.|  
  
## Remarks  

 This interface is meant to be used by a debugger in conjunction with a function evaluation call to `M:System.Runtime.InteropServices.Marshal.GetInspectableIIDs(System.Object)`. When the method retrieves the interface identifiers supported by a Windows Runtime server object, the debugger may use the methods defined in this interface to map them to managed types that correspond to those interfaces.  
  
 To retrieve an instance of this interface, run `QueryInterface` on an instance of the ICorDebugAppDomain or ICorDebugAppDomain2 interface.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** Windows Runtime  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
