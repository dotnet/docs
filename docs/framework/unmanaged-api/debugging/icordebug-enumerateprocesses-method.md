---
title: "ICorDebug::EnumerateProcesses Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorDebug.EnumerateProcesses"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "EnumerateProcesses"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "EnumerateProcesses method [.NET Framework debugging]"
  - "ICorDebug::EnumerateProcesses method [.NET Framework debugging]"
ms.assetid: ba25d166-1d28-4f1d-aca2-de298bbca669
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebug::EnumerateProcesses Method
Gets an enumerator for the processes that are being debugged.  
  
## Syntax  
  
```  
HRESULT EnumerateProcesses (  
    [out] ICorDebugProcessEnum      **ppProcess  
);  
```  
  
#### Parameters  
 `ppProcess`  
 A pointer to the address of an ICorDebugProcessEnum object that is the enumerator for the processes being debugged.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)