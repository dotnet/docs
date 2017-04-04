---
title: "ICorDebugProcess::ModifyLogSwitch Method | Microsoft Docs"
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
  - "ICorDebugProcess.ModifyLogSwitch"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugProcess::ModifyLogSwitch"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugProcess::ModifyLogSwitch method [.NET Framework debugging]"
  - "ModifyLogSwitch method [.NET Framework debugging]"
ms.assetid: 5fd30875-555e-4e96-877b-5dd266cde7c4
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugProcess::ModifyLogSwitch Method
Sets the severity level of the specified log switch.  
  
## Syntax  
  
```  
HRESULT ModifyLogSwitch(  
    [in] WCHAR *pLogSwitchName,  
    [in] LONG  lLevel);  
```  
  
#### Parameters  
 `pLogSwitchName`  
 [in] A pointer to a string that specifies the name of the log switch.  
  
 `lLevel`  
 [in] The severity level to be set for the specified log switch.  
  
## Remarks  
 This method is valid only after the [ICorDebugManagedCallback::CreateProcess](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-createprocess-method.md) callback has occurred.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]