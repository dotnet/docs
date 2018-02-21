---
title: "ICorDebugFunction2::EnumerateNativeCode Method"
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
  - "ICorDebugFunction2.EnumerateNativeCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction2::EnumerateNativeCode"
helpviewer_keywords: 
  - "ICorDebugFunction2::EnumerateNativeCode method [.NET Framework debugging]"
  - "EnumerateNativeCode method [.NET Framework debugging]"
ms.assetid: d383f5cc-1144-4b6d-b57a-db34d9134ab2
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction2::EnumerateNativeCode Method
Gets an interface pointer to an ICorDebugCodeEnum object that contains the native code statements in the function referenced by this ICorDebugFunction2 object.  
  
> [!NOTE]
>  `EnumerateNativeCode` is not implemented in the current version of the .NET Framework.  
  
## Syntax  
  
```  
HRESULT EnumerateNativeCode (  
    [out] ICorDebugCodeEnum   **ppCodeEnum  
);  
```  
  
## Requirements  
 **Header:** CorDebug.idl, CorDebug.h
