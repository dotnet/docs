---
title: "ICorDebugType::GetRank Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugType.GetRank"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugType::GetRank"
helpviewer_keywords: 
  - "GetRank method, ICorDebugType interface [.NET Framework debugging]"
  - "ICorDebugType::GetRank method [.NET Framework debugging]"
ms.assetid: 72d3d927-f590-4f2d-8f60-448f3dfb96af
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugType::GetRank Method
Gets the number of dimensions in an array type.  
  
## Syntax  
  
```cpp  
HRESULT GetRank (  
    [out] ULONG32   *pnRank  
);  
```  
  
## Parameters  
 `pnRank`  
 [out] A pointer to the number of dimensions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
