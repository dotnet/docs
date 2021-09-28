---
description: "Learn more about: ICorDebugAppDomain3::GetCachedWinRTTypes Method"
title: "ICorDebugAppDomain3::GetCachedWinRTTypes Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain3.GetCachedWinRTTypes"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain3::GetCachedWinRTTypes"
helpviewer_keywords: 
  - "ICorDebugAppDomain3::GetCachedWinRTTypes method [.NET Framework debugging]"
  - "GetCachedWinRTTypes method, ICorDebugAppDomain3 interface [.NET Framework debugging]"
ms.assetid: 9afd0e04-a403-41e2-9528-a6dcbcdcbd4d
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain3::GetCachedWinRTTypes Method

Gets an enumerator for all cached Windows Runtime types.  
  
## Syntax  
  
```cpp  
HRESULT GetCachedWinRTTypes (
    [out] ICorDebugGuidToTypeEnum **ppGuidToTypeEnum)  
;  
```  
  
## Parameters  

 `ppGuidToTypeEnum`  
 [out] A pointer to an [ICorDebugGuidToTypeEnum](icordebugguidtotypeenum-interface.md) interface object that can enumerate the managed representations of Windows Runtime types currently loaded in the application domain.  
  
## Requirements  

 **Platforms:** Windows Runtime  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugAppDomain3 Interface](icordebugappdomain3-interface.md)
