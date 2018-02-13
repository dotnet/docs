---
title: "ICorDebugStringValue::GetString Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugStringValue.GetString"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugStringValue::GetString"
helpviewer_keywords: 
  - "ICorDebugStringValue::GetString method [.NET Framework debugging]"
  - "GetString method, ICorDebugStringValue interface [.NET Framework debugging]"
ms.assetid: 2b94bda7-09ee-435d-91b9-c4e31af1896c
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugStringValue::GetString Method
Gets the string referenced by this ICorDebugStringValue.  
  
## Syntax  
  
```  
HRESULT GetString (  
    [in] ULONG32    cchString,  
    [out] ULONG32   *pcchString,  
    [out, size_is(cchString), length_is(*pcchString)]   
        WCHAR       szString[]  
);  
```  
  
#### Parameters  
 `cchString`  
 [in] The size of the `szString` array.  
  
 `pcchString`  
 [out] A pointer to the number of characters returned in the `szString` array.  
  
 `szString`  
 [out] An array that stores the retrieved string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
