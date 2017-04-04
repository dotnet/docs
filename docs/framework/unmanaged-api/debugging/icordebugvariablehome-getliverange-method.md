---
title: "IcorDebugVariableHome::GetLiveRange Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
apiname: 
  - "ICorDebugVariableHome.GetLiveRange"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetLiveRange"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetLiveRange method [.NET Framework debugging]"
  - "GetLiveRange method, ICorDebugVariableFrame interface [.NET Framework debugging]"
ms.assetid: 87277e1a-1595-4729-9e25-d1c3ac18ce5f
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# IcorDebugVariableHome::GetLiveRange Method
Gets the native range over which this variable is live.  
  
## Syntax  
  
```  
  
HRESULT GetLiveRange(  
    [out] ULONG32* pStartOffset,  
    [out] ULONG32 *pEndOffset  
);  
  
```  
  
#### Parameters  
 `pStartOffset`  
 [out] The logical offset at which the variable is first live.  
  
 `pEndOffset`  
 [out] The logical offset immediately after the point at which the variable is last live.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See Also  
 [ICorDebugVariableHome Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugvariablehome-interface.md)