---
title: "ICorDebugChain::GetPrevious Method | Microsoft Docs"
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
  - "ICorDebugChain.GetPrevious"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugChain::GetPrevious"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugChain::GetPrevious method [.NET Framework debugging]"
  - "GetPrevious method [.NET Framework debugging]"
ms.assetid: 58eed4c8-d80c-4c6a-a875-967a90dd926c
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugChain::GetPrevious Method
Gets the previous chain of frames for the thread.  
  
## Syntax  
  
```  
HRESULT GetPrevious (  
    [out] ICorDebugChain     **ppChain  
);  
```  
  
#### Parameters  
 `ppChain`  
 [out] A pointer to the address of an ICorDebugChain object that represents the previous chain of frames for this thread. If this chain is the first chain, `ppChain` is null.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]