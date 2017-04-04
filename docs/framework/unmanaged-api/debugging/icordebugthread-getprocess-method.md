---
title: "ICorDebugThread::GetProcess Method | Microsoft Docs"
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
  - "ICorDebugThread.GetProcess"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugThread::GetProcess"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugThread::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorDebugThread interface [.NET Framework debugging]"
ms.assetid: 163816e7-0739-4566-b3df-cd256be8b8a4
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugThread::GetProcess Method
Gets an interface pointer to the process of which this ICorDebugThread forms a part.  
  
## Syntax  
  
```  
HRESULT GetProcess (  
    [out] ICorDebugProcess   **ppProcess  
);  
```  
  
#### Parameters  
 `ppProcess`  
 [out] A pointer to the address of an ICorDebugProcess interface object that represents the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]