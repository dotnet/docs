---
title: "ICorDebugEnum::Clone Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEnum.Clone"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEnum::Clone"
helpviewer_keywords: 
  - "Clone method, ICorDebugEnum interface [.NET Framework debugging]"
  - "ICorDebugEnum::Clone method [.NET Framework debugging]"
ms.assetid: 57eefaf3-75cf-4496-bc94-88c0706861b7
topic_type: 
  - "apiref"
---
# ICorDebugEnum::Clone Method
Creates a copy of this ICorDebugEnum object.  
  
## Syntax  
  
```cpp  
HRESULT Clone (  
    [out] ICorDebugEnum **ppEnum  
);  
```  
  
## Parameters  
 `ppEnum`  
 [out] A pointer to the address of an `ICorDebugEnum` object that is a copy of this `ICorDebugEnum` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
