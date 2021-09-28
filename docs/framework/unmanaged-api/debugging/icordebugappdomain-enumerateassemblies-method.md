---
description: "Learn more about: ICorDebugAppDomain::EnumerateAssemblies Method"
title: "ICorDebugAppDomain::EnumerateAssemblies Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain.EnumerateAssemblies"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::EnumerateAssemblies"
helpviewer_keywords: 
  - "ICorDebugAppDomain::EnumerateAssemblies method [.NET Framework debugging]"
  - "EnumerateAssemblies method [.NET Framework debugging]"
ms.assetid: 7add64f9-19a8-46a9-be62-905d5e7d1bd8
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain::EnumerateAssemblies Method

Gets an enumerator for the assemblies in the application domain.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateAssemblies (  
    [out] ICorDebugAssemblyEnum  **ppAssemblies  
);  
```  
  
## Parameters  

 `ppAssemblies`  
 [out] A pointer to the address of an ICorDebugAssemblyEnum object that is the enumerator for the assemblies in the application domain.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
