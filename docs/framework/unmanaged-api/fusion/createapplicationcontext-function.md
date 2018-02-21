---
title: "CreateApplicationContext Function"
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
  - "CreateApplicationContext"
api_location: 
  - "fusion.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateApplicationContext"
helpviewer_keywords: 
  - "CreateApplicationContext function [.NET Framework fusion]"
ms.assetid: 7bf8a141-b2c0-4058-9885-1cef7dcaa811
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateApplicationContext Function
This function supports the .NET Framework infrastructure and is not intended to be used directly from your code.  
  
## Syntax  
  
```  
HRESULT CreateApplicationContext (  
    [in]  IAssemblyName  *pName,  
    [out] LPPAPPLICATIONCONTEXT  *ppCtx  
 );  
```  
  
#### Parameters  
 `pName`  
 [in] A pointer to a friendly name.  
  
 `ppCtx`  
 [out] A pointer to an application context.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in Fusion.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyCache Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblycache-interface.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)
