---
title: "ICorDebugModule::GetSize Method | Microsoft Docs"
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
  - "ICorDebugModule.GetSize"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugModule::GetSize"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetSize method, ICorDebugModule interface [.NET Framework debugging]"
  - "ICorDebugModule::GetSize method [.NET Framework debugging]"
ms.assetid: 5c68375d-145d-46ef-a7c8-2dc4257472de
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugModule::GetSize Method
Gets the size, in bytes, of the module.  
  
## Syntax  
  
```  
HRESULT GetSize(  
    [out] ULONG32 *pcBytes  
);  
```  
  
#### Parameters  
 `pcBytes`  
 [out] The size of the module in bytes.  
  
 If the module was produced from the native image generator (NGen.exe), the size of the module will be zero.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]