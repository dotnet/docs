---
title: "ICorDebugObjectValue2::GetVirtualMethodAndType Method | Microsoft Docs"
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
  - "ICorDebugObjectValue2.GetVirtualMethodAndType"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugObjectValue2::GetVirtualMethodAndType"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetVirtualMethodAndType method [.NET Framework debugging]"
  - "ICorDebugObjectValue2::GetVirtualMethodAndType method"
ms.assetid: 621b4543-a8f7-4117-98e4-930992cd688a
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugObjectValue2::GetVirtualMethodAndType Method
This method is not yet implemented.  
  
## Syntax  
  
```  
HRESULT GetVirtualMethodAndType (  
    [in] mdMemberRef          memberRef,  
    [out] ICorDebugFunction   **ppFunction,  
    [out] ICorDebugType       **ppType  
);  
```  
  
## Remarks  
 Gets interface pointers to the "ICorDebugFunction" and "ICorDebugType" instances that represent the most derived method and type for the specified member reference.  
  
## See Also  
    
 