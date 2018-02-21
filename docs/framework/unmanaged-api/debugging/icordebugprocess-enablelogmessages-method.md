---
title: "ICorDebugProcess::EnableLogMessages Method"
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
  - "ICorDebugProcess.EnableLogMessages"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::EnableLogMessages"
helpviewer_keywords: 
  - "ICorDebugProcess::EnableLogMessages method [.NET Framework debugging]"
  - "EnableLogMessages method [.NET Framework debugging]"
ms.assetid: 14a4e5a3-3eaf-4f53-9dd1-762726963a23
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::EnableLogMessages Method
Enables and disables the transmission of log messages to the debugger.  
  
## Syntax  
  
```  
HRESULT EnableLogMessages([in]BOOL fOnOff);  
```  
  
#### Parameters  
 `fOnOff`  
 [in] `true` enables the transmission of log messages; `false` disables the transmission.  
  
## Remarks  
 This method is valid only after the [ICorDebugManagedCallback::CreateProcess](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-createprocess-method.md) callback occurs.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
