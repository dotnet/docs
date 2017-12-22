---
title: "ICorDebugArrayValue::HasBaseIndicies Method"
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
  - "ICorDebugArrayValue.HasBaseIndicies"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::HasBaseIndicies"
helpviewer_keywords: 
  - "HasBaseIndicies method [.NET Framework debugging]"
  - "ICorDebugArrayValue::HasBaseIndicies method [.NET Framework debugging]"
ms.assetid: aa26df07-e0a6-4608-bdef-d4afafec89aa
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugArrayValue::HasBaseIndicies Method
Gets a value that indicates whether any dimensions of this array have a base index of non-zero.  
  
## Syntax  
  
```  
HRESULT HasBaseIndicies (  
    [out] BOOL    *pbHasBaseIndicies  
);  
```  
  
#### Parameters  
 `pbHasBaseIndicies`  
 [out] A pointer to a Boolean value that is `true` if one or more dimensions of this `ICorDebugArrayValue` object have a base index of non-zero; otherwise, the Boolean value is `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]
