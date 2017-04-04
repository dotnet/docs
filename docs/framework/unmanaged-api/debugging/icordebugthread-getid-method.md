---
title: "ICorDebugThread::GetID Method | Microsoft Docs"
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
  - "ICorDebugThread.GetID"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugThread::GetID"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugThread::GetID method [.NET Framework debugging]"
  - "GetID method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: f1de4584-92df-42f3-9da4-fca03a1c6821
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugThread::GetID Method
Gets the current operating system identifier of the active part of this ICorDebugThread.  
  
## Syntax  
  
```  
HRESULT GetID (  
    [out] DWORD *pdwThreadId  
);  
```  
  
#### Parameters  
 `pdwThreadId`  
 [out] The identifier of the thread.  
  
## Remarks  
 The operating system identifier can potentially change during execution of a process, and can be a different value for different parts of the thread.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]