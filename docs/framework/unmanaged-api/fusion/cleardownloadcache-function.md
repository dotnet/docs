---
title: "ClearDownloadCache Function"
ms.date: "03/30/2017"
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
author: "rpetrusha"
ms.author: "ronpet"
---
# ClearDownloadCache Function
Clears the global assembly cache of downloaded assemblies.  
  
## Syntax  
  
```cpp  
HRESULT ClearDownloadCache ();  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Fusion.dll and Mscorwks.dll. Use Fusion.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Fusion Global Static Functions](fusion-global-static-functions.md)
- [Global Assembly Cache](../../app-domains/gac.md)
