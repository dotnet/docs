---
title: "ICorDebugHandleValue::Dispose Method | Microsoft Docs"
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
  - "ICorDebugHandleValue.Dispose"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugHandleValue::Dispose"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugHandleValue::Dispose method [.NET Framework debugging]"
  - "Dispose method [.NET Framework debugging]"
ms.assetid: c1542811-0a7f-4235-bcfd-b24370d6f24b
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugHandleValue::Dispose Method
Releases the handle referenced by this ICorDebugHandleValue object without explicitly releasing the interface pointer.  
  
## Syntax  
  
```  
HRESULT Dispose ();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]