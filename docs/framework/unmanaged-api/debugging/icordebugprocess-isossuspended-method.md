---
title: "ICorDebugProcess::IsOSSuspended Method"
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
  - "ICorDebugProcess.IsOSSuspended"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::IsOSSuspended"
helpviewer_keywords: 
  - "IsOSSuspended method [.NET Framework debugging]"
  - "ICorDebugProcess::IsOSSuspended method [.NET Framework debugging]"
ms.assetid: 83406cb2-5797-4402-872d-89c9516aefec
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::IsOSSuspended Method
Gets a value that indicates whether the specified thread has been suspended as a result of the debugger stopping this process.  
  
## Syntax  
  
```  
HRESULT IsOSSuspended(  
    [in]  DWORD threadID,  
    [out] BOOL  *pbSuspended);  
```  
  
#### Parameters  
 `threadID`  
 [in] The ID of thread in question.  
  
 `pbSuspended`  
 [out] A pointer to a Boolean value that is `true` if the specified thread has been suspended; otherwise *`pbSuspended` is `false`.  
  
## Remarks  
 When the specified thread has been suspended as a result of the debugger stopping this process, the specified thread's Win32 suspend count is incremented by one. The debugger user interface (UI) may want to take this information into account if it displays the operating system (OS) suspend count of the thread to the user.  
  
 The `IsOSSuspended` method makes sense only in the context of unmanaged debugging. During managed debugging, threads are cooperatively suspended rather than OS-suspended.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
