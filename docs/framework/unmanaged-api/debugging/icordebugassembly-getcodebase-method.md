---
title: "ICorDebugAssembly::GetCodeBase Method"
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
  - "ICorDebugAssembly.GetCodeBase"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly::GetCodeBase"
helpviewer_keywords: 
  - "GetCodeBase method [.NET Framework debugging]"
  - "ICorDebugAssembly::GetCodeBase method [.NET Framework debugging]"
ms.assetid: 48adc154-9058-4fef-9c43-e9aad80e4dbf
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly::GetCodeBase Method
This method is not implemented in the current version of the .NET Framework.  
  
## Syntax  
  
```  
HRESULT GetCodeBase (  
    [in] ULONG32  cchName,  
    [out] ULONG32 *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]   
        WCHAR szName[]  
);  
```
