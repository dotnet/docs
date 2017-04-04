---
title: "ICorDebugType::GetRank Method | Microsoft Docs"
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
  - "ICorDebugType.GetRank"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugType::GetRank"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetRank method, ICorDebugType interface [.NET Framework debugging]"
  - "ICorDebugType::GetRank method [.NET Framework debugging]"
ms.assetid: 72d3d927-f590-4f2d-8f60-448f3dfb96af
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugType::GetRank Method
Gets the number of dimensions in an array type.  
  
## Syntax  
  
```  
HRESULT GetRank (  
    [out] ULONG32   *pnRank  
);  
```  
  
#### Parameters  
 `pnRank`  
 [out] A pointer to the number of dimensions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]