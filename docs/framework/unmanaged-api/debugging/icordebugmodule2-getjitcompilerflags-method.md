---
title: "ICorDebugModule2::GetJITCompilerFlags Method | Microsoft Docs"
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
  - "ICorDebugModule2.GetJITCompilerFlags"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugModule2::GetJITCompilerFlags"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetJITCompilerFlags method [.NET Framework debugging]"
  - "ICorDebugModule2::GetJITCompilerFlags method [.NET Framework debugging]"
ms.assetid: 7212d9f4-989b-44e3-b8d4-ffc35922f6a0
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugModule2::GetJITCompilerFlags Method
Gets the flags that control the just-in-time (JIT) compilation of this ICorDebugModule2.  
  
## Syntax  
  
```  
HRESULT GetJITCompilerFlags (  
    [out] DWORD   *pdwFlags  
);  
```  
  
#### Parameters  
 `pdwFlags`  
 [out] A pointer to a value of the [CorDebugJITCompilerFlags](../../../../docs/framework/unmanaged-api/debugging/cordebugjitcompilerflags-enumeration.md) enumeration that controls the JIT compilation.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]