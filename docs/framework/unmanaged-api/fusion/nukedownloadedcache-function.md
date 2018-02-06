---
title: "NukeDownloadedCache Function"
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
  - "NukeDownloadedCache"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "NukeDownloadedCache"
helpviewer_keywords: 
  - "NukeDownloadedCache function [.NET Framework fusion]"
ms.assetid: fac2b1c6-6fa3-4818-805b-b63972024c86
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# NukeDownloadedCache Function
Deletes the common language runtime (CLR) download cache.  
  
## Syntax  
  
```  
HRESULT NukeDownloadedCache();  
```  
  
## Return Value  
 This method returns standard COM error codes, as defined in WinError.h.  
  
## Remarks  
 The CLR download cache is the area where strong-named assemblies that are downloaded from a URL are stored for possible reuse.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Fusion.dll and Mscorwks.dll. Use Fusion.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [CreateHistoryReader Function](../../../../docs/framework/unmanaged-api/fusion/createhistoryreader-function.md)  
 [GetHistoryFileDirectory Function](../../../../docs/framework/unmanaged-api/fusion/gethistoryfiledirectory-function.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)
