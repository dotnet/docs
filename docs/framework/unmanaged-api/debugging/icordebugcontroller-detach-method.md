---
title: "ICorDebugController::Detach Method"
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
  - "ICorDebugController.Detach"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::Detach"
helpviewer_keywords: 
  - "Detach method, ICorDebugController interface [.NET Framework debugging]"
  - "ICorDebugController::Detach method [.NET Framework debugging]"
ms.assetid: 06fae364-f2c6-4a50-aa7e-3da9f2684dc3
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugController::Detach Method
Detaches the debugger from the process or application domain.  
  
## Syntax  
  
```  
HRESULT Detach ();  
```  
  
## Remarks  
 The process or application domain continues execution normally, but the "ICorDebugProcess" or "ICorDebugAppDomain" object is no longer valid and no further callbacks will occur.  
  
 In the .NET Framework version 2.0, if unmanaged debugging is enabled, this method will fail due to operating system limitations.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
