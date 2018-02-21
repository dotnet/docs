---
title: "ICorDebugProcess::GetID Method"
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
  - "ICorDebugProcess.GetID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::GetID"
helpviewer_keywords: 
  - "GetID method, ICorDebugProcess interface [.NET Framework debugging]"
  - "ICorDebugProcess::GetID method [.NET Framework debugging]"
ms.assetid: b0ba8453-fa7e-4c14-93e5-335409cd4a47
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::GetID Method
Gets the operating system (OS) ID of the process.  
  
## Syntax  
  
```  
HRESULT GetID([out] DWORD *pdwProcessId);  
```  
  
#### Parameters  
 `pdwProcessId`  
 [out] The unique ID of the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
