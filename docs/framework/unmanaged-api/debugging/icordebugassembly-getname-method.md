---
title: "ICorDebugAssembly::GetName Method"
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
  - "ICorDebugAssembly.GetName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly::GetName"
helpviewer_keywords: 
  - "ICorDebugAssembly::GetName method [.NET Framework debugging]"
  - "GetName method, ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: cdeda721-b214-4503-a291-c70b68b5f36b
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly::GetName Method
Gets the name of the assembly that this `ICorDebugAssembly` instance represents.  
  
## Syntax  
  
```  
HRESULT GetName (  
    [in] ULONG32  cchName,  
    [out] ULONG32 *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)] WCHAR szName[]  
);  
```  
  
#### Parameters  
 `cchName`  
 [in] The size of the `szName` array.  
  
 `pcchName`  
 [out] A pointer to an integer that specifies the actual length of the name.  
  
 `szName`  
 [out] An array that stores the name.  
  
## Remarks  
 The `GetName` method returns the full path and file name of the assembly.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
