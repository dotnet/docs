---
title: "ICorDebugAssembly::GetProcess Method | Microsoft Docs"
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
  - "ICorDebugAssembly.GetProcess"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugAssembly::GetProcess"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugAssembly::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: ea52be06-0a16-4f57-afca-4287d72e76c4
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugAssembly::GetProcess Method
Gets an interface pointer to the process in which this ICorDebugAssembly instance is running.  
  
## Syntax  
  
```  
HRESULT GetProcess (  
    [out] ICorDebugProcess **ppProcess  
);  
```  
  
#### Parameters  
 `ppProcess`  
 [out] A pointer to an ICorDebugProcess interface that represents the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]