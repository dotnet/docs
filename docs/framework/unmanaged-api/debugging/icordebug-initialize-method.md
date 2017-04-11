---
title: "ICorDebug::Initialize Method | Microsoft Docs"
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
  - "ICorDebug.Initialize"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebug::Initialize"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "Initialize method, ICorDebug interface [.NET Framework debugging]"
  - "ICorDebug::Initialize method [.NET Framework debugging]"
ms.assetid: 6fae3b23-5c9f-47c0-85d8-6bb75e050786
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebug::Initialize Method
Initializes the `ICorDebug` object.  
  
## Syntax  
  
```  
HRESULT Initialize ();  
```  
  
## Remarks  
 The debugger must call `Initialize` at creation time to initialize the debugging services. This method must be called before any other method on `ICorDebug` is called.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)