---
title: "ICorDebugEnum::GetCount Method | Microsoft Docs"
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
  - "ICorDebugEnum.GetCount"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugEnum::GetCount"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugEnum::GetCount method [.NET Framework debugging]"
  - "GetCount method, ICorDebugEnum interface [.NET Framework debugging]"
ms.assetid: d8a74304-1cb2-4977-a21d-e1af48c563ff
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugEnum::GetCount Method
Gets the number of items in the enumeration.  
  
## Syntax  
  
```  
HRESULT GetCount (  
    [out] ULONG *pcelt  
);  
```  
  
#### Parameters  
 `pcelt`  
 [out] A pointer to the number of items in the enumeration.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]