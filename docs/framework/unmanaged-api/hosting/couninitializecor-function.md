---
title: "CoUninitializeCor Function"
ms.date: "03/30/2017"
api_name: 
  - "CoUninitializeCor"
api_location: 
  - "mscoree.dll"
  - "mscorsvr.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CoUninitializeCor"
helpviewer_keywords: 
  - "CoUninitializeCor function [.NET Framework hosting]"
ms.assetid: 50a95b8b-9766-470e-bb29-2c7ecddfd4a1
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# CoUninitializeCor Function
`CoUninitializeCor` is obsolete.  
  
## Syntax  
  
```  
STDAPI_(void) CoUninitializeCor(void);  
```  
  
## Remarks  
 The common language runtime cannot be unloaded from a process. To completely remove the runtime from a running process, you must shut down that process.  
  
## See also

- [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
