---
title: "ICorDebugFrame::GetCode Method | Microsoft Docs"
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
  - "ICorDebugFrame.GetCode"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugFrame::GetCode"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetCode method, ICorDebugFrame interface [.NET Framework debugging]"
  - "ICorDebugFrame::GetCode method [.NET Framework debugging]"
ms.assetid: fbaa0794-a031-4015-8beb-2749e47ac340
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugFrame::GetCode Method
Gets a pointer to the code associated with this stack frame.  
  
## Syntax  
  
```  
HRESULT GetCode (  
    [out] ICorDebugCode      **ppCode  
);  
```  
  
#### Parameters  
 `ppCode`  
 [out] A pointer to the address of an ICorDebugCode object that represents the code associated with this frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]