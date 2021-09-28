---
description: "Learn more about: ICorDebugAppDomain::IsAttached Method"
title: "ICorDebugAppDomain::IsAttached Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain.IsAttached"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::IsAttached"
helpviewer_keywords: 
  - "IsAttached method [.NET Framework debugging]"
  - "ICorDebugAppDomain::IsAttached method [.NET Framework debugging]"
ms.assetid: af0c67c7-f53e-47c9-b84b-be50bd04903e
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain::IsAttached Method

Gets a value that indicates whether the debugger is attached to the application domain.  
  
## Syntax  
  
```cpp  
HRESULT IsAttached (  
    [out] BOOL  *pbAttached  
);  
```  
  
## Parameters  

 `pbAttached`  
 [out] `true` if the debugger is attached to the application domain; otherwise, `false`.  
  
## Remarks  

 The ICorDebugController methods cannot be used until the debugger attaches to the application domain.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
