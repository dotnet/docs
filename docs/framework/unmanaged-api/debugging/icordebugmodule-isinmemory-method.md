---
description: "Learn more about: ICorDebugModule::IsInMemory Method"
title: "ICorDebugModule::IsInMemory Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule.IsInMemory"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::IsInMemory"
helpviewer_keywords: 
  - "IsInMemory method [.NET Framework debugging]"
  - "ICorDebugModule::IsInMemory method [.NET Framework debugging]"
ms.assetid: 89940711-98e7-4aa6-bffc-5e39e91e1b7d
topic_type: 
  - "apiref"
---
# ICorDebugModule::IsInMemory Method

Gets a value that indicates whether this module exists only in memory.  
  
## Syntax  
  
```cpp  
HRESULT IsInMemory(  
    [out] BOOL *pInMemory  
);  
```  
  
## Parameters  

 `pInMemory`  
 [out] `true` if this module exists only in memory; otherwise, `false`.  
  
## Remarks  

 The common language runtime (CLR) supports the loading of modules from raw streams of bytes. Such modules are called *in-memory modules* and do not exist on disk.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
