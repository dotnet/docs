---
description: "Learn more about: ICorDebugThread::GetRegisterSet Method"
title: "ICorDebugThread::GetRegisterSet Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread.GetRegisterSet"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::GetRegisterSet"
helpviewer_keywords: 
  - "ICorDebugThread::GetRegisterSet method [.NET Framework debugging]"
  - "GetRegisterSet method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 3b9b6260-98ac-4cfd-88e5-5d7614f94a0c
topic_type: 
  - "apiref"
---
# ICorDebugThread::GetRegisterSet Method

Gets an interface pointer to the register set that is associated with the active part of this ICorDebugThread object.  
  
## Syntax  
  
```cpp  
HRESULT GetRegisterSet (  
    [out] ICorDebugRegisterSet **ppRegisters  
);  
```  
  
## Parameters  

 `ppRegisters`  
 [out] A pointer to the address of an [ICorDebugRegisterSet](icordebugregisterset-interface.md) interface object that represents the register set for the active part of this thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
