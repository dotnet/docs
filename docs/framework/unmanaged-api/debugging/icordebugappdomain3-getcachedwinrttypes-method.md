---
title: "ICorDebugAppDomain3::GetCachedWinRTTypes Method"
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
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAppDomain3::GetCachedWinRTTypes Method
Gets an enumerator for all cached [!INCLUDE[wrt](../../../../includes/wrt-md.md)] types.  
  
## Syntax  
  
```  
HRESULT GetCachedWinRTTypes (   
    [out] ICorDebugGuidToTypeEnum **ppGuidToTypeEnum)  
;  
```  
  
#### Parameters  
 `ppGuidToTypeEnum`  
 [out] A pointer to an [ICorDebugGuidToTypeEnum](../../../../docs/framework/unmanaged-api/debugging/icordebugguidtotypeenum-interface.md) interface object that can enumerate the managed representations of [!INCLUDE[wrt](../../../../includes/wrt-md.md)] types currently loaded in the application domain.  
  
## Requirements  
 **Platforms:** [!INCLUDE[wrt](../../../../includes/wrt-md.md)]  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorDebugAppDomain3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomain3-interface.md)
