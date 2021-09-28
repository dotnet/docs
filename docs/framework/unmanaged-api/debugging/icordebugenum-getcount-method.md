---
description: "Learn more about: ICorDebugEnum::GetCount Method"
title: "ICorDebugEnum::GetCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEnum.GetCount"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEnum::GetCount"
helpviewer_keywords: 
  - "ICorDebugEnum::GetCount method [.NET Framework debugging]"
  - "GetCount method, ICorDebugEnum interface [.NET Framework debugging]"
ms.assetid: d8a74304-1cb2-4977-a21d-e1af48c563ff
topic_type: 
  - "apiref"
---
# ICorDebugEnum::GetCount Method

Gets the number of items in the enumeration.  
  
## Syntax  
  
```cpp  
HRESULT GetCount (  
    [out] ULONG *pcelt  
);  
```  
  
## Parameters  

 `pcelt`  
 [out] A pointer to the number of items in the enumeration.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
