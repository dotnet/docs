---
title: "ClearDownloadCache Function"
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
  - "ClearDownloadCache"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ClearDownloadCache"
helpviewer_keywords: 
  - "ClearDownloadCache function [.NET Framework fusion]"
ms.assetid: df7595d1-430f-44b4-8160-4c2ba9df70b1
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ClearDownloadCache Function
Clears the global assembly cache of downloaded assemblies.  
  
## Syntax  
  
```  
HRESULT ClearDownloadCache ();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Fusion.dll and Mscorwks.dll. Use Fusion.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)
