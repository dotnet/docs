---
title: "ICorDebugStringValue::GetLength Method | Microsoft Docs"
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
  - "ICorDebugStringValue.GetLength"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugStringValue::GetLength"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugStringValue::GetLength method [.NET Framework debugging]"
  - "GetLength method [.NET Framework debugging]"
ms.assetid: a1ebfc69-46a6-4225-8788-b7cfb2f15e1d
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugStringValue::GetLength Method
Gets the number of characters in the string referenced by this ICorDebugStringValue.  
  
## Syntax  
  
```  
HRESULT GetLength (  
    [out] ULONG32   *pcchString  
);  
```  
  
#### Parameters  
 `pcchString`  
 [out] A pointer to a value that specifies the length of the string referenced by this `ICorDebugStringValue` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]